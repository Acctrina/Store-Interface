using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using OOPG_MiniProject;

namespace OOPGMIniProject
{
    public partial class signUp : Form
    {
        Form loginPage;//Login page
        SqlDataReader dR;
        Database custDbObj = new Database();
        string Membership;
        public signUp()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
       

              if(string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text) || string.IsNullOrWhiteSpace(confirmTextBox.Text) || string.IsNullOrWhiteSpace(addressTextBox.Text))
                {
                    MessageBox.Show("Please fill up all the blanks!");
                }
                  else
                  {
                        string selectStr = "Select Name From CustomerTbl where Name = " + "'" + nameTextBox.Text + "'";
                        dR = custDbObj.ExecuteReader(selectStr);

                        if (dR.Read())
                        {
                           dR.Close();
                           MessageBox.Show("Name has been used! Please pick another.");                         
                        }
                        else
                        {
                           dR.Close();

                           if(passwordTextBox.Text == confirmTextBox.Text)
                           {
                                if (memberRadioButton.Checked)
                                {
                                    Membership = "Yes";
                                }
                                else
                                {
                                    Membership = "No";
                                }


                           }
                           else
                           {
                            MessageBox.Show("Please double check your password");
                            return;
                           }
                           

                         string strInsert = "Insert into CustomerTBL(Name, Password, Address, Membership)" + " Values('" + nameTextBox.Text + "', '" + passwordTextBox.Text + "', '" + addressTextBox.Text + "', '" + Membership + "')";
                         Database dB = new Database();
                         int row = dB.ExecuteNonQuery(strInsert);
                         MessageBox.Show("Account created!");
                        }
                        
                        
                  }
                }

        private void backButton_Click(object sender, EventArgs e)
        {
            loginPage = new loginPage();
            loginPage.Show();
            this.Hide();
        }
    
    }
}

