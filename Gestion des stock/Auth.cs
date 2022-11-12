using System;
using System.Windows.Forms;

namespace Gestion_des_stock
{
    public partial class Auth : Form
    {
        public Auth()
        {
           
                InitializeComponent();
   

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            if (Gestion_des_utilisateur.Datauser.Login(bunifuTextBox1.Text, bunifuTextBox2.Text))
            {


                if (Connexion.type == "Admin")
                {
                    Form1 form = new Form1();
                    form.Show();
                }
                if (Connexion.type == "Employee")
                {
                    Employee employees = new Employee();
                    employees.Show();
                }
                this.Hide();



            }
            else
            {
                MessageBox.Show("Utilisateur n'existe pas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }
    }
}
