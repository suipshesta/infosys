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
    public partial class internet_search_form : MetroForm
    {
        public internet_search_form()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel4.Hide();
            pictureBox4.Hide();
            button2.Hide();



           

            SqlConnection con=new SqlConnection("Data Source=XOX;Initial Catalog=student;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select *  from info1 where First_Name LIKE '" + '%' + label1.Text + '%' + "'",con);
            DataTable dt = new DataTable();

           


            sda.Fill(dt);
            ForeColor = Color.Black;
            dataGridView1.DataSource = dt;
           

            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[13];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            sda.Dispose();


            dataGridView1.Columns["Citizen_no"].DisplayIndex = 14;
            dataGridView1.Columns["Photo"].DisplayIndex = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 80;
            }



           
        }
        public string id
        {



            get { return label1.Text; }

            set { label1.Text = value; }

        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = !panel4.Visible;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

           
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            label8.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string fn = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
           string mn = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string ln = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            label9.Text = fn+" " + mn+" " + " "+ln;
            label28.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            label12.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            label14.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            label16.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

            label18.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            label20.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            label22.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            label24.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            label26.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();

            byte[] img1 = (byte[])dataGridView1.CurrentRow.Cells[13].Value;
            MemoryStream ms1 = new MemoryStream(img1);
            pictureBox3.Image = Image.FromStream(ms1);

            byte[] img2 = (byte[])dataGridView1.CurrentRow.Cells[14].Value;
            MemoryStream ms2 = new MemoryStream(img2);
            pictureBox4.Image = Image.FromStream(ms2);
            button2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = !pictureBox4.Visible;
        }
    }
}
