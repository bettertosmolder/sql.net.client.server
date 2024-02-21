using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace serverserverbase
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //await Database.GetInstance().MakeTestTable();
            await Server.Connect();
        }
    }


    public class Database
    {
        private static Database Instance;
        public static Database GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Database();
            }
            return Instance;
        }
        private static string ConnectionString { get; set; }
        private static string Command { get; set; }
        private static SqlConnection Connection { get; set; }
        public Database()
        {

            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Ivan Ott\\Desktop\\uchebka\\Serv\\LastChanceServer\\WebMarket.mdf\";Integrated Security=True;Connect Timeout=30";
            Connection = new SqlConnection(ConnectionString);
        }
       
        private static async Task Open()
        {
            try
            {
                await Connection.OpenAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static async Task Close()
        {
            await Connection.CloseAsync();
        }
        private static async Task Do(string command)
        {
            Connection.Open();
            Command = command;
            var nc = new SqlCommand(Command, Connection);
            try
            {
                await nc.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Connection.Close();
        }
        public async Task MakeTestTable()
        {
            await Open();
            //await Do("create table dogs(id int primary key, color varchar(50), age int, poroda varchar(40));");
            //await Do("insert into dogs values(1, 'yellow', 2, 'ovcharka');");
            await Do("insert into dogs values(2, 'brown', 3, 'terrier');");
            await Do("insert into dogs values(3, 'black', 1, 'buldog');");
            await Do("insert into dogs values(4, 'white', 1, 'husky');");
            await Do("insert into dogs values(5, 'red', 4, 'corgi');");
            await Close();
        }
        public async Task Insert(string query)
        {
            await Open();
            try { await Do(query); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            await Close();
        }
        public DataTable MakeTable(string command)
        {
            if(Connection.State == ConnectionState.Closed) 
            { 
                Connection.Open(); 
            }
           
            DataTable table = new DataTable();
            Command = command;
            try
            {
                var nc = new SqlCommand(Command, Connection);
                SqlDataAdapter adapter = new SqlDataAdapter(nc);
                adapter.SelectCommand = nc;
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
                Command = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return table;
            
        }
        
    }

    public class MyIp
    {
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }

    class Server
    {
        public static async Task Connect()
        {
            //Определите получение переменных длины данных
            Socket tcpListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                tcpListener.Bind(new IPEndPoint(IPAddress.Any, 8888));
                tcpListener.Listen(10);    // запускаем сервер
                Console.WriteLine("Сервер запущен. Ожидание подключений... ");

                while (true)
                {
                    // получаем подключение в виде TcpClient
                    var tcpClient = await tcpListener.AcceptAsync();
                    Console.WriteLine($"Connected !");
                    Console.WriteLine(tcpClient.RemoteEndPoint.ToString());
                    // создаем новую задачу для обслуживания нового клиента
                    await Task.Run(async () => await ProcessClientAsync(tcpClient));

                    // вместо задач можно использовать стандартный Thread
                    // new Thread(async ()=> await ProcessClientAsync(tcpClient)).Start();
                }
            }
            //data = TableManagement.SerializeTable(Database.GetInstance().MakeTable(Console.ReadLine()));
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static async Task ProcessClientAsync(Socket tcpClient)
        {

            //byte[] data = TableManagement.SerializeTable(Database.GetInstance().MakeTable(Console.ReadLine()));
            List<byte> data = new List<byte>();
            // буфер для накопления входящих данных
            List<byte> response = new List<byte>();
            // буфер для считывания одного байта
            var bytesRead = new byte[1];
            int i = 0;

            while (true)
            {
                i++;
                // считываем данные до конечного символа
                while (true)
                {
                    var count = await tcpClient.ReceiveAsync(new ArraySegment<byte>(bytesRead), SocketFlags.None);
                    // смотрим, если считанный байт представляет конечный символ, выходим
                    if (count == 0 || bytesRead[0] == '\n')
                    {
                        count = 0;
                        break;
                    }
                    // иначе добавляем в буфер
                    response.Add(bytesRead[0]);
                }
                var query = Encoding.UTF8.GetString(response.ToArray());
                // если прислан маркер окончания взаимодействия,
                // выходим из цикла и завершаем взаимодействие с клиентом
                if (query == "END") break;

                Console.WriteLine(query);

                // отправляем
                if (!query.Contains("insert")) await tcpClient.SendAsync(new ArraySegment<byte>(TableManagement.SerializeTable(Database.GetInstance().MakeTable(query))), SocketFlags.None);
                else await Database.GetInstance().Insert(query);
                //await tcpClient.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(Console.ReadLine() + '\n')), SocketFlags.None);
                query = "";
                response = new List<byte>();
                bytesRead = new byte[1];
            }
            tcpClient.Shutdown(SocketShutdown.Both);
            tcpClient.Close();
        }
    }
    public class TableManagement
    {
        public static byte[] SerializeTable(DataTable data)
        {

            if (data == null)
            {
                Console.WriteLine("NULL");
                return null;
            }
            Console.WriteLine("sent!");
            var datadic = data.Rows.OfType<DataRow>()
                        .Select(row => data.Columns.OfType<DataColumn>()
                            .ToDictionary(col => col.ColumnName, c => row[c]));
            return Encoding.ASCII.GetBytes(System.Text.Json.JsonSerializer.Serialize(datadic));
        }
    }

}
