using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProj
{
    [Serializable]
    public class LogsInfo
    {
        public string Log { get; set; }
        public LogsInfo(string log)
        {
            this.Log = log;
        }
    }

    [Serializable]
    public class Client
    {
        private TcpClient client;
        private NetworkStream stream;
        private BinaryWriter writer;
        private BinaryReader reader;

        public string Id { get; private set; }
        public decimal Sum { get; private set; }
        public int Pin { get; private set; }

        private CancellationTokenSource tokenFakeMoneySource;
        private CancellationToken tokenFakeMoney;
        private CancellationTokenSource tokenReceivingMoneySource;
        private CancellationToken tokenReceivingMoney;

        public delegate Task AddLogDelegate(string log);
        private AddLogDelegate addLog;

        public void AddLoggerFunction(AddLogDelegate logFunction)
        {
            addLog += logFunction;
        }

        public void DeleteLoggerFunction(AddLogDelegate logFunction)
        {
            Delegate newDelegate = System.Delegate.Remove(addLog, logFunction);
            addLog = newDelegate as AddLogDelegate;
        }

        public Client(int pin)
        {
            this.Id = Guid.NewGuid().ToString().Remove(31, 4);
            this.Sum = 10000;
            this.Pin = pin;
            ConnectToServer();
        }
        public Client(string id, decimal sum, int pin)
        {
            this.Id = id;
            this.Sum = sum;
            this.Pin = pin;
            ConnectToServer();
        }

        private int GetPort()
        {
            Random random = new Random();
            int port = random.Next(1000, 2000);
            bool isAvailable = true;
            do
            {
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

                foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
                {
                    if (tcpi.LocalEndPoint.Port == port)
                    {
                        isAvailable = false;
                        port++;
                        break;
                    }
                }
            } while (!isAvailable);
            return port;
        }

        public void ConnectToServer()
        {
            try
            {
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), GetPort());
                client = new TcpClient(iPEndPoint);

                //TODO: PORT SERVERA 1717
                client.Connect("127.0.0.1", 1717);
                stream = client.GetStream();
                reader = new BinaryReader(stream);
                writer = new BinaryWriter(stream);

                writer.Write(this.Id);
                writer.Flush();

                /*VS STUDIO 2013 .net 4.5 не знает сокращения addLog?.Invoke => if addLog != null */
                if (addLog != null)
                {
                    addLog.Invoke(String.Format("[{0}]: Вы вошли в банк.", DateTime.Now.ToString()));
                }
                
                ReceivingMoneyAsync();
                SendFakeMoneyAsync();
            }
            catch
            {
                MessageBox.Show("Банк закрыт. Вернитесь позже.");
                Application.Exit();
            }
        }

        public void DisconnectFromServer()
        {
            /*VS STUDIO 2013 .net 4.5 не знает сокращения addLog?.Invoke => if addLog != null */
            if (addLog != null)
            {
                addLog.Invoke(String.Format("[{0}]: Вы вышли из банка.", DateTime.Now.ToString()));
            }
 
            tokenFakeMoneySource.Cancel();
            tokenReceivingMoneySource.Cancel();
            client.Close();
        }

        public async void ReceivingMoneyAsync()
        {
            tokenReceivingMoneySource = new CancellationTokenSource();
            tokenReceivingMoney = tokenReceivingMoneySource.Token;

            await Task.Run(() =>
            {
                while (true)
                {
                    if (tokenReceivingMoney.IsCancellationRequested)
                    {
                        break;
                    }
                    try
                    {
                        decimal money = reader.ReadDecimal();
                        Sum += money;

           
                            addLog.Invoke(String.Format("[{0}]: Зачисление [{1}]. Баланс [{2}].", DateTime.Now.ToString(), money, Sum));
                        
                    }
                    catch
                    {
                        break;
                    }     
                }
            });
        }

        public bool SendMoney(string id, decimal sum, bool fakeMoney)
        {
            try
            {
                if (sum < this.Sum)
                {
                    writer.Write(id);
                    writer.Write(sum);
                    writer.Flush();

                    if (!fakeMoney)
                    {
                        this.Sum -= sum;
                        /*VS STUDIO 2013 .net 4.5 не знает сокращения addLog?.Invoke => if addLog != null */
                        if (addLog != null)
                        {
                            addLog.Invoke(String.Format("[{0}]: Отправлено [{1}]. Баланс [{2}].", DateTime.Now.ToString(), sum, this.Sum));
                            addLog.Invoke(String.Format("Получатель: [{0}].", id));
                        }  
                    }
                    return true;
                }
            }
            catch
            {
                DisconnectFromServer();
            }
            return false;
        }

        public async Task SendFakeMoneyAsync()
        {
            tokenFakeMoneySource = new CancellationTokenSource();
            tokenFakeMoney = tokenFakeMoneySource.Token;

            await Task.Run(() =>
            {
                int sendSum, timeSleep;
                Random random = new Random();

                while (true)
                {
                    if (tokenFakeMoney.IsCancellationRequested)
                    {
                        break;
                    }
                    timeSleep = random.Next(1000, 10000);
                    Thread.Sleep(timeSleep);
                    sendSum = random.Next(1000, 2000);
                    SendMoney(this.Id, sendSum, true);
                }
            });
        }
    }
}
