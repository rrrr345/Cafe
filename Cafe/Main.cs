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
    public partial class Main : Form
    {


        string connStr = "server=stud-mysql.sdlik.ru; port=33445; user=st_333_22; database=is_333_22_KR; password=37380198";

        MySqlConnection conn;
       MySqlCommand cmd;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
           this.Hide();
           Auth auth = new Auth();
           auth.ShowDialog();

            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT Name, Login FROM Authorization";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            { 
                string name = reader[0].ToString();
                string login = reader[1].ToString();
                listBox1.Items.Add(name+" "+login);
            }

            reader.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            int insertCount = 0;

            string name = textBox1.Text;
            string login = textBox2.Text;
            string password = textBox3.Text;
            string phone = textBox4.Text;
            string sql = "INSERT INTO  Authorization (Name, Login, Password, Phone) VALUES ('KIRA', '123', '123', '9845598724')";



            try
            {
                MySqlCommand command = new MySqlCommand(sql, conn);
                insertCount = command.ExecuteNonQuery();
            }

            catch
            {
                MessageBox.Show("Операция добавления пользователя закончилась ошибкой");

            }

            finally
            { 
                conn.Close();
            }

            
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sprav.Employe employe = new sprav.Employe();
            employe.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
