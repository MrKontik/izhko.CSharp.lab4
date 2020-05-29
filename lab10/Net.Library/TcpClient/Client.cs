using System;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace SomeProject.Library.Client
{
    public class Client
    {
        public TcpClient tcpClient;

        public OperationResult ReceiveMessageFromServer()
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 8080);
                StringBuilder recievedMessage = new StringBuilder();
                byte[] data = new byte[256];
                NetworkStream stream = tcpClient.GetStream();

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    recievedMessage.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);
                stream.Close();
                tcpClient.Close();

                return new OperationResult(Result.OK, recievedMessage.ToString());
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.ToString());
            }
        }

        public OperationResult SendMessageToServer(string message)
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();
                byte[] data = System.Text.Encoding.UTF8.GetBytes("0"+message);
                stream.Write(data, 0, data.Length);
                stream.Close();
                tcpClient.Close();
                return new OperationResult(Result.OK, "") ;
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }
        public OperationResult SendFileToServer(string FileName)
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();
                using (FileStream fstream = File.OpenRead(FileName))
                {
                    // декодируем байты в строку
                    //string textFromFile = System.Text.Encoding.Default.GetString(array);
                    //Console.WriteLine($"Текст из файла: {textFromFile}");
                    byte[] data = System.Text.Encoding.UTF8.GetBytes("1" + FileName.Substring(FileName.LastIndexOf(".")+1,FileName.Length- FileName.LastIndexOf(".")-1) +"$"+ fstream.Length+"%");
                    // преобразуем строку в байты
                    //byte[] data2 = new byte[fstream.Length];
                    byte[] data2 = new byte[4000096];
                    // считываем данные
                    fstream.Read(data2, 0, data2.Length);
                    //byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    stream.Write(data2, 0, data2.Length);
                    stream.Close();
                    tcpClient.Close();
                }
                return new OperationResult(Result.OK, "");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }
    }
}
