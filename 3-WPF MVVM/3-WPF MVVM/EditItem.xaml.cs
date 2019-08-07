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
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {

        public String editTitle { get; set; } // variable for getting values from the Main Window Class
        public String editPrice { get; set; } // variable for getting values from the Main Window Class
        public int editType { get; set; } // variable for getting values from the Main Window Class
        public String editYear { get; set; } // variable for getting values from the Main Window Class
        public int entryID { get; set; } // variable for getting values from the Main Window Class
        public int editMonth { get; set; } // variable for getting values from the Main Window Class

        private string connection_string = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Environment.CurrentDirectory.ToString() + "\\datas\\datas.mdb"; // Connection string for access database
        private OleDbCommand com; // For creating commands
        private OleDbConnection con; // For database connection
        private OleDbDataReader dr; // For reading rows from table
        public MainWindow mw; // For accessing the current main window from this class

        public EditItem()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            entryCombo.SelectedIndex = editType; // filling form
            entryTitle.Text = editTitle; // filling form
            entryPrice.Text = editPrice; // filling form
            monthCombo.SelectedIndex = editMonth; // filling form
            entryYear.Text = editYear; // filling form
        } 

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            // checking missing parameters
            if (entryTitle.Text != "" && validNum(entryYear.Text.ToString()) == true && validNum(entryYear.Text.ToString()) == true)
            {
                String add_query = ""; // determine add query
                if (entryCombo.SelectedIndex == 0)
                {
                    // if earnings is selected
                    add_query = "UPDATE earnings SET earning_title=@Title, earning_price=@Price, earning_year=@Year, earning_month=@Month WHERE earning_id=" + entryID; //adding query for earnings
                }
                else if (entryCombo.SelectedIndex == 1)
                {
                    // if spendings is selected
                    add_query = "UPDATE spendings SET spending_title=@Title, spending_price=@Price, spending_year=@Year, spending_month=@Month WHERE spending_id=" + entryID;  //adding query for spendings
                }
                con = new OleDbConnection(connection_string); // determine the connection
                com = new OleDbCommand(); // determine the command
                con.Open(); // opening connection
                com.Connection = con; // setting Command's connection to con(Oledbconnection)
                com.CommandText = add_query; // setting command text
                com.Parameters.AddWithValue("@Title", entryTitle.Text.ToString()); // adding parameters
                com.Parameters.AddWithValue("@Price", entryPrice.Text.ToString()); // adding parameters
                com.Parameters.AddWithValue("@Year", entryYear.Text.ToString()); // adding parameters
                com.Parameters.AddWithValue("@Month", monthCombo.Text.ToString()); // adding parameters
                Object r = com.ExecuteNonQuery(); // sending command to database. 
                // and it returns with value, if the returned value is bigger than 0 or not null, command executed successfully
                if (r != null) MessageBox.Show("Item is updated successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information); // if command executed successfully, displaying message
                con.Close();  // closing database connection
                mw.fillYear(); // refreshing years
                mw.entryListBox.Items.Clear(); // clearing entryListBox
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
            foreach (char i in text)
            {
                // checking each char if it is number, if it is not set result to false
                if (char.IsNumber(i) == false) result = false;
            }
            return result; // returning result
        }

    }
}
