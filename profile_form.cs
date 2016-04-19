using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace infosys
{
    public partial class profile_form : MetroForm
    {
        public profile_form()
        {
            InitializeComponent();
        }

        private void profile_form_Load(object sender, EventArgs e)
        {
            label1.Hide();
            pictureBox1.Hide();
            

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=XOX;Initial Catalog=student;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("select * from info1 where Citizen_no='" + label1.Text + "'", con);
                
                DataTable dt = new DataTable();
                sda.Fill(dt);
                byte[] MyData1 = new Byte[0];
                byte[] MyData2 = new Byte[0];
                MyData1 = (byte[])dt.Rows[0][14];
                MyData2 = (byte[])dt.Rows[0][13];
                MemoryStream str1 = new MemoryStream(MyData1);
                MemoryStream str2 = new MemoryStream(MyData2);
                pictureBox1.Image = Image.FromStream(str1);
                pictureBox2.Image = Image.FromStream(str2);

                label9.Text = dt.Rows[0].ItemArray.GetValue(0).ToString();
                label3.Text = dt.Rows[0].ItemArray.GetValue(1).ToString() + ' ' + dt.Rows[0].ItemArray.GetValue(2).ToString() + ' ' + dt.Rows[0].ItemArray.GetValue(3).ToString();
                label20.Text = dt.Rows[0].ItemArray.GetValue(11).ToString();
                label10.Text = dt.Rows[0].ItemArray.GetValue(12).ToString();
                label12.Text = dt.Rows[0].ItemArray.GetValue(5).ToString();
                label8.Text = dt.Rows[0].ItemArray.GetValue(6).ToString();
                label16.Text = dt.Rows[0].ItemArray.GetValue(7).ToString();
                label17.Text = dt.Rows[0].ItemArray.GetValue(8).ToString();
                label18.Text = dt.Rows[0].ItemArray.GetValue(9).ToString();
                label19.Text = dt.Rows[0].ItemArray.GetValue(10).ToString();

            }
            catch (Exception tr)
            {

                MessageBox.Show(tr.Message);
                


            }





        }
        public string id
        {


           
            get { return label1.Text; }
            
            set { label1.Text = value; }
           
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle1.Checked)
            {
                pictureBox1.Show();

            }
            else
            {
                pictureBox1.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
        

       
      


    }
}
