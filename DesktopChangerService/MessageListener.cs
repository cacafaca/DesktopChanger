using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DesktopChangerService
{
    public class MessageListener
    {
        public MessageListener()
        {
            CanWork = false;
            IPAddress = Dns.GetHostEntry("localhost").AddressList[0];
            MessageListenSocket = new TcpListener(IPAddress, 2525);
        }

        public void Start()
        {
            CanWork = true;
            Listener = new Thread(new ThreadStart(DoListen));
            Listener.Start();
        }

        public void Stop()
        {
            CanWork = false;
        }

        Thread Listener;
        bool CanWork;

        private void DoListen()
        {
            int buffSize = 512;
            while (CanWork)
            {
                Thread.Sleep(10);
                TcpClient tcpClient = MessageListenSocket.AcceptTcpClient();
                byte[] receiveData = new byte[buffSize];
                NetworkStream stream = tcpClient.GetStream();
                stream.Read(receiveData, 0, buffSize);

            }
        }

        TcpListener MessageListenSocket;
        IPAddress IPAddress;
    }
}
