using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;




namespace StudentManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordtextBox.Text;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-URDRC1S\\SQLEXPRESS;Initial Catalog=StudentDB; Integrated Security=true");
            connection.Open();

            SqlCommand selectCommand = new SqlCommand(" select * from tbl_registration where username = '" + username + "' and password ='" + password + "'", connection);


            SqlDataReader dataFromDb = selectCommand.ExecuteReader();
            if (dataFromDb.HasRows)
            {


                this.Hide();
                Feature featureFrom = new Feature();
                featureFrom.Show();

            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
          
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(RegistrationGroupBox.Visible== true )
            RegistrationGroupBox.Visible = false;
            else
                RegistrationGroupBox.Visible = true;

            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {

            string name = UsertextBox.Text;
            string email = GmailtextBox.Text;
            string password = PasstextBox.Text;
            string confirmpassword = ConfirmpasstextBox.Text;

            Console.WriteLine(name + email + password + confirmpassword);




            //----------emailVerification
            if (!email.Contains("@") && !email.Contains(".com"))
            {

                GmailLable.ForeColor = Color.Red;
                MessageBox.Show("Please Use @ and .com in your email address");
            }
            else
            {
                GmailLable.ForeColor = Color.Blue;
            }
            //----------UserNameVerification
            if (!System.Text.RegularExpressions.Regex.IsMatch(UsertextBox.Text, "[A-Z]"))
            {
                UsernameLable.ForeColor = Color.Red;
                MessageBox.Show("Please Use Both UpperCase and LowerCase");


            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(UsertextBox.Text, "[a-z]"))
            {
                UsernameLable.ForeColor = Color.Red;
                MessageBox.Show("Please Use Both UpperCase and LowerCase");

            }
            else
            {
                UsernameLable.ForeColor = Color.Blue;
            }
            //----------PasswordVerification
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"[^a-zA-Z0-9]") && password != confirmpassword)
            {
                MessageBox.Show("Please Use  numbers,letters and special character and same password at both term ");
                PasswordLable.ForeColor = Color.Red;
                ConfirmPasswordLable.ForeColor = Color.Red;


            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"[^a-zA-Z0-9]") && password == confirmpassword)
            {
                MessageBox.Show("Please Use  numbers,letters and special character and same password at both term ");
                PasswordLable.ForeColor = Color.Red;
                ConfirmPasswordLable.ForeColor = Color.Red;

            }
            else
            {
                PasswordLable.ForeColor = Color.Blue;
                ConfirmPasswordLable.ForeColor = Color.Blue;
            }
            //----------DatabaseEntryVerification&Connection&ConfirmationMail
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[^a-zA-Z0-9]") && password == confirmpassword && email.Contains("@") && email.Contains(".com") && name != null && System.Text.RegularExpressions.Regex.IsMatch(UsertextBox.Text, "[A-Z]") && System.Text.RegularExpressions.Regex.IsMatch(UsertextBox.Text, "[a-z]"))
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-URDRC1S\\SQLEXPRESS;Initial Catalog=StudentDB; Integrated Security=true");
                connection.Open();

                SqlCommand insertCommand = new SqlCommand(" insert into tbl_registration(username,gmail,password) values ('" + name + "','" + email + "','" + password + "') ", connection);

                insertCommand.ExecuteNonQuery();

                MessageBox.Show("Record Inserted Successfully");

            }

            else
            {
                MessageBox.Show("Follow Proper Instruction");
            }
            
           


        }

        private void UsertextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmpasstextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasstextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsernameLable_Click(object sender, EventArgs e)
        {

        }
    }
}
