using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using OOPGMIniProject;

namespace OOPG_MiniProject
{
    public partial class loginPage : Form
    {
        Database custdBObj = new Database();
        Shop shopObj;
        SqlDataReader dR;
        string Password;
        public loginPage()
        {
            InitializeComponent();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {

            string selectStr = "Select Password From CustomerTBL where Name = " + "'" + nameTextBox.Text + "'";
            dR = custdBObj.ExecuteReader(selectStr);


            if (dR.Read())
            {
                Password = dR["Password"].ToString();

                if (Password == pswTextBox.Text)
                {
                    Name = nameTextBox.Text;

                    MessageBox.Show("Welcome " + Name);

                    Shop frm = new Shop(nameTextBox.Text);
                    frm.ShowDialog();


                    shopObj = new Shop();
                    shopObj.Show();
                    this.Hide();

                }
                else if (pswTextBox.Text == "")
                {
                    MessageBox.Show("Wrong Password");

                }

            }
            else
            {
                MessageBox.Show("Please register first");
            }

            dR.Close();

        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            signUp frm = new signUp();
            frm.ShowDialog();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }   
}
