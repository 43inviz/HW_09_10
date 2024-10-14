using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HW_09_10_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StartClient();

        }

        


        public static void StartClient()
        {
            string serverAdress = "127.0.0.1";
            int port = 8888;

            try
            {
                TcpClient client = new TcpClient(serverAdress, port);
                Console.WriteLine("Connect to server...");

                NetworkStream stream = client.GetStream();
                Console.WriteLine("Enter 'date' to get current date or 'time' for current time:");
                string requesst = Console.ReadLine();

                byte[] data = Encoding.ASCII.GetBytes(requesst);
                stream.Write(data, 0, data.Length);


                data = new byte[256];
                StringBuilder response = new StringBuilder();

                int bytes = stream.Read(data, 0, data.Length);
                response.Append(Encoding.ASCII.GetString(data, 0, bytes));
                Console.WriteLine("Response from server: " + response);


                client.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}
