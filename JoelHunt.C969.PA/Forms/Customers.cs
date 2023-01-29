using JoelHunt.C969.PA.Forms.ViewModels;
using JoelHunt.C969.PA.Models;
using JoelHunt.C969.PA.Repositories;
using JoelHunt.C969.PA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoelHunt.C969.PA.Forms
{
    public partial class Customers : Form
    {
        private readonly RepoControl repo;
        private readonly ICustomerService customerService;
        private readonly User activeUser;

        public Customers(RepoControl repo, User activeUser)
        {
            this.repo = repo;
            this.customerService = repo.Customers;
            this.activeUser = activeUser;
            GetListOfCustomers();

            InitializeComponent();

            PopulateCustomerGrid();
        }

        private void GetListOfCustomers()
        {
            this.customers = this.customerService.GetCustomerList();
        }

        private void PopulateCustomerGrid()
        {
            this.customerDataGrid.DataSource = this.customers;
            this.customerDataGrid.MultiSelect = false;
            this.customerDataGrid.ReadOnly = true;
            this.customerDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.customerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void RefreshDataGrid()
        {
            this.customerDataGrid.DataSource = typeof(CustomerListModel);
            GetListOfCustomers();
            this.customerDataGrid.DataSource = this.customers;
        }

        private void RefreshAfterUpdate(object sender, EventArgs args)
        {
            RefreshDataGrid();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            CreateCustomer create = new CreateCustomer(this.repo, this.activeUser);
            create.Show();
            create.FormClosed += RefreshAfterUpdate;
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.customerDataGrid.SelectedRows[0];
            int customerId = Convert.ToInt32(row.Cells["customerId"].Value);

            EditCustomer editCustomerForm = new EditCustomer(this.repo, this.activeUser, customerId);
            editCustomerForm.Show();
            editCustomerForm.FormClosed += RefreshAfterUpdate;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.customerDataGrid.SelectedRows[0];
            int customerId = Convert.ToInt32(row.Cells["customerId"].Value);

            bool deleteSuccessful = this.customerService.DeleteAllCustomersRecords(customerId);

            if (deleteSuccessful)
            {
                MessageBox.Show("Customer deleted successfully");
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Error deleting the customer.");
            }
        }

        private List<CustomerListModel> customers;
    }
}
