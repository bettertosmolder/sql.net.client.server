using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastChanceClient_backup
{
    public partial class Form2 : Form
    {

        private TcpClient client;
        private NetworkStream stream;
        private const string serverIpAddress = "127.0.0.1"; // Replace with your server's IP address
        private const int serverPort = 8888;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            client = new TcpClient();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Not connected to the server.");
                    return;
                }

                string query = "SELECT * FROM PRODUCTS"+ '\n';
                byte[] queryBytes = Encoding.UTF8.GetBytes(query);

                await stream.WriteAsync(queryBytes, 0, queryBytes.Length);

                // Read the response from the server
                byte[] responseBuffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                // Update the UI with the received data
                UpdateDataGridView(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await client.ConnectAsync(serverIpAddress, serverPort);
            stream = client.GetStream();
            MessageBox.Show("Connected to the server");
        }

        private void UpdateDataGridView(string responseData)
        {
            try
            {
                // Deserialize the received JSON string
                var dataDictionary = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, object>>>(responseData);

                // Create a DataTable and add columns based on the keys in the dictionary
                DataTable dataTable = new DataTable();
                if (dataDictionary.Count > 0)
                {
                    foreach (var key in dataDictionary.First().Keys)
                    {
                        dataTable.Columns.Add(key, typeof(object));
                    }

                    // Populate the DataTable with data from the dictionary
                    foreach (var dataRow in dataDictionary)
                    {
                        DataRow newRow = dataTable.NewRow();
                        foreach (var key in dataRow.Keys)
                        {
                            newRow[key] = dataRow[key];
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating DataGridView: {ex.Message}");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Not connected to the server.");
                    return;
                }

                string query = "SELECT * FROM CATEGORIES" + '\n';
                byte[] queryBytes = Encoding.UTF8.GetBytes(query);

                await stream.WriteAsync(queryBytes, 0, queryBytes.Length);

                // Read the response from the server
                byte[] responseBuffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                // Update the UI with the received data
                UpdateDataGridView(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Not connected to the server.");
                    return;
                }

                string query = "SELECT * FROM STORES" + '\n';
                byte[] queryBytes = Encoding.UTF8.GetBytes(query);

                await stream.WriteAsync(queryBytes, 0, queryBytes.Length);

                // Read the response from the server
                byte[] responseBuffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                // Update the UI with the received data
                UpdateDataGridView(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Not connected to the server.");
                    return;
                }

                string query = "SELECT * FROM MANUFACTURERS" + '\n';
                byte[] queryBytes = Encoding.UTF8.GetBytes(query);

                await stream.WriteAsync(queryBytes, 0, queryBytes.Length);

                // Read the response from the server
                byte[] responseBuffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                // Update the UI with the received data
                UpdateDataGridView(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Not connected to the server.");
                    return;
                }

                string query = "SELECT * FROM PRODUCTS" + '\n';
                byte[] queryBytes = Encoding.UTF8.GetBytes(query);

                await stream.WriteAsync(queryBytes, 0, queryBytes.Length);

                // Read the response from the server
                byte[] responseBuffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                // Update the UI with the received data
                UpdateDataGridView(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
