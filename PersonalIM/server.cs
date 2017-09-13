using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace PersonalIM
{
    public class Server
    {
        
        public static void Main(string[] args)
        {
            int maxBytes = 10025;
            //Set LocalIP Address
            IPAddress localIp = IPAddress.Parse("127.0.0.1");
            //Init count of requests for the server
            int requestCount = 0;
            //Create the server | TcpListener -> constantly listens for input | 8888 -> Random Port num
            TcpListener server = new TcpListener(localIp, 8888);
            //Create the client | default | TcpClient -> Provides the client connections
            TcpClient client = default(TcpClient);
            //Start the server
            server.Start();
            Console.WriteLine(" >> Server Started");
            //Accepts a pending connection request
            client = server.AcceptTcpClient();
            Console.WriteLine(" >> Accepted Connection");
            //Reinitialize request count?? Example had this dont know why
            requestCount = 0;

            while ((true))
            {
                try
                {
                    //Up Request count and print the request count
                    requestCount++;
                    Console.WriteLine(requestCount);
                    //Set the stream to be coming from the client | NetworkStream -> Provides the underlying stream of data for network access
                    NetworkStream networkStream = client.GetStream();
                    //Set bytes to be read from client 
                    byte[] bytesFrom = new byte[maxBytes];
                    //Read from the stream, the amount of bytes, Read(Byte[], Int32, Int32 (LENGTH?)) TODO
                    networkStream.Read(bytesFrom, 0, (int) client.ReceiveBufferSize);
                    //Reads into a string from the bytes received
                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    Console.WriteLine(" >> Data from client - " + dataFromClient);
                    //Sets a simple server response to be
                    string serverResponse = "Last Message from client" + dataFromClient;
                    //Sets bytes to send from a string encoded with ASCII
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    //Writes the response into the network stream
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            client.Close();
            server.Stop();
            Console.WriteLine(" >> exit");
            Console.ReadLine();
        }
        
    }
}