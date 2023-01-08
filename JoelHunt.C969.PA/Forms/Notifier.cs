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
    public partial class Notifier : Form
    {
        public Notifier(string notificationText)
        {
            InitializeComponent();
            this.notificationMessage.Text = notificationText;
            this.AutoSize = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Notifier_Load(object sender, EventArgs e)
        {

        }
    }
}
