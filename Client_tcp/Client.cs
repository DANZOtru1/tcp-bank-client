using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_tcp
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

    
}
