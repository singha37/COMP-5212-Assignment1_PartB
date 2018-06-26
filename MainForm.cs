using System;
using System.Collections.Generic;      
using System.Windows.Forms;

namespace Assignment1_PartB
{
    public partial class MainForm : Form
    {
        List<Customer> customerDB;

        string selectedCustomer = "";
        string[] customerArray;

        int index = -1;

        public MainForm()
        {
            InitializeComponent();
            customerDB = new List<Customer>();  
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadDB();
            displayCustomers();
        }

        public void loadDB()
        {
            customerDB.Add(new Customer("Jaarna", "Kereopa", "123-2514"));
            customerDB.Add(new Customer("Sure", "Stook", "123-1263"));
            customerDB.Add(new Customer("Jamie", "Allom", "123-3658"));
            customerDB.Add(new Customer("Brain", "Janes", "123-9898"));
        }

        public void clearBoxes()
        {
            firstNameTB.Text = null;
            lastNameTB.Text = null;
            phoneTB.Text = null; 
        }

        public void clearDisplay()
        {
            customerListBox.Items.Clear();
        }

        public void displayCustomers()
        {
            foreach(var customer in customerDB)
            {
                customerListBox.Items.Add(customer.getCustomer());
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchText = searchTB.Text;

            if (searchText.Equals(""))
            {
                MessageBox.Show("You must enter a customer name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchTB.Focus();
            }
            else
            {
                searchTB.Text = null;
                clearDisplay();   

                for (int i = 0; i < customerDB.Count; i++)  
                {
                    if(customerDB[i].firstName.Equals(searchText))
                    {
                        index = i;
                        break;
                    }
                }

                if(index != -1)
                {
                    customerListBox.Items.Add(customerDB[index].getCustomer());
                }
                else
                {
                    MessageBox.Show("Customer not found, please try again.", "Search Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    searchTB.Focus();
                }
            }

        }

        private void customerListButton_Click(object sender, EventArgs e)
        {
            clearDisplay();
            displayCustomers();
        }

        private void clearListButton_Click(object sender, EventArgs e)
        {
            clearDisplay();
            searchTB.Focus();
            addButton.Enabled = true;
        }

        private void customerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomer = customerListBox.Items[customerListBox.SelectedIndex].ToString();
            addButton.Enabled = false;

            customerArray = selectedCustomer.Split('\t');
            firstNameTB.Text = customerArray[0];
            lastNameTB.Text = customerArray[1];
            phoneTB.Text = customerArray[2];

            for (int i = 0; i < customerDB.Count; i++)
            {
                if (customerDB[i].firstName.Equals(firstNameTB.Text) && customerDB[i].lastName.Equals(lastNameTB.Text) && customerDB[i].phone.Equals(phoneTB.Text))
                {
                    index = i;
                    break;
                }
            }       
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if(selectedCustomer.Equals("") || selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(firstNameTB.Text == "" || lastNameTB.Text == "" || phoneTB.Text == "")
                {
                    MessageBox.Show("All textboxes must be filled to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    customerDB[index].firstName = firstNameTB.Text;
                    customerDB[index].lastName = lastNameTB.Text;
                    customerDB[index].phone = phoneTB.Text;


                    selectedCustomer = "";
                    clearBoxes();     
                    clearDisplay();
                    displayCustomers();
                    addButton.Enabled = true;
                    MessageBox.Show("Customer details updated.", "Customer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (firstNameTB.Text == "" || lastNameTB.Text == "" || phoneTB.Text == "")
            {
                MessageBox.Show("All textboxes must be filled to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {         
                customerDB.Add(new Customer(firstNameTB.Text, lastNameTB.Text, phoneTB.Text));

                clearBoxes();
                clearDisplay();
                displayCustomers();
                MessageBox.Show("New customer has been added.", "Customer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearBoxes();
            addButton.Enabled = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedCustomer.Equals("") || selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {        
                DialogResult resultDialog = MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo);
                if (resultDialog == DialogResult.Yes)
                {
                    customerDB.RemoveAt(index);
                    MessageBox.Show("Customer has been deleted.", "Customer Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                else if (resultDialog == DialogResult.No)
                {     
                    MessageBox.Show("Operation Cancelled", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                selectedCustomer = "";
                clearDisplay();
                displayCustomers();
            }
            addButton.Enabled = true;
        }
    }
}
