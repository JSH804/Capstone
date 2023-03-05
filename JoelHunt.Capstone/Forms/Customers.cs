using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JoelHunt.Capstone.Forms.ViewModels;
using JoelHunt.Capstone.Models;
using JoelHunt.Capstone.Repositories;
using JoelHunt.Capstone.Services;

namespace JoelHunt.Capstone.Forms
{
    public partial class Customers : Form
    {
        private readonly RepoControl repo;
        private readonly ICustomerService customerService;
        private readonly Tutor activeTutor;

        public Customers(RepoControl repo, Tutor activeTutor)
        {
            this.repo = repo;
            this.customerService = repo.Customers;
            this.activeTutor = activeTutor;
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
            this.customerDataGrid.Columns[0].Visible = false;
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
            CreateCustomer create = new CreateCustomer(this.repo, this.activeTutor);
            create.Show();
            create.FormClosed += RefreshAfterUpdate;
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.customerDataGrid.SelectedRows[0];
            int customerId = Convert.ToInt32(row.Cells["customerId"].Value);

            EditCustomer editCustomerForm = new EditCustomer(this.repo, this.activeTutor, customerId);
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
