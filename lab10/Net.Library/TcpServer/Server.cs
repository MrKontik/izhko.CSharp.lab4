using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SomeProject.Library.Server
{
    public class Server
    {
        public static long MaxConn=4;
        public static long CurConn;
        public static int NumberFile;
        TcpListener serverListener;

        public Server()
        {
            NumberFile = 0;
            CurConn = 0;
            serverListener = new TcpListener(IPAddress.Loopback, 8080);
        }

        public bool TurnOffListener()
        {
            try
            {
                if (serverListener != null)
                    serverListener.Stop();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot turn off listener: " + e.Message);
                return false;
            }
        }

        public async Task TurnOnListener()
        {
            try
            {
                if (serverListener != null)
                    serverListener.Start();
                Console.WriteLine("Waiting for connections...");
                Console.WriteLine("The current number of connections: " + CurConn);
                while (true)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(NewConnection), serverListener.AcceptTcpClient());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot turn on listener: " + e.Message);
            }
        }
        static void NewConnection(object client)
        {
            while (Interlocked.Read(ref CurConn) >= Interlocked.Read(ref MaxConn))
            { }
            if (Interlocked.Read(ref CurConn) < Interlocked.Read(ref MaxConn))
            {
                Interlocked.Increment(ref CurConn);
                Console.WriteLine("The current number of connections: " + CurConn);
                OperationResult result = ReceiveMessageFromClient((TcpClient)client).Result;
                if (result.Result == Result.Fail)
                    Console.WriteLine("Unexpected error: " + result.Message);
                else
                    Console.WriteLine(result.Message);
                Interlocked.Decrement(ref CurConn);
            }
        }


        public async static Task<OperationResult> ReceiveMessageFromClient(TcpClient client)
        {
            try
            {
                Console.WriteLine("Waiting for connections...");
                StringBuilder recievedMessage = new StringBuilder(); 

                byte[] data = new byte[1];
                NetworkStream stream = client.GetStream();
                int bytes = stream.Read(data, 0, data.Length);
                string str = Encoding.UTF8.GetString(data, 0, bytes);
                if (str == "0")
                {
                    data = new byte[256];
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        recievedMessage.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    stream.Close();
                    client.Close();
                }
                if (str == "1")
                {
                    ReceiveFileFromClient(stream);
                    client.Close();
                }
                return new OperationResult(Result.OK, recievedMessage.ToString());
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        public static OperationResult ReceiveFileFromClient(NetworkStream stream)
        {
            try
            {
                if (!Directory.Exists(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    Directory.CreateDirectory(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                Interlocked.Increment(ref NumberFile);
                byte[] data = new byte[4000096];
                int bytes = stream.Read(data, 0, data.Length);
                string str= Encoding.UTF8.GetString(data, 0, bytes);
                //data = new byte[Int32.Parse(str.Substring(str.IndexOf("$"), str.IndexOf("%")- str.IndexOf("$")))];
                using (FileStream fstream = new FileStream(DateTime.Now.ToString("yyyy-MM-dd") + "\\File"+NumberFile+"."+str.Substring(0, str.IndexOf('$')), FileMode.OpenOrCreate))
                {
                    //TCP юдипи в чем отличие, что можно написать на тсп, в чем отличие. архитектуры, проблемы, о чем подумать, где точно нужен сервер 
                    str = str.Substring(str.IndexOf('$') + 1, str.Length - str.IndexOf('$') - 1);
                    byte[] data2 = Encoding.UTF8.GetBytes(str);
                    fstream.Write(data2, 0, data2.Length);
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        //data2 = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data, 0, bytes));
                        fstream.Write(data, 0, bytes);
                    }
                    while (stream.DataAvailable);
                }
                stream.Close();
                
                return new OperationResult(Result.OK, "");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        public OperationResult SendMessageToClient(string message)
        {
            try
            {
                TcpClient client = serverListener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
            return new OperationResult(Result.OK, "");
        }
      
    }
}