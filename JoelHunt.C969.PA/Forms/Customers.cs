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
            this.customerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private List<CustomerListModel> customers;

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            CreateCustomer create = new CreateCustomer(this.repo, this.activeUser);
            create.Show();
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.customerDataGrid.SelectedRows[0];
            int customerId = Convert.ToInt32(row.Cells["Id"].Value);

            EditCustomer editCustomerForm = new EditCustomer(this.repo, this.activeUser, customerId);
            editCustomerForm.Show();
        }
    }
}
