using System;
using System.Windows.Forms;

namespace Gestion_des_stock
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }
    }
}
