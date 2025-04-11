using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;

namespace Cafe
{
   
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connStr = "server=stud-mysql.sdlik.ru; port=33445; user=st_333_22; database=is_333_22_KR; password=37380198";
            DatabaseConnection.Initialize(connStr);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
