using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace WiFi_Server_CSharp
{
    class UDPSocket
    {
        private Socket socket;
        EndPoint localEP, remoteEP;
        byte[] buffer = new byte[1024];
        
        void Initialize(string ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            localEP = new IPEndPoint(IPAddress.Any, port);
            remoteEP = new IPEndPoint(IPAddress.None, port);

            socket.Bind(localEP);

            createSocketThread();
        }

        private Thread SThread;
        private void createSocketThread()
        {
            SThread = new Thread(SocketThread);
            SThread.Start();
        }

        private void SocketThread()
        {
            while (true)
            {
            }
        }

        public void disconnect()
        {
            SThread.Abort();
        }
    }
}
