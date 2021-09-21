using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace connectingDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlDataReader dataReader;
        SqlCommand command;
        string sql,output="";
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
             connection = new SqlConnection(@"Data Source=RCPSCR9PC026\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True");
            connection.Open();

            sql = "Select * from STUDENTS ";

            command = new SqlCommand(sql, connection);

            dataReader = command.ExecuteReader();

            //while (dataReader.Read())
            //{
            //    output = output + dataReader.GetValue(0) + "\t" + dataReader.GetValue(2) + "\n";

            //}
            //  dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            datagridDisplay.DataContext = dataTable;

           // MessageBox.Show(output);

            output = "";
            dataReader.Close();
            command.Dispose();
            connection.Close();

        }
    }
}
