using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;


namespace _3_WPF_MVVM
{
    /// <summary>
    /// Interaction logic for AddValues.xaml
    /// </summary>
    public partial class AddValues : Window
    {
        public AddValues()
        {
            InitializeComponent();
        }

        private string connection_string = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Environment.CurrentDirectory.ToString() + "\\datas\\datas.mdb"; // Connection string for access database
        private OleDbCommand com; // For creating commands
        private OleDbConnection con; // For database connection
        private OleDbDataReader dr; // For reading rows from table
        public MainWindow mw; // For accessing the current main window from this class


        private void addtodatabase_Click(object sender, RoutedEventArgs e)
        {
            // checking missing parameters
            if (entryTitle.Text != "" && validNum(entryYear.Text.ToString()) == true && validNum(entryYear.Text.ToString()) == true){
                String add_query = ""; // determine add query
                if (entryCombo.SelectedIndex == 0)
                {
                    // if earnings is selected
                    add_query = "INSERT INTO earnings (earning_title,earning_price,earning_year,earning_month) VALUES ('" + entryTitle.Text.ToString() + "','" + entryPrice.Text.ToString() + "','" + entryYear.Text.ToString() + "','" + monthCombo.Text.ToString() + "');"; //adding query for earnings
                }
                else if (entryCombo.SelectedIndex == 1)
                {
                    // if spendings is selected
                    add_query = "INSERT INTO spendings (spending_title,spending_price,spending_year,spending_month) VALUES ('" + entryTitle.Text.ToString() + "','" + entryPrice.Text.ToString() + "','" + entryYear.Text.ToString() + "','" + monthCombo.Text.ToString() + "');"; //adding query for spendings
                }
                con = new OleDbConnection(connection_string);  // determine the connection
                com = new OleDbCommand(); // determine the command
                con.Open(); // opening connection
                com.Connection = con; // setting Command's connection to con(Oledbconnection)
                com.CommandText = add_query; // setting command text
                Object r = com.ExecuteNonQuery(); // sending command to database. 
                // and it returns with value, if the returned value is bigger than 0 or not null, command executed successfully
                if (r != null) MessageBox.Show("Datas are saved to database successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);  // if command executed successfully, displaying message
                con.Close(); // closing database connection
                mw.fillYear(); // refreshing years
                this.Close(); // closing current window
            }
            else
            {
                MessageBox.Show("Some parameters are missing or invalid !", "Error", MessageBoxButton.OK, MessageBoxImage.Error); // displaying messages
            }
            
        }

        // function for checking that the text is number or not
        private bool validNum(String text)
        {
            bool result = true; // setting result variable to true
            foreach(char i in text){
                // checking each char if it is number, if it is not set result to false
                if (char.IsNumber(i) == false) result = false;
            }
            return result; // returning result
        }
        
    }
}
