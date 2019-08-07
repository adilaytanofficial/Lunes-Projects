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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;

namespace _3_WPF_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string connection_string = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Environment.CurrentDirectory.ToString() + "\\datas\\datas.mdb"; // Connection string for access database
        private OleDbCommand com; // For creating commands
        private OleDbConnection con; // For database connection
        private OleDbDataReader dr; // For reading rows from table

        private List<Entry> listboxItems; // it is a list that keeps the values coming from database and entry is a class.

        public MainWindow()
        {
            InitializeComponent();
        }

        // 3.3 Insert Button
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            // Add button for adding items
            AddValues form = new AddValues(); // Opening addvalues window
            form.mw = this; // it sets the main window in AddValues class to reach from other side to here.
            form.ShowDialog(); // showing the AddValues Window
        }

        // 3.3 Delete Button
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (entryListBox.SelectedIndex >= 0){
                // If there is selected item in listbox
                String delete_query = ""; // Delete query
                if (entryCombo.SelectedIndex == 0)
                {
                    // if earnings is selected
                    delete_query = "DELETE FROM earnings WHERE earning_id=" + listboxItems[entryListBox.SelectedIndex].EntryId; //delete query for earnings
                }
                else if (entryCombo.SelectedIndex == 1)
                {
                    // if spendings is selected
                    delete_query = "DELETE FROM spendings WHERE spending_id=" + listboxItems[entryListBox.SelectedIndex].EntryId; //delete query for spendings
                }
                con = new OleDbConnection(connection_string); // determine the connection
                com = new OleDbCommand(); // determine the command
                con.Open(); // opening connection
                com.Connection = con; // setting Command's connection to con(Oledbconnection)
                com.CommandText = delete_query; // setting command text
                int result = com.ExecuteNonQuery(); // sending command to database. 
                // and it returns with value, if the returned value is bigger than 0, command executed successfully
                if (result > 0){
                    // if command executed successfully
                    MessageBox.Show("The selected item was removed from database successfully.", "İnformation", MessageBoxButton.OK, MessageBoxImage.Information); // displaying messages
                    entryListBox.Items.RemoveAt(entryListBox.SelectedIndex); // removing item from listbox
                    fillYear(); // refreshing years
                }
                else
                {
                    // if command didn't execute successfully
                    MessageBox.Show("There is an error while deleting the record from database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); // displaying messages
                }
                con.Close(); // closing database connection
            }
            else
            {
                // If there is no selected item in listbox
                MessageBox.Show("You should select an item.", "Error !", MessageBoxButton.OK, MessageBoxImage.Error); // displaying messages
            }

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (entryListBox.SelectedIndex >= 0){
                // If there is selected item in listbox
                EditItem edit_form = new EditItem(); // creating a new EditItem window
                edit_form.editType = entryCombo.SelectedIndex; // setting editType variable to use it in other side
                edit_form.editTitle = listboxItems[entryListBox.SelectedIndex].EntryTitle; // setting editType variable to use it in other side
                edit_form.editPrice = listboxItems[entryListBox.SelectedIndex].EntryPrice; // setting editTitle variable to use it in other side
                edit_form.editYear = listboxItems[entryListBox.SelectedIndex].EntryYear; // setting editYear variable to use it in other side
                edit_form.entryID = listboxItems[entryListBox.SelectedIndex].EntryId; // setting entryID variable to use it in other side
                edit_form.editMonth = monthCombo.SelectedIndex; // setting editMonth variable to use it in other side
                edit_form.mw = this;  // it sets the main window in EditItem class to reach from other side to here.
                edit_form.ShowDialog(); // showing the EditItem Window
            }
            else
            {
                // If there is no selected item in listbox
                MessageBox.Show("You should select an item.", "Error !", MessageBoxButton.OK, MessageBoxImage.Error); // displaying messages
            }
            
        }

        public void updateEntries()
        {
            entryListBox.Items.Clear(); // clearing list box
            listboxItems = new List<Entry>(); // Creating a new list to add values that come from the database
            listboxItems = getEntries(entryCombo.Text.ToString()); // getting values from database
            if (listboxItems.Count > 0)
            {
                // if amount of items are bigger than 0
                for (int i = 0; i < listboxItems.Count; i++)
                {
                    // add each item to listbox
                    entryListBox.Items.Add("Title: " + listboxItems[i].EntryTitle.ToString() + " Price: $" + listboxItems[i].EntryPrice.ToString());
                }
            }
            else
            {
                MessageBox.Show("There is no record ! Please add a record...", "Error", MessageBoxButton.OK, MessageBoxImage.Error); // displaying messages
            }
        }

        private List<Entry> getEntries(String entryType)
        {
            List<Entry> result = new List<Entry>(); // creating an empty list to keep the values that coming from database
            String getQuery = ""; // reading query
            String prefix = ""; // prefix for reading values from columns
            if (entryType == "Earnings"){
                // if entryType is Earnings
                getQuery = "SELECT * from earnings WHERE earning_year='" + entryYear.Text.ToString() + "'" + " AND earning_month='" + monthCombo.Text.ToString() + "'"; // reading query for earnings
                prefix = "earning_"; // prefix for Earnings
            }
            else if (entryType == "Spendings"){
                // if entryType is Spendings
                getQuery = "SELECT * from spendings WHERE spending_year='" + entryYear.Text.ToString() + "'" + " AND spending_month='" + monthCombo.Text.ToString() + "'"; // reading query for spendings
                prefix = "spending_"; // prefix for Spendings
            }
            con = new OleDbConnection(connection_string); // determine the connection
            com = new OleDbCommand(); // determine the command
            con.Open(); // opening connection
            com.Connection = con; // setting Command's connection to con(Oledbconnection)
            com.CommandText = getQuery; // setting command text
            dr = com.ExecuteReader(); // setting datareader to read values from rows
            while (dr.Read())
            {
                // in each row, getting values from columns
                Entry empty_entry = new Entry(); // creating empty Entry object for adding it to list
                empty_entry.EntryId = int.Parse(dr[prefix + "id"].ToString()); // setting EntryId values
                empty_entry.EntryTitle = dr[prefix + "title"].ToString(); // setting EntryTitle values
                empty_entry.EntryPrice = dr[prefix + "price"].ToString(); // setting EntryPrice values
                empty_entry.EntryYear = dr[prefix + "year"].ToString(); // setting EntryYear values
                empty_entry.EntryMonth = dr[prefix + "month"].ToString(); // setting EntryMonth values
                result.Add(empty_entry); // Adding Entry item to list
            }
            con.Close(); // closing database connection
            return result; // returning the list
        }

        private void showthelist_Click(object sender, RoutedEventArgs e)
        {
            updateEntries(); // void for updating entries
        }

        private void entryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            entryListBox.Items.Clear(); // clear listbox
            fillYear(); // refreshing years
        }

        public void fillYear()
        {
            entryYear.Items.Clear(); //clearing year combobox
            String getQuery = ""; // reading query
            String prefix = ""; // prefix for reading values from columns
            if (entryCombo.SelectedIndex == 0){
                // if entryType is Earnings
                getQuery = "SELECT * from earnings"; // reading query for earnings
                prefix = "earning_"; // prefix for Earnings
            }
            else if (entryCombo.SelectedIndex == 1){
                // if entryType is Spendings
                getQuery = "SELECT * from spendings"; // reading query for spendings
                prefix = "spending_"; // prefix for Spendings
            }
            con = new OleDbConnection(connection_string); // determine the connection
            com = new OleDbCommand(); // determine the command
            con.Open(); // opening connection
            com.Connection = con; // setting Command's connection to con(Oledbconnection)
            com.CommandText = getQuery;  // setting command text
            dr = com.ExecuteReader(); // setting datareader to read values from rows
            while (dr.Read())
            {
                // in each row, getting values from columns
                String year = dr[prefix + "year"].ToString(); // getting year values
                if(!entryYear.Items.Contains(year)){
                    // if the selected year is not in the entryYear items, add it to entryYear items.
                    entryYear.Items.Add(year);
                }
            }
            con.Close(); // closing database connection
            if (entryYear.Items.Count > 0) entryYear.SelectedIndex = 0; // if count of items bigger than 0, select the first one
        }

       
      
    }
}
