using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography;

namespace TableTCPHost
{
    class HostListener
    {
        public void Listen(int port)
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAdr = ipHost.AddressList[0];
            IPEndPoint ipPoint = new IPEndPoint(ipAdr, port);

            // создаем сокет
            Socket listenSocket = new Socket(ipAdr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(5);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytesCount = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных

                    do
                    {
                        bytesCount = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytesCount));
                    }
                    while (handler.Available > 0);

                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

                    // отправляем ответ
                    string message = "ваше сообщение доставлено";
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

