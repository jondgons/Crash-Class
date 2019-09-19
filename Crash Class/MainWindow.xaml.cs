using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crash_Class
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employees.accdb");
        }

        private void SeeAssets_Click(object sender, RoutedEventArgs e)
        {
            // querying Assets
            string query = "select* from Assets"; // query string

            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open(); // connect to the database

            OleDbDataReader read = cmd.ExecuteReader(); // reads result

            string data = ""; // holder string

            while (read.Read()) // loops over database call
            {
                data += read[0].ToString() + ": " + read[2].ToString() + ", " + read[1].ToString() + "\n";
            }

            DisplayArea.Text = data; // displays data

            read.Close();
            cn.Close();
        }

        private void SeeEmployees_Click(object sender, RoutedEventArgs e)
        {
            // querying Employees
            string query = "select* from Employees"; // query string

            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open(); // connect to the database

            OleDbDataReader read = cmd.ExecuteReader(); // reads result

            string data = ""; // holder string

            while (read.Read()) // loops over database call
            {
                data += read[0].ToString() + ": " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }

            DisplayArea.Text = data; // displays data

            read.Close();
            cn.Close();
        }
    }
}
