using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace StudentManagementSystem
{
    public partial class Feature : Form
    {
       
      
        public Feature()
        {
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            try
            {
                byte[] bImageData = GetImageData();


                SqlConnection dbCon = new SqlConnection("Data Source=DESKTOP-URDRC1S\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=true");

                SqlCommand insertCommand = new SqlCommand("INSERT INTO [dbo].[tbl_student_info] (name,roll,reg,faculty,img) VALUES (@StudentName,@StudentRoll,@StudentReg,@StudentFaculty,@StudentImage)", dbCon);

                insertCommand.Parameters.AddWithValue("@StudentName", StudentNametextBox.Text);
                insertCommand.Parameters.AddWithValue("@StudentRoll", StudentRolltextBox.Text);
                insertCommand.Parameters.AddWithValue("@StudentReg", RegtextBox.Text);
                insertCommand.Parameters.AddWithValue("@StudentFaculty", FacultyComboBox.Text);
                insertCommand.Parameters.AddWithValue("@StudentImage", bImageData);


                if (dbCon.State == ConnectionState.Closed)
                    dbCon.Open();
                insertCommand.ExecuteNonQuery();
                MessageBox.Show("Record Inserted Successfully");



            }
            catch (Exception)
            { }



        }


        public byte[] GetImageData()
        {




            Image img = Image.FromFile(ImageTextBox.Text);

            ImageConverter ic = new ImageConverter();

            return (byte[])ic.ConvertTo(img, typeof(byte[]));

        }



    


        private void StudentRolltextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentRolltextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void StudentNametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                ImageTextBox.Text = ofd.FileName;


                StudentPictureBox.Image = Image.FromFile(@ofd.FileName);
            }

        }



        private void ImageLabel_Click(object sender, EventArgs e)
        {

        }

        private void ViewButton_Click(object sender, EventArgs e)
        {




            SqlConnection connection = new SqlConnection("Data Source = DESKTOP-URDRC1S\\SQLEXPRESS;Initial Catalog = StudentDB; Integrated Security=true");

            //ViewDataGridView.Update();
  //ViewDataGridView.Update();

            ViewDataGridView.Rows.Clear();
            connection.Open();

            SqlCommand selectCommand = new SqlCommand("select * from tbl_student_info", connection);


            SqlDataReader dataFromDb = selectCommand.ExecuteReader();


            while (dataFromDb.Read())
            {

                try
                {
                    var index = ViewDataGridView.Rows.Add();


                    ViewDataGridView.Rows[index].Cells[0].Value = dataFromDb["name"].ToString();
                    ViewDataGridView.Rows[index].Cells[1].Value = dataFromDb["roll"].ToString();
                    ViewDataGridView.Rows[index].Cells[2].Value = dataFromDb["reg"].ToString();
                    ViewDataGridView.Rows[index].Cells[3].Value = dataFromDb["faculty"].ToString();




                    byte[] storedImage = (byte[])dataFromDb["img"];

                    Image newImage;
                    MemoryStream stream = new MemoryStream(storedImage);
                    newImage = Image.FromStream(stream);



                    ViewDataGridView.Rows[index].Cells[4].Value = newImage;


                    ((DataGridViewImageColumn)ViewDataGridView.Columns[4]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                    ViewDataGridView.Rows[index].Height = 100;

                }
                catch (Exception )
                { }
            }


            





















        }

        private void ViewSearchButton_Click(object sender, EventArgs e)
        {
            ViewDataGridView.Rows.Clear();
            string CBox = ViewComboBox.Text;
            if (CBox == "Namewise")
            {
                SqlConnection connection = new SqlConnection("Data Source = DESKTOP-URDRC1S\\SQLEXPRESS;Initial Catalog = StudentDB; Integrated Security=true");

                connection.Open();

                SqlCommand selectCommand = new SqlCommand("select * from tbl_student_info where name like '" + ViewTextBox.Text + "%'", connection);


                //selectCommand.Parameters.Add("@NAME", ViewTextBox.Text);
                SqlDataReader dataFromDb = selectCommand.ExecuteReader();


                while (dataFromDb.Read())
                {

                    try
                    {
                        var index = ViewDataGridView.Rows.Add();


                        ViewDataGridView.Rows[index].Cells[0].Value = dataFromDb["name"].ToString();
                        ViewDataGridView.Rows[index].Cells[1].Value = dataFromDb["roll"].ToString();
                        ViewDataGridView.Rows[index].Cells[2].Value = dataFromDb["reg"].ToString();
                        ViewDataGridView.Rows[index].Cells[3].Value = dataFromDb["faculty"].ToString();




                        byte[] storedImage = (byte[])dataFromDb["img"];

                        Image newImage;
                        MemoryStream stream = new MemoryStream(storedImage);
                        newImage = Image.FromStream(stream);



                        ViewDataGridView.Rows[index].Cells[4].Value = newImage;


                        ((DataGridViewImageColumn)ViewDataGridView.Columns[4]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                        ViewDataGridView.Rows[index].Height = 100;

                    }
                    catch (Exception )
                    { }
                }
            }
            else if (CBox == "Rollwise")
            {
                SqlConnection connection = new SqlConnection("Data Source =  DESKTOP-URDRC1S\\SQLEXPRESS;Initial Catalog = StudentDB; Integrated Security=true");

                connection.Open();

                SqlCommand selectCommand = new SqlCommand("select * from tbl_student_info where roll like '" + ViewTextBox.Text + "%'", connection);


                //selectCommand.Parameters.Add("@NAME", ViewTextBox.Text);
                SqlDataReader dataFromDb = selectCommand.ExecuteReader();


                while (dataFromDb.Read())
                {

                    try
                    {
                        var index = ViewDataGridView.Rows.Add();


                        ViewDataGridView.Rows[index].Cells[0].Value = dataFromDb["name"].ToString();
                        ViewDataGridView.Rows[index].Cells[1].Value = dataFromDb["roll"].ToString();
                        ViewDataGridView.Rows[index].Cells[2].Value = dataFromDb["reg"].ToString();
                        ViewDataGridView.Rows[index].Cells[3].Value = dataFromDb["faculty"].ToString();




                        byte[] storedImage = (byte[])dataFromDb["img"];

                        Image newImage;
                        MemoryStream stream = new MemoryStream(storedImage);
                        newImage = Image.FromStream(stream);



                        ViewDataGridView.Rows[index].Cells[4].Value = newImage;


                        ((DataGridViewImageColumn)ViewDataGridView.Columns[4]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                        ViewDataGridView.Rows[index].Height = 100;

                    }
                    catch (Exception )
                    { }
                }
            }
            else if (CBox == "Registrationwise")
            {
                SqlConnection connection = new SqlConnection("Data Source =  DESKTOP-URDRC1S\\SQLEXPRESS;Initial Catalog = StudentDB; Integrated Security=true");

                connection.Open();

                SqlCommand selectCommand = new SqlCommand("select * from tbl_student_info where reg like '" + ViewTextBox.Text + "%'", connection);


                //selectCommand.Parameters.Add("@NAME", ViewTextBox.Text);
                SqlDataReader dataFromDb = selectCommand.ExecuteReader();


                while (dataFromDb.Read())
                {

                    try
                    {
                        var index = ViewDataGridView.Rows.Add();


                        ViewDataGridView.Rows[index].Cells[0].Value = dataFromDb["name"].ToString();
                        ViewDataGridView.Rows[index].Cells[1].Value = dataFromDb["roll"].ToString();
                        ViewDataGridView.Rows[index].Cells[2].Value = dataFromDb["reg"].ToString();
                        ViewDataGridView.Rows[index].Cells[3].Value = dataFromDb["faculty"].ToString();




                        byte[] storedImage = (byte[])dataFromDb["img"];

                        Image newImage;
                        MemoryStream stream = new MemoryStream(storedImage);
                        newImage = Image.FromStream(stream);



                        ViewDataGridView.Rows[index].Cells[4].Value = newImage;


                        ((DataGridViewImageColumn)ViewDataGridView.Columns[4]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                        ViewDataGridView.Rows[index].Height = 100;

                    }
                    catch (Exception )
                    { }
                }
            }
            else if (CBox == "Facultywise")
            {
                SqlConnection connection = new SqlConnection("Data Source = DESKTOP-URDRC1S\\SQLEXPRESS ;Initial Catalog = StudentDB; Integrated Security=true");

                connection.Open();

                SqlCommand selectCommand = new SqlCommand("select * from tbl_student_info where faculty like '" + ViewTextBox.Text + "%'", connection);


                //selectCommand.Parameters.Add("@NAME", ViewTextBox.Text);
                SqlDataReader dataFromDb = selectCommand.ExecuteReader();


                while (dataFromDb.Read())
                {

                    try
                    {
                        var index = ViewDataGridView.Rows.Add();


                        ViewDataGridView.Rows[index].Cells[0].Value = dataFromDb["name"].ToString();
                        ViewDataGridView.Rows[index].Cells[1].Value = dataFromDb["roll"].ToString();
                        ViewDataGridView.Rows[index].Cells[2].Value = dataFromDb["reg"].ToString();
                        ViewDataGridView.Rows[index].Cells[3].Value = dataFromDb["faculty"].ToString();




                        byte[] storedImage = (byte[])dataFromDb["img"];

                        Image newImage;
                        MemoryStream stream = new MemoryStream(storedImage);
                        newImage = Image.FromStream(stream);



                        ViewDataGridView.Rows[index].Cells[4].Value = newImage;


                        ((DataGridViewImageColumn)ViewDataGridView.Columns[4]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                        ViewDataGridView.Rows[index].Height = 100;

                    }
                    catch (Exception )
                    { }
                }
            }
            else
            {
                MessageBox.Show(" Follow Proper way ");

            }











        }

        private void FacultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
          
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            string deletee = DeleteTextBox.Text;



            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-URDRC1S\\SQLEXPRESS;Initial Catalog=StudentDB; Integrated Security=true");
            connection.Open();

            SqlCommand selectCommand = new SqlCommand(" delete from tbl_student_info where reg = '" + deletee + "'", connection);


            selectCommand.ExecuteNonQuery();
            MessageBox.Show("Data deleted successfully!!");









        }

        private void ReBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {

            StudentNametextBox.Clear();
            StudentRolltextBox.Clear();
            RegtextBox.Clear();
            ImageTextBox.Clear();
            FacultyComboBox.Text = "";
            StudentPictureBox.Image = null;
        }

        private void Feature_Load(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source =  DESKTOP-URDRC1S\\SQLEXPRESS ;Initial Catalog = StudentDB; Integrated Security=true");

            connection.Open();

            string inputReg = updateSerachBox.Text;

            SqlCommand selectCommand = new SqlCommand("select * from tbl_student_info where reg='" + inputReg + "'", connection);


            SqlDataReader dataFromDb = selectCommand.ExecuteReader();


            while (dataFromDb.Read())
            {

                try
                {

                    string name = dataFromDb["name"].ToString();
                    string reg = dataFromDb["reg"].ToString();
                    string roll = dataFromDb["roll"].ToString();
                    string faculty = dataFromDb["faculty"].ToString();

                    byte[] storedImage = (byte[])dataFromDb["img"];
                    Image newImage;
                    MemoryStream stream = new MemoryStream(storedImage);
                    newImage = Image.FromStream(stream);

                    updateNameBox.Text = name;
                    updateRegBox.Text = reg;
                    updateRollBox.Text = roll;
                    updateComboBox.Text = faculty;
                    updatepictureBox.Image = newImage;




                }
                catch (Exception )
                { }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                updateimagebox.Text = ofd.FileName;


                updateNewImagePicBox.Image = Image.FromFile(@ofd.FileName);
            }


        }

        private void updatebtn_Click(object sender, EventArgs e)
        {


            try
            {
                string updateImageLocation = updateimagebox.Text;

                SqlConnection dbCon = new SqlConnection("Data Source= DESKTOP-URDRC1S\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=true");

                if (updateImageLocation == null || updateImageLocation == "")
                {
                    SqlCommand updateCommandWithoutImage = new SqlCommand("Update tbl_student_info SET name=@StudentName,roll=@StudentRoll,reg=@StudentReg,faculty=@StudentFaculty where reg='" + updateSerachBox.Text + "'", dbCon);

                    updateCommandWithoutImage.Parameters.AddWithValue("@StudentName", updateNameBox.Text);
                    updateCommandWithoutImage.Parameters.AddWithValue("@StudentRoll", updateRollBox.Text);
                    updateCommandWithoutImage.Parameters.AddWithValue("@StudentReg", updateRegBox.Text);
                    updateCommandWithoutImage.Parameters.AddWithValue("@StudentFaculty", updateComboBox.Text);
                    if (dbCon.State == ConnectionState.Closed)
                        dbCon.Open();
                    updateCommandWithoutImage.ExecuteNonQuery();
                    MessageBox.Show("Record Updated  Successfully");

                }
                else
                {

                    byte[] bImageData = GetImageDataForUpdate();

                    SqlCommand updateCommandWithImage = new SqlCommand("Update tbl_student_info SET name=@StudentName,roll=@StudentRoll,reg=@StudentReg,faculty=@StudentFaculty,img=@StudentImage where reg='" + updateSerachBox.Text + "'", dbCon);

                    updateCommandWithImage.Parameters.AddWithValue("@StudentName", updateNameBox.Text);
                    updateCommandWithImage.Parameters.AddWithValue("@StudentRoll", updateRollBox.Text);
                    updateCommandWithImage.Parameters.AddWithValue("@StudentReg", updateRegBox.Text);
                    updateCommandWithImage.Parameters.AddWithValue("@StudentFaculty", updateComboBox.Text);
                    updateCommandWithImage.Parameters.AddWithValue("@StudentImage", bImageData);

                    if (dbCon.State == ConnectionState.Closed)
                        dbCon.Open();
                    updateCommandWithImage.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");

                }





            }
            catch (Exception ex)
            { }



        }
        public byte[] GetImageDataForUpdate()
        {
            Image img = Image.FromFile(updateimagebox.Text);

            ImageConverter ic = new ImageConverter();

            return (byte[])ic.ConvertTo(img, typeof(byte[]));
        }

        private void StudentPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void DeleteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}