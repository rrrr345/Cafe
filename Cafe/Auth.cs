using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cafe
{
    public partial class Auth : Form
    {

        string connStr = "server=stud-mysql.sdlik.ru; port=33445; user=st_333_22; database=is_333_22_KR; password=37380198";

        MySqlConnection conn;
        public Auth()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            conn.Open();
            string sql = "SELECT COUNT(ID) FROM Authorization WHERE Login = @login AND Password = @password AND active = 1";
            MySqlCommand mySqlCommand = new MySqlCommand(sql,conn);
            mySqlCommand.Parameters.AddWithValue("@login", login);
            mySqlCommand.Parameters.AddWithValue("@password", password);
            int count = Convert.ToInt32(mySqlCommand.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Авторизация прошла успешно");
                this.Close();
            }

            else {
                MessageBox.Show("Неверные данные");
            }
          
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
