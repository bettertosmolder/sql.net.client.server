using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LastChanceClient_backup;
using System.Windows.Forms;
using System;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Text.Json;
using Newtonsoft.Json;
using LastChanceClient;


namespace LastChanceClient_backup
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string[,] users = { { "root", "root" }, { "user", "user" }, {"admin","admin" } };

            try
            {
                string login = textBox1.Text; string password = textBox2.Text;
                // Проверяем введенный логин и пароль
                bool isUserExists = false; for (int i = 0; i < users.GetLength(0); i++)
                {
                    if (users[i, 0] == login && users[i, 1] == password)
                    {
                        isUserExists = true;

                    }
                    else if (login == "admin")
                    {
                        Hide();
                        Form1 form1 = new Form1();
                        form1.Show();
                    }
                    else if(login == "user")
                    {
                        Hide();
                        Form2 form2 = new Form2();
                        form2.Show();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
