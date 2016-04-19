using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MetroFramework.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

using NITGEN.SDK.NBioBSP;

namespace infosys
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : MetroForm
    {
        NBioAPI m_NBioAPI;
        NBioAPI.Export m_Export;
        NBioAPI.IndexSearch m_IndexSearch;
        short m_OpenedDeviceID;
        NBioAPI.Type.HFIR m_hNewFIR;
        NBioAPI.Type.DEVICE_INFO_EX[] m_DeviceInfoEx;

        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        public static Bitmap _latestFrame;


        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDevice;
        private System.Windows.Forms.Label labStatus;
        private PictureBox Thumb_photo;
        private Label label2;
        private MetroFramework.Controls.MetroTextBox TextBox1;
        private MetroFramework.Controls.MetroTextBox First_Name;
        private MetroFramework.Controls.MetroTextBox Middle_Name;
        private Label label3;
        private Label label4;
        private Label label5;
        private MetroFramework.Controls.MetroTextBox DOB;
        private MetroFramework.Controls.MetroTextBox metroTextBox5;
        private Label label6;
        private Label label7;
        private Panel panel1;
        private Panel panel2;
        private PictureBox User_photo;
        private GroupBox groupBox3;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private GroupBox groupBox4;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton4;
        private Panel panel3;
        private MetroFramework.Controls.MetroComboBox comboBoxCameras;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton metroButton8;
        private MetroFramework.Controls.MetroButton metroButton7;
        private MetroFramework.Controls.MetroButton metroButton5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private MetroFramework.Controls.MetroButton metroButton10;
        private GroupBox groupBox5;
        private Label SaveSatus;
        private MetroFramework.Controls.MetroButton buttonRollCapture2;
        private MetroFramework.Controls.MetroButton buttonOpen;
        private ListView listSearchDB;
        private ColumnHeader columnUserID;
        private ColumnHeader columnFpID;
        private ColumnHeader columnSampleNo;
        private MetroFramework.Controls.MetroButton buttonRollCapture1;
        private MetroFramework.Controls.MetroTextBox metroTextBox9;
        private MetroFramework.Controls.MetroTextBox metroTextBox8;
        private MetroFramework.Controls.MetroTextBox metroTextBox7;
        private MetroFramework.Controls.MetroTextBox metroTextBox6;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private MetroFramework.Controls.MetroTextBox metroTextBox10;
        private MetroFramework.Controls.MetroButton metroButton9;
        private MetroFramework.Controls.MetroTextBox metroTextBox3;
        private MetroFramework.Controls.MetroButton metroButton11;
        private Panel panel4;
        private MetroFramework.Controls.MetroTextBox metroTextBox12;
        private MetroFramework.Controls.MetroButton metroButton12;
        private GroupBox groupBox7;
        private GroupBox groupBox6;
        private Panel panel5;
        private MetroFramework.Controls.MetroTextBox search_text;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private Panel panel6;
        private MetroFramework.Controls.MetroTile metroTile4;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTile metroTile5;
        private Label label13;
        private MetroFramework.Controls.MetroTextBox metroTextBox13;
        private Label label14;
        private MetroFramework.Controls.MetroTextBox metroTextBox14;
        private Label label15;
        private Label label16;
        private Panel panel7;
        private PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton metroButton13;
        private MetroFramework.Controls.MetroProgressBar progressIdentify;
        private Panel panel8;
        private Panel panel9;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private Panel panel10;
        private MetroFramework.Controls.MetroTile metroTile6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox2;
        private Panel panel11;
        private Panel panel12;
        private DataGridView dataGridView1;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private MetroFramework.Controls.MetroTextBox metroTextBox19;
        private MetroFramework.Controls.MetroTextBox metroTextBox18;
        private MetroFramework.Controls.MetroTextBox metroTextBox17;
        private MetroFramework.Controls.MetroTextBox metroTextBox16;
        private MetroFramework.Controls.MetroTextBox metroTextBox15;
        private MetroFramework.Controls.MetroTextBox metroTextBox11;
        private MetroFramework.Controls.MetroTextBox metroTextBox4;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroButton metroButton14;
        private MetroFramework.Controls.MetroButton metroButton15;
        private MetroFramework.Controls.MetroTile metroTile7;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {

            InitializeComponent();

            m_NBioAPI = new NBioAPI();
            m_Export = new NBioAPI.Export(m_NBioAPI);


            m_IndexSearch = new NBioAPI.IndexSearch(m_NBioAPI);


            m_hNewFIR = null;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOpen = new MetroFramework.Controls.MetroButton();
            this.comboDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonRollCapture1 = new MetroFramework.Controls.MetroButton();
            this.buttonRollCapture2 = new MetroFramework.Controls.MetroButton();
            this.Thumb_photo = new System.Windows.Forms.PictureBox();
            this.labStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.First_Name = new MetroFramework.Controls.MetroTextBox();
            this.Middle_Name = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DOB = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox5 = new MetroFramework.Controls.MetroTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroButton9 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.User_photo = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.listSearchDB = new System.Windows.Forms.ListView();
            this.columnUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFpID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSampleNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.metroTextBox9 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox8 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox7 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox6 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox14 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox10 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox13 = new MetroFramework.Controls.MetroTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxCameras = new MetroFramework.Controls.MetroComboBox();
            this.SaveSatus = new System.Windows.Forms.Label();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.metroButton10 = new MetroFramework.Controls.MetroButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.metroButton8 = new MetroFramework.Controls.MetroButton();
            this.metroTextBox3 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton11 = new MetroFramework.Controls.MetroButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.metroTextBox12 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton12 = new MetroFramework.Controls.MetroButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.search_text = new MetroFramework.Controls.MetroTextBox();
            this.metroButton13 = new MetroFramework.Controls.MetroButton();
            this.label16 = new System.Windows.Forms.Label();
            this.progressIdentify = new MetroFramework.Controls.MetroProgressBar();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile5 = new MetroFramework.Controls.MetroTile();
            this.label13 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTile6 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.metroButton15 = new MetroFramework.Controls.MetroButton();
            this.metroButton14 = new MetroFramework.Controls.MetroButton();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.metroTextBox19 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox18 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox17 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox16 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox15 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox11 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox4 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroTile7 = new MetroFramework.Controls.MetroTile();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Thumb_photo)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User_photo)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.Controls.Add(this.buttonOpen);
            this.groupBox1.Controls.Add(this.comboDevice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(1031, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 466);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device function";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(204, 22);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "Select Device";
            this.buttonOpen.UseSelectable = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click_1);
            // 
            // comboDevice
            // 
            this.comboDevice.Location = new System.Drawing.Point(76, 23);
            this.comboDevice.Name = "comboDevice";
            this.comboDevice.Size = new System.Drawing.Size(122, 21);
            this.comboDevice.TabIndex = 1;
            this.comboDevice.SelectedIndexChanged += new System.EventHandler(this.comboDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device List";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonRollCapture1);
            this.groupBox2.Controls.Add(this.buttonRollCapture2);
            this.groupBox2.Controls.Add(this.Thumb_photo);
            this.groupBox2.Controls.Add(this.labStatus);
            this.groupBox2.Location = new System.Drawing.Point(25, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 348);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Capture function";
            // 
            // buttonRollCapture1
            // 
            this.buttonRollCapture1.Location = new System.Drawing.Point(25, 291);
            this.buttonRollCapture1.Name = "buttonRollCapture1";
            this.buttonRollCapture1.Size = new System.Drawing.Size(99, 42);
            this.buttonRollCapture1.TabIndex = 6;
            this.buttonRollCapture1.Text = "Scan 1";
            this.buttonRollCapture1.UseSelectable = true;
            this.buttonRollCapture1.Click += new System.EventHandler(this.metroButton9_Click);
            // 
            // buttonRollCapture2
            // 
            this.buttonRollCapture2.Location = new System.Drawing.Point(130, 291);
            this.buttonRollCapture2.Name = "buttonRollCapture2";
            this.buttonRollCapture2.Size = new System.Drawing.Size(105, 42);
            this.buttonRollCapture2.TabIndex = 5;
            this.buttonRollCapture2.Text = "Scan 2";
            this.buttonRollCapture2.UseSelectable = true;
            this.buttonRollCapture2.Click += new System.EventHandler(this.buttonRollCapture_Click_1);
            // 
            // Thumb_photo
            // 
            this.Thumb_photo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Thumb_photo.Location = new System.Drawing.Point(30, 28);
            this.Thumb_photo.Name = "Thumb_photo";
            this.Thumb_photo.Size = new System.Drawing.Size(180, 207);
            this.Thumb_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Thumb_photo.TabIndex = 4;
            this.Thumb_photo.TabStop = false;
            // 
            // labStatus
            // 
            this.labStatus.Location = new System.Drawing.Point(6, 238);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(228, 49);
            this.labStatus.TabIndex = 2;
            this.labStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Citizen No.";
            // 
            // TextBox1
            // 
            this.TextBox1.Lines = new string[0];
            this.TextBox1.Location = new System.Drawing.Point(125, 25);
            this.TextBox1.MaxLength = 32767;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.PasswordChar = '\0';
            this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox1.SelectedText = "";
            this.TextBox1.Size = new System.Drawing.Size(124, 23);
            this.TextBox1.TabIndex = 9;
            this.TextBox1.UseSelectable = true;
            // 
            // First_Name
            // 
            this.First_Name.Lines = new string[0];
            this.First_Name.Location = new System.Drawing.Point(125, 69);
            this.First_Name.MaxLength = 32767;
            this.First_Name.Name = "First_Name";
            this.First_Name.PasswordChar = '\0';
            this.First_Name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.First_Name.SelectedText = "";
            this.First_Name.Size = new System.Drawing.Size(152, 23);
            this.First_Name.TabIndex = 9;
            this.First_Name.UseSelectable = true;
            this.First_Name.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // Middle_Name
            // 
            this.Middle_Name.Lines = new string[0];
            this.Middle_Name.Location = new System.Drawing.Point(125, 108);
            this.Middle_Name.MaxLength = 32767;
            this.Middle_Name.Name = "Middle_Name";
            this.Middle_Name.PasswordChar = '\0';
            this.Middle_Name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Middle_Name.SelectedText = "";
            this.Middle_Name.Size = new System.Drawing.Size(152, 23);
            this.Middle_Name.TabIndex = 9;
            this.Middle_Name.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Middle Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gender";
            // 
            // DOB
            // 
            this.DOB.Lines = new string[0];
            this.DOB.Location = new System.Drawing.Point(125, 226);
            this.DOB.MaxLength = 32767;
            this.DOB.Name = "DOB";
            this.DOB.PasswordChar = '\0';
            this.DOB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DOB.SelectedText = "";
            this.DOB.Size = new System.Drawing.Size(152, 23);
            this.DOB.TabIndex = 9;
            this.DOB.UseSelectable = true;
            // 
            // metroTextBox5
            // 
            this.metroTextBox5.Lines = new string[0];
            this.metroTextBox5.Location = new System.Drawing.Point(125, 336);
            this.metroTextBox5.MaxLength = 32767;
            this.metroTextBox5.Name = "metroTextBox5";
            this.metroTextBox5.PasswordChar = '\0';
            this.metroTextBox5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox5.SelectedText = "";
            this.metroTextBox5.Size = new System.Drawing.Size(152, 23);
            this.metroTextBox5.TabIndex = 9;
            this.metroTextBox5.UseSelectable = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "DOB";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Zone";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.metroButton9);
            this.panel1.Controls.Add(this.metroButton4);
            this.panel1.Controls.Add(this.metroButton3);
            this.panel1.Controls.Add(this.metroButton2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(427, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1334, 594);
            this.panel1.TabIndex = 10;
            // 
            // metroButton9
            // 
            this.metroButton9.Location = new System.Drawing.Point(1217, 548);
            this.metroButton9.Name = "metroButton9";
            this.metroButton9.Size = new System.Drawing.Size(101, 37);
            this.metroButton9.TabIndex = 15;
            this.metroButton9.Text = "close";
            this.metroButton9.UseSelectable = true;
            this.metroButton9.Click += new System.EventHandler(this.metroButton9_Click_1);
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(786, 291);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(192, 33);
            this.metroButton4.TabIndex = 12;
            this.metroButton4.Text = "Select Photo";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(930, 549);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(167, 37);
            this.metroButton3.TabIndex = 14;
            this.metroButton3.Text = "Register";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(1103, 548);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(108, 37);
            this.metroButton2.TabIndex = 14;
            this.metroButton2.Text = "clear";
            this.metroButton2.UseSelectable = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox3.Controls.Add(this.User_photo);
            this.groupBox3.Location = new System.Drawing.Point(744, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 247);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Photo";
            // 
            // User_photo
            // 
            this.User_photo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.User_photo.Location = new System.Drawing.Point(15, 20);
            this.User_photo.Name = "User_photo";
            this.User_photo.Size = new System.Drawing.Size(235, 207);
            this.User_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.User_photo.TabIndex = 4;
            this.User_photo.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.metroButton1);
            this.groupBox4.Location = new System.Drawing.Point(744, 337);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(263, 66);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "OR";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(42, 19);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(192, 33);
            this.metroButton1.TabIndex = 12;
            this.metroButton1.Text = "Use Webcam";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.metroTextBox9);
            this.panel2.Controls.Add(this.metroTextBox8);
            this.panel2.Controls.Add(this.metroTextBox7);
            this.panel2.Controls.Add(this.metroTextBox6);
            this.panel2.Controls.Add(this.metroTextBox14);
            this.panel2.Controls.Add(this.metroTextBox5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.metroTextBox10);
            this.panel2.Controls.Add(this.DOB);
            this.panel2.Controls.Add(this.TextBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.metroTextBox13);
            this.panel2.Controls.Add(this.Middle_Name);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.First_Name);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(729, 594);
            this.panel2.TabIndex = 11;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.listSearchDB);
            this.panel11.Location = new System.Drawing.Point(492, 7);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(224, 323);
            this.panel11.TabIndex = 18;
            // 
            // listSearchDB
            // 
            this.listSearchDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUserID,
            this.columnFpID,
            this.columnSampleNo});
            this.listSearchDB.Location = new System.Drawing.Point(34, 18);
            this.listSearchDB.Name = "listSearchDB";
            this.listSearchDB.Size = new System.Drawing.Size(168, 290);
            this.listSearchDB.TabIndex = 16;
            this.listSearchDB.UseCompatibleStateImageBehavior = false;
            this.listSearchDB.View = System.Windows.Forms.View.Details;
            this.listSearchDB.SelectedIndexChanged += new System.EventHandler(this.listSearchDB_SelectedIndexChanged);
            // 
            // columnUserID
            // 
            this.columnUserID.Text = "User ID";
            this.columnUserID.Width = 51;
            // 
            // columnFpID
            // 
            this.columnFpID.Text = "Fp ID";
            this.columnFpID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnFpID.Width = 55;
            // 
            // columnSampleNo
            // 
            this.columnSampleNo.Text = "Sam No.";
            this.columnSampleNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(193, 190);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 17);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "female";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(125, 190);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 17);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "male";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // metroTextBox9
            // 
            this.metroTextBox9.Lines = new string[0];
            this.metroTextBox9.Location = new System.Drawing.Point(125, 495);
            this.metroTextBox9.MaxLength = 32767;
            this.metroTextBox9.Name = "metroTextBox9";
            this.metroTextBox9.PasswordChar = '\0';
            this.metroTextBox9.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox9.SelectedText = "";
            this.metroTextBox9.Size = new System.Drawing.Size(152, 23);
            this.metroTextBox9.TabIndex = 9;
            this.metroTextBox9.UseSelectable = true;
            // 
            // metroTextBox8
            // 
            this.metroTextBox8.Lines = new string[0];
            this.metroTextBox8.Location = new System.Drawing.Point(125, 454);
            this.metroTextBox8.MaxLength = 32767;
            this.metroTextBox8.Name = "metroTextBox8";
            this.metroTextBox8.PasswordChar = '\0';
            this.metroTextBox8.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox8.SelectedText = "";
            this.metroTextBox8.Size = new System.Drawing.Size(152, 23);
            this.metroTextBox8.TabIndex = 9;
            this.metroTextBox8.UseSelectable = true;
            // 
            // metroTextBox7
            // 
            this.metroTextBox7.Lines = new string[0];
            this.metroTextBox7.Location = new System.Drawing.Point(125, 415);
            this.metroTextBox7.MaxLength = 32767;
            this.metroTextBox7.Name = "metroTextBox7";
            this.metroTextBox7.PasswordChar = '\0';
            this.metroTextBox7.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox7.SelectedText = "";
            this.metroTextBox7.Size = new System.Drawing.Size(152, 23);
            this.metroTextBox7.TabIndex = 9;
            this.metroTextBox7.UseSelectable = true;
            // 
            // metroTextBox6
            // 
            this.metroTextBox6.Lines = new string[0];
            this.metroTextBox6.Location = new System.Drawing.Point(125, 375);
            this.metroTextBox6.MaxLength = 32767;
            this.metroTextBox6.Name = "metroTextBox6";
            this.metroTextBox6.PasswordChar = '\0';
            this.metroTextBox6.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox6.SelectedText = "";
            this.metroTextBox6.Size = new System.Drawing.Size(152, 23);
            this.metroTextBox6.TabIndex = 9;
            this.metroTextBox6.UseSelectable = true;
            // 
            // metroTextBox14
            // 
            this.metroTextBox14.Lines = new string[0];
            this.metroTextBox14.Location = new System.Drawing.Point(125, 297);
            this.metroTextBox14.MaxLength = 32767;
            this.metroTextBox14.Name = "metroTextBox14";
            this.metroTextBox14.PasswordChar = '\0';
            this.metroTextBox14.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox14.SelectedText = "";
            this.metroTextBox14.Size = new System.Drawing.Size(152, 23);
            this.metroTextBox14.TabIndex = 9;
            this.metroTextBox14.UseSelectable = true;
            // 
            // metroTextBox10
            // 
            this.metroTextBox10.Lines = new string[0];
            this.metroTextBox10.Location = new System.Drawing.Point(125, 260);
            this.metroTextBox10.MaxLength = 32767;
            this.metroTextBox10.Name = "metroTextBox10";
            this.metroTextBox10.PasswordChar = '\0';
            this.metroTextBox10.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox10.SelectedText = "";
            this.metroTextBox10.Size = new System.Drawing.Size(152, 23);
            this.metroTextBox10.TabIndex = 9;
            this.metroTextBox10.UseSelectable = true;
            // 
            // metroTextBox13
            // 
            this.metroTextBox13.Lines = new string[0];
            this.metroTextBox13.Location = new System.Drawing.Point(125, 150);
            this.metroTextBox13.MaxLength = 32767;
            this.metroTextBox13.Name = "metroTextBox13";
            this.metroTextBox13.PasswordChar = '\0';
            this.metroTextBox13.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox13.SelectedText = "";
            this.metroTextBox13.Size = new System.Drawing.Size(152, 23);
            this.metroTextBox13.TabIndex = 9;
            this.metroTextBox13.UseSelectable = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Last Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 499);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Ward No.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Email";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 460);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "VDC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Municipality";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "District";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 304);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Country";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Location = new System.Drawing.Point(107, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1006, 594);
            this.panel3.TabIndex = 11;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxCameras);
            this.groupBox5.Controls.Add(this.SaveSatus);
            this.groupBox5.Controls.Add(this.metroButton5);
            this.groupBox5.Controls.Add(this.metroButton6);
            this.groupBox5.Controls.Add(this.pictureBox4);
            this.groupBox5.Controls.Add(this.metroButton10);
            this.groupBox5.Controls.Add(this.pictureBox3);
            this.groupBox5.Controls.Add(this.metroButton7);
            this.groupBox5.Controls.Add(this.metroButton8);
            this.groupBox5.Location = new System.Drawing.Point(14, 25);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(970, 547);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Take Photo";
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.ItemHeight = 23;
            this.comboBoxCameras.Location = new System.Drawing.Point(27, 488);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(154, 29);
            this.comboBoxCameras.TabIndex = 2;
            this.comboBoxCameras.UseSelectable = true;
            // 
            // SaveSatus
            // 
            this.SaveSatus.AutoSize = true;
            this.SaveSatus.Location = new System.Drawing.Point(699, 337);
            this.SaveSatus.Name = "SaveSatus";
            this.SaveSatus.Size = new System.Drawing.Size(0, 13);
            this.SaveSatus.TabIndex = 2;
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(211, 488);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(75, 29);
            this.metroButton5.TabIndex = 1;
            this.metroButton5.Text = "Start";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton6
            // 
            this.metroButton6.Location = new System.Drawing.Point(315, 488);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(75, 29);
            this.metroButton6.TabIndex = 1;
            this.metroButton6.Text = "Stop";
            this.metroButton6.UseSelectable = true;
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(27, 41);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(591, 421);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // metroButton10
            // 
            this.metroButton10.Location = new System.Drawing.Point(816, 488);
            this.metroButton10.Name = "metroButton10";
            this.metroButton10.Size = new System.Drawing.Size(148, 29);
            this.metroButton10.TabIndex = 1;
            this.metroButton10.Text = "Back to Registration";
            this.metroButton10.UseSelectable = true;
            this.metroButton10.Click += new System.EventHandler(this.metroButton10_Click_1);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(669, 125);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(267, 201);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // metroButton7
            // 
            this.metroButton7.Location = new System.Drawing.Point(636, 488);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(75, 29);
            this.metroButton7.TabIndex = 1;
            this.metroButton7.Text = "Click";
            this.metroButton7.UseSelectable = true;
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // metroButton8
            // 
            this.metroButton8.Location = new System.Drawing.Point(722, 488);
            this.metroButton8.Name = "metroButton8";
            this.metroButton8.Size = new System.Drawing.Size(84, 29);
            this.metroButton8.TabIndex = 1;
            this.metroButton8.Text = "Save Current";
            this.metroButton8.UseSelectable = true;
            this.metroButton8.Click += new System.EventHandler(this.metroButton8_Click);
            // 
            // metroTextBox3
            // 
            this.metroTextBox3.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.metroTextBox3.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.metroTextBox3.Lines = new string[0];
            this.metroTextBox3.Location = new System.Drawing.Point(151, 118);
            this.metroTextBox3.MaxLength = 32767;
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.PasswordChar = '\0';
            this.metroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox3.SelectedText = "";
            this.metroTextBox3.Size = new System.Drawing.Size(414, 50);
            this.metroTextBox3.TabIndex = 12;
            this.metroTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox3.UseSelectable = true;
            // 
            // metroButton11
            // 
            this.metroButton11.Location = new System.Drawing.Point(170, 127);
            this.metroButton11.Name = "metroButton11";
            this.metroButton11.Size = new System.Drawing.Size(155, 49);
            this.metroButton11.TabIndex = 13;
            this.metroButton11.Text = "search";
            this.metroButton11.UseSelectable = true;
            this.metroButton11.Click += new System.EventHandler(this.metroButton11_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.metroTextBox12);
            this.panel4.Controls.Add(this.metroTextBox3);
            this.panel4.Controls.Add(this.metroButton12);
            this.panel4.Controls.Add(this.groupBox7);
            this.panel4.Controls.Add(this.groupBox6);
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Location = new System.Drawing.Point(304, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(730, 541);
            this.panel4.TabIndex = 14;
            // 
            // metroTextBox12
            // 
            this.metroTextBox12.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.metroTextBox12.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.metroTextBox12.Lines = new string[0];
            this.metroTextBox12.Location = new System.Drawing.Point(151, 256);
            this.metroTextBox12.MaxLength = 32767;
            this.metroTextBox12.Name = "metroTextBox12";
            this.metroTextBox12.PasswordChar = '\0';
            this.metroTextBox12.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox12.SelectedText = "";
            this.metroTextBox12.Size = new System.Drawing.Size(414, 50);
            this.metroTextBox12.TabIndex = 12;
            this.metroTextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox12.UseSelectable = true;
            // 
            // metroButton12
            // 
            this.metroButton12.Location = new System.Drawing.Point(273, 378);
            this.metroButton12.Name = "metroButton12";
            this.metroButton12.Size = new System.Drawing.Size(155, 59);
            this.metroButton12.TabIndex = 13;
            this.metroButton12.Text = "sign in";
            this.metroButton12.UseSelectable = true;
            this.metroButton12.Click += new System.EventHandler(this.metroButton12_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(117, 229);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(480, 99);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Password";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(117, 93);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(480, 99);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "User Name";
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Location = new System.Drawing.Point(66, 27);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(581, 471);
            this.panel9.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel12);
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Location = new System.Drawing.Point(182, 32);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(858, 583);
            this.panel5.TabIndex = 15;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::infosys.Properties.Resources.giphy__1_1;
            this.pictureBox5.Location = new System.Drawing.Point(289, -27);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(368, 328);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.search_text);
            this.panel10.Controls.Add(this.metroButton13);
            this.panel10.Controls.Add(this.label16);
            this.panel10.Controls.Add(this.metroButton11);
            this.panel10.Location = new System.Drawing.Point(231, 307);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(494, 271);
            this.panel10.TabIndex = 20;
            // 
            // search_text
            // 
            this.search_text.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.search_text.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.search_text.Lines = new string[0];
            this.search_text.Location = new System.Drawing.Point(22, 38);
            this.search_text.Margin = new System.Windows.Forms.Padding(0);
            this.search_text.MaxLength = 32767;
            this.search_text.Name = "search_text";
            this.search_text.PasswordChar = '\0';
            this.search_text.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.search_text.SelectedText = "";
            this.search_text.Size = new System.Drawing.Size(451, 70);
            this.search_text.TabIndex = 16;
            this.search_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.search_text.Theme = MetroFramework.MetroThemeStyle.Light;
            this.search_text.UseCustomBackColor = true;
            this.search_text.UseSelectable = true;
            // 
            // metroButton13
            // 
            this.metroButton13.Location = new System.Drawing.Point(170, 193);
            this.metroButton13.Name = "metroButton13";
            this.metroButton13.Size = new System.Drawing.Size(155, 51);
            this.metroButton13.TabIndex = 18;
            this.metroButton13.Text = "Finger Scan";
            this.metroButton13.UseSelectable = true;
            this.metroButton13.Click += new System.EventHandler(this.metroButton13_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(187, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "Type  Citizen No. or Name";
            // 
            // progressIdentify
            // 
            this.progressIdentify.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressIdentify.FontWeight = MetroFramework.MetroProgressBarWeight.Bold;
            this.progressIdentify.Location = new System.Drawing.Point(20, 731);
            this.progressIdentify.Margin = new System.Windows.Forms.Padding(1);
            this.progressIdentify.Name = "progressIdentify";
            this.progressIdentify.Size = new System.Drawing.Size(1330, 10);
            this.progressIdentify.Step = 5;
            this.progressIdentify.Style = MetroFramework.MetroColorStyle.Blue;
            this.progressIdentify.TabIndex = 19;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(1220, 35);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(127, 56);
            this.metroTile1.TabIndex = 19;
            this.metroTile1.Text = "Admin Sign In";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseCustomForeColor = true;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.ForeColor = System.Drawing.Color.Red;
            this.metroLabel1.Location = new System.Drawing.Point(79, 673);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 19);
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "normal";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.metroTile4);
            this.panel6.Controls.Add(this.metroTile3);
            this.panel6.Controls.Add(this.metroTile5);
            this.panel6.Location = new System.Drawing.Point(96, 66);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(889, 550);
            this.panel6.TabIndex = 21;
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Location = new System.Drawing.Point(582, 145);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(164, 125);
            this.metroTile4.TabIndex = 2;
            this.metroTile4.Text = "Show Database";
            this.metroTile4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile4.TileImage = global::infosys.Properties.Resources.appbar_window_simple;
            this.metroTile4.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile4.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile4.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile4.UseSelectable = true;
            this.metroTile4.UseTileImage = true;
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Location = new System.Drawing.Point(371, 145);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(164, 125);
            this.metroTile3.TabIndex = 2;
            this.metroTile3.Text = "Edit Data";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile3.TileImage = global::infosys.Properties.Resources.appbar_checkmark_pencil;
            this.metroTile3.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile3.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.UseTileImage = true;
            this.metroTile3.Click += new System.EventHandler(this.metroTile3_Click);
            // 
            // metroTile5
            // 
            this.metroTile5.ActiveControl = null;
            this.metroTile5.Location = new System.Drawing.Point(147, 145);
            this.metroTile5.Name = "metroTile5";
            this.metroTile5.Size = new System.Drawing.Size(164, 123);
            this.metroTile5.TabIndex = 2;
            this.metroTile5.Text = "New Entry";
            this.metroTile5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile5.TileImage = global::infosys.Properties.Resources.appbar_camera_switch;
            this.metroTile5.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile5.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile5.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile5.UseSelectable = true;
            this.metroTile5.UseTileImage = true;
            this.metroTile5.Click += new System.EventHandler(this.metroTile5_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 676);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "status:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(65, 62);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(460, 554);
            this.panel7.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(267, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Location = new System.Drawing.Point(31, 20);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(391, 505);
            this.panel8.TabIndex = 19;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(102, 29);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(96, 47);
            this.metroLabel2.TabIndex = 23;
            this.metroLabel2.Text = "Info-Sys";
            // 
            // metroTile6
            // 
            this.metroTile6.ActiveControl = null;
            this.metroTile6.Location = new System.Drawing.Point(1243, 32);
            this.metroTile6.Name = "metroTile6";
            this.metroTile6.Size = new System.Drawing.Size(127, 56);
            this.metroTile6.TabIndex = 21;
            this.metroTile6.Text = "logout";
            this.metroTile6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile6.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile6.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile6.UseCustomForeColor = true;
            this.metroTile6.UseSelectable = true;
            this.metroTile6.Click += new System.EventHandler(this.metroTile6_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(1094, 32);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(116, 56);
            this.metroTile2.TabIndex = 20;
            this.metroTile2.TileImage = global::infosys.Properties.Resources.appbar_magnify_back;
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::infosys.Properties.Resources.Nepali_flag__1_;
            this.pictureBox2.Location = new System.Drawing.Point(13, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.metroButton15);
            this.panel12.Controls.Add(this.metroButton14);
            this.panel12.Controls.Add(this.label25);
            this.panel12.Controls.Add(this.label24);
            this.panel12.Controls.Add(this.label23);
            this.panel12.Controls.Add(this.label22);
            this.panel12.Controls.Add(this.label21);
            this.panel12.Controls.Add(this.label20);
            this.panel12.Controls.Add(this.label19);
            this.panel12.Controls.Add(this.label18);
            this.panel12.Controls.Add(this.label17);
            this.panel12.Controls.Add(this.metroTextBox19);
            this.panel12.Controls.Add(this.metroTextBox18);
            this.panel12.Controls.Add(this.metroTextBox17);
            this.panel12.Controls.Add(this.metroTextBox16);
            this.panel12.Controls.Add(this.metroTextBox15);
            this.panel12.Controls.Add(this.metroTextBox11);
            this.panel12.Controls.Add(this.metroTextBox4);
            this.panel12.Controls.Add(this.metroTextBox2);
            this.panel12.Controls.Add(this.metroTextBox1);
            this.panel12.Controls.Add(this.dataGridView1);
            this.panel12.Location = new System.Drawing.Point(349, 15);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1327, 484);
            this.panel12.TabIndex = 24;
            // 
            // metroButton15
            // 
            this.metroButton15.Location = new System.Drawing.Point(484, 26);
            this.metroButton15.Name = "metroButton15";
            this.metroButton15.Size = new System.Drawing.Size(75, 23);
            this.metroButton15.TabIndex = 4;
            this.metroButton15.Text = "delete";
            this.metroButton15.UseSelectable = true;
            this.metroButton15.Click += new System.EventHandler(this.metroButton15_Click);
            // 
            // metroButton14
            // 
            this.metroButton14.Location = new System.Drawing.Point(381, 29);
            this.metroButton14.Name = "metroButton14";
            this.metroButton14.Size = new System.Drawing.Size(75, 23);
            this.metroButton14.TabIndex = 3;
            this.metroButton14.Text = "add";
            this.metroButton14.UseSelectable = true;
            this.metroButton14.Click += new System.EventHandler(this.metroButton14_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 411);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "label17";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(19, 341);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "label17";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 306);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "label17";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 269);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "label17";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 229);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "label17";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 185);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "label17";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 151);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "label17";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 103);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "label17";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "label17";
            // 
            // metroTextBox19
            // 
            this.metroTextBox19.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox19.Location = new System.Drawing.Point(139, 408);
            this.metroTextBox19.MaxLength = 32767;
            this.metroTextBox19.Name = "metroTextBox19";
            this.metroTextBox19.PasswordChar = '\0';
            this.metroTextBox19.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox19.SelectedText = "";
            this.metroTextBox19.Size = new System.Drawing.Size(145, 23);
            this.metroTextBox19.TabIndex = 1;
            this.metroTextBox19.Text = "metroTextBox1";
            this.metroTextBox19.UseSelectable = true;
            // 
            // metroTextBox18
            // 
            this.metroTextBox18.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox18.Location = new System.Drawing.Point(139, 334);
            this.metroTextBox18.MaxLength = 32767;
            this.metroTextBox18.Name = "metroTextBox18";
            this.metroTextBox18.PasswordChar = '\0';
            this.metroTextBox18.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox18.SelectedText = "";
            this.metroTextBox18.Size = new System.Drawing.Size(145, 23);
            this.metroTextBox18.TabIndex = 1;
            this.metroTextBox18.Text = "metroTextBox1";
            this.metroTextBox18.UseSelectable = true;
            // 
            // metroTextBox17
            // 
            this.metroTextBox17.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox17.Location = new System.Drawing.Point(139, 298);
            this.metroTextBox17.MaxLength = 32767;
            this.metroTextBox17.Name = "metroTextBox17";
            this.metroTextBox17.PasswordChar = '\0';
            this.metroTextBox17.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox17.SelectedText = "";
            this.metroTextBox17.Size = new System.Drawing.Size(145, 23);
            this.metroTextBox17.TabIndex = 1;
            this.metroTextBox17.Text = "metroTextBox1";
            this.metroTextBox17.UseSelectable = true;
            // 
            // metroTextBox16
            // 
            this.metroTextBox16.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox16.Location = new System.Drawing.Point(139, 259);
            this.metroTextBox16.MaxLength = 32767;
            this.metroTextBox16.Name = "metroTextBox16";
            this.metroTextBox16.PasswordChar = '\0';
            this.metroTextBox16.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox16.SelectedText = "";
            this.metroTextBox16.Size = new System.Drawing.Size(145, 23);
            this.metroTextBox16.TabIndex = 1;
            this.metroTextBox16.Text = "metroTextBox1";
            this.metroTextBox16.UseSelectable = true;
            // 
            // metroTextBox15
            // 
            this.metroTextBox15.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox15.Location = new System.Drawing.Point(139, 225);
            this.metroTextBox15.MaxLength = 32767;
            this.metroTextBox15.Name = "metroTextBox15";
            this.metroTextBox15.PasswordChar = '\0';
            this.metroTextBox15.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox15.SelectedText = "";
            this.metroTextBox15.Size = new System.Drawing.Size(145, 23);
            this.metroTextBox15.TabIndex = 1;
            this.metroTextBox15.Text = "metroTextBox1";
            this.metroTextBox15.UseSelectable = true;
            // 
            // metroTextBox11
            // 
            this.metroTextBox11.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox11.Location = new System.Drawing.Point(139, 184);
            this.metroTextBox11.MaxLength = 32767;
            this.metroTextBox11.Name = "metroTextBox11";
            this.metroTextBox11.PasswordChar = '\0';
            this.metroTextBox11.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox11.SelectedText = "";
            this.metroTextBox11.Size = new System.Drawing.Size(145, 23);
            this.metroTextBox11.TabIndex = 1;
            this.metroTextBox11.Text = "metroTextBox1";
            this.metroTextBox11.UseSelectable = true;
            // 
            // metroTextBox4
            // 
            this.metroTextBox4.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox4.Location = new System.Drawing.Point(139, 150);
            this.metroTextBox4.MaxLength = 32767;
            this.metroTextBox4.Name = "metroTextBox4";
            this.metroTextBox4.PasswordChar = '\0';
            this.metroTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox4.SelectedText = "";
            this.metroTextBox4.Size = new System.Drawing.Size(145, 23);
            this.metroTextBox4.TabIndex = 1;
            this.metroTextBox4.Text = "metroTextBox1";
            this.metroTextBox4.UseSelectable = true;
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox2.Location = new System.Drawing.Point(139, 99);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.Size = new System.Drawing.Size(145, 23);
            this.metroTextBox2.TabIndex = 1;
            this.metroTextBox2.Text = "metroTextBox1";
            this.metroTextBox2.UseSelectable = true;
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox1.Location = new System.Drawing.Point(139, 58);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.Size = new System.Drawing.Size(145, 23);
            this.metroTextBox1.TabIndex = 1;
            this.metroTextBox1.Text = "metroTextBox1";
            this.metroTextBox1.UseSelectable = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(382, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(536, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // metroTile7
            // 
            this.metroTile7.ActiveControl = null;
            this.metroTile7.Location = new System.Drawing.Point(1002, 32);
            this.metroTile7.Name = "metroTile7";
            this.metroTile7.Size = new System.Drawing.Size(83, 56);
            this.metroTile7.TabIndex = 25;
            this.metroTile7.Text = "admin";
            this.metroTile7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile7.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile7.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile7.UseCustomForeColor = true;
            this.metroTile7.UseSelectable = true;
            this.metroTile7.Click += new System.EventHandler(this.metroTile7_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1370, 761);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.metroTile7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.progressIdentify);
            this.Controls.Add(this.metroTile6);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Thumb_photo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.User_photo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void DisplayErrorMsg(string msg, uint ret)
        {
            labStatus.Text = msg + NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]";
        }

        DataTable dt = new DataTable();
        int i, j;
        private void Form1_Load(object sender, System.EventArgs e)
        {
            panel12.Hide();
            metroTile7.Hide();
            pictureBox2.Hide();
            panel4.Hide();
            panel1.Hide();
            panel3.Hide();
            panel6.Hide();
            panel7.Hide();
            panel11.Hide();
            metroTile6.Hide();
            metroTile1.Show();
            metroTextBox12.PasswordChar = '*';
            metroTextBox12.MaxLength = 12;
            metroButton7.Enabled = false;
            metroButton6.Enabled = false;


            dt.Columns.Add("Citizen_ID",typeof(int));

            dt.Columns.Add("First_Name",typeof(String));
            dt.Columns.Add("Middle_Name", typeof(String));
            dt.Columns.Add("Last_Name",typeof(string));




            // Enumerate Device
            int i;
            uint nNumDevice;
            short[] nDeviceID;
            uint ret = m_NBioAPI.EnumerateDevice(out nNumDevice, out nDeviceID, out m_DeviceInfoEx);
            DisplayErrorMsg("", ret);

            comboDevice.Items.Add("Auto_Detect");
            for (i = 0; i < nNumDevice; i++)
            {
                comboDevice.Items.Add(m_DeviceInfoEx[i].Name + " (ID:" + m_DeviceInfoEx[i].Instance.ToString("D2") + ")");
            }

            // Set default value
            comboDevice.SelectedIndex = 0;
            buttonRollCapture1.Enabled = false;
            buttonRollCapture2.Enabled = false;

            labStatus.Text = "NBioBSP Init success !";

            // for webcam initialization
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                comboBoxCameras.Items.Add(VideoCaptureDevice.Name);
            }
            comboBoxCameras.SelectedIndex = 0;

            //for list database initialization

            uint reti = m_IndexSearch.InitEngine();
            if (reti != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(reti);
            }






            listSearchDB.Items.Clear();
            uint load = NBioAPI.Error.NONE;





            string szFileName = @"C:\Users\suip\Documents\Visual Studio 2013\Projects\infosys\db\dtdb.ISDB";
            if (szFileName != "")
            {
                // Clear ListView of SearchDB
                listSearchDB.Items.Clear();
                // Clear IndexSearchDB
                m_IndexSearch.ClearDB();

                // Load SearchDB from File
                load = m_IndexSearch.LoadDBFromFile(szFileName);
                if (load != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(load);
                    return;
                }

                listSearchDB.Items.Clear();

                // Load list from file
                szFileName = Path.ChangeExtension(szFileName, "FID");

                FileStream fs = new FileStream(szFileName, FileMode.Open, FileAccess.Read);
                StreamReader fr = new StreamReader(fs);

                while (fr.Peek() >= 0)
                {
                    try
                    {
                        string szLine = fr.ReadLine();
                        string[] szSplit = szLine.Split('\t');
                        ListViewItem listItem = new ListViewItem();
                        listItem.Text = szSplit[0];
                        listItem.SubItems.Add(szSplit[1]);
                        listItem.SubItems.Add(szSplit[2]);
                        listSearchDB.Items.Add(listItem);
                    }
                    catch
                    {
                        break;
                    }
                }

                fr.Close();
                fs.Close();

                // MessageBox.Show("Load SearchDB to file success!");
            }
            else
            {
                MessageBox.Show("You must enter filename !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DisplayErrorMsg(uint ret)
        {
            MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void Form1_Closed(object sender, System.EventArgs e)
        {
            // Close Device
            m_NBioAPI.CloseDevice(m_OpenedDeviceID);
        }

        private void buttonExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void buttonOpen_Click(object sender, System.EventArgs e)
        {
            short iDeviceID = NBioAPI.Type.DEVICE_ID.AUTO;

            // Select device type
            if (comboDevice.SelectedIndex > 0)
                iDeviceID = (short)(m_DeviceInfoEx[comboDevice.SelectedIndex - 1].NameID + (m_DeviceInfoEx[comboDevice.SelectedIndex - 1].Instance << 8));
            else
                iDeviceID = NBioAPI.Type.DEVICE_ID.AUTO;

            // Close Device if before opened
            m_NBioAPI.CloseDevice(m_OpenedDeviceID);

            // Open device
            uint ret = m_NBioAPI.OpenDevice(iDeviceID);
            if (ret == NBioAPI.Error.NONE)
            {
                m_OpenedDeviceID = iDeviceID;

                buttonRollCapture1.Enabled = true;
                buttonRollCapture2.Enabled = true;



                labStatus.Text = "Device Open Success yahoo! - ";

                if (comboDevice.SelectedIndex > 0)
                    labStatus.Text += m_DeviceInfoEx[comboDevice.SelectedIndex - 1].Description;
                else
                    labStatus.Text += "Auto Detect Device";
            }
            else
            {
                DisplayErrorMsg("Device Open Failed! - ", ret);
            }
        }

        private void buttonRollCapture_Click(object sender, System.EventArgs e)
        {

            NBioAPI.Type.WINDOW_OPTION WinOption = new NBioAPI.Type.WINDOW_OPTION();
            NBioAPI.Type.HFIR hAudit = new NBioAPI.Type.HFIR();

            uint rez = m_NBioAPI.Capture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out m_hNewFIR, 20000, hAudit, WinOption);

            if (rez == NBioAPI.Error.NONE)
            {
                NBioAPI.Export.EXPORT_AUDIT_DATA exportData;
                uint ret = m_Export.NBioBSPToImage(hAudit, out exportData);
                int nWidth = (int)exportData.ImageWidth;
                int nHeight = (int)exportData.ImageHeight;

                if (ret == NBioAPI.Error.NONE)
                {
                    Bitmap bmp = new Bitmap(nWidth, nHeight, PixelFormat.Format8bppIndexed);
                    BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                    System.Runtime.InteropServices.Marshal.Copy(exportData.AuditData[0].Image[0].Data, 0, data.Scan0, nWidth * nHeight);
                    bmp.UnlockBits(data);

                    ColorPalette GrayscalePalette = bmp.Palette;

                    for (int i = 0; i < 256; i++)
                        GrayscalePalette.Entries[i] = Color.FromArgb(i, i, i);

                    bmp.Palette = GrayscalePalette;
                    Thumb_photo.Image = bmp;
                    // bmp.Save("RollImage.bmp");
                    // MessageBox.Show("successfully produced");

                }
                else
                {
                    //MessageBox.Show("problem making bmp");
                }



            }
            else
            {
                //MessageBox.Show("there was error outside");
            }













            try
            {
                if (Thumb_photo.Image != null)
                {


                    MemoryStream stream = new MemoryStream();
                    Thumb_photo.Image.Save(stream, ImageFormat.Jpeg);

                    byte[] pic = stream.ToArray();


                    SqlConnection con = new SqlConnection(@"Data Source=XOX;Initial Catalog=xxx;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Table_2(ID,thumb) VALUES(@a,@b)", con);
                    cmd.Parameters.AddWithValue("@a", TextBox1.Text);


                    cmd.Parameters.Add(new SqlParameter("@b", pic));

                    cmd.ExecuteNonQuery();


                    MessageBox.Show("saved successfully to database");
                }
                else
                {
                    MessageBox.Show("image is empty");

                }




            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }
        }







        private void comboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // panel1.Visible = !panel3.Visible;
            panel1.Hide();
            panel3.Show();
        }



        private void metroButton10_Click_1(object sender, EventArgs e)
        {
            panel3.Hide();
            panel1.Show();
            if (pictureBox4.Image != null)
            {
                FinalVideo.Stop();
            }

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBoxCameras.SelectedIndex].MonikerString);
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            FinalVideo.Start();
            metroButton7.Enabled = true;
            metroButton6.Enabled = true;
        }
        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            pictureBox4.Image = video;
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {

            if (FinalVideo.IsRunning == true)
            {
                FinalVideo.Stop();
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Save(@"C:\Users\suip\Documents\Visual Studio 2013\Projects\infosys\webcam\picture.jpg", ImageFormat.Jpeg);
                SaveSatus.Text = "successfully saved to drive !";
            }
            else
            {
                //exception
            }

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {


            pictureBox3.Image = (Bitmap)pictureBox4.Image.Clone();
            User_photo.Image = (Bitmap)pictureBox4.Image.Clone();

        }

        private void buttonRollCapture_Click_1(object sender, EventArgs e)
        {
            NBioAPI.Type.WINDOW_OPTION WinOption = new NBioAPI.Type.WINDOW_OPTION();
            NBioAPI.Type.HFIR hAudit = new NBioAPI.Type.HFIR();

            uint rez = m_NBioAPI.Capture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out m_hNewFIR, 20000, hAudit, WinOption);

            if (rez == NBioAPI.Error.NONE)
            {
                NBioAPI.Export.EXPORT_AUDIT_DATA exportData;
                uint ret = m_Export.NBioBSPToImage(hAudit, out exportData);
                int nWidth = (int)exportData.ImageWidth;
                int nHeight = (int)exportData.ImageHeight;

                if (ret == NBioAPI.Error.NONE)
                {
                    Bitmap bmp = new Bitmap(nWidth, nHeight, PixelFormat.Format8bppIndexed);
                    BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                    System.Runtime.InteropServices.Marshal.Copy(exportData.AuditData[0].Image[0].Data, 0, data.Scan0, nWidth * nHeight);
                    bmp.UnlockBits(data);

                    ColorPalette GrayscalePalette = bmp.Palette;

                    for (int i = 0; i < 256; i++)
                        GrayscalePalette.Entries[i] = Color.FromArgb(i, i, i);

                    bmp.Palette = GrayscalePalette;
                    Thumb_photo.Image = bmp;
                    labStatus.Text = "Scan Successfull.";
                    m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                    // bmp.Save("RollImage.bmp");
                    // MessageBox.Show("successfully produced");

                }
                else
                {
                    //MessageBox.Show("problem making bmp");
                }



            }
            else
            {
                //MessageBox.Show("there was error outside");
            }














        }

        private void buttonOpen_Click_1(object sender, EventArgs e)
        {
            short iDeviceID = NBioAPI.Type.DEVICE_ID.AUTO;

            // Select device type
            if (comboDevice.SelectedIndex > 0)
                iDeviceID = (short)(m_DeviceInfoEx[comboDevice.SelectedIndex - 1].NameID + (m_DeviceInfoEx[comboDevice.SelectedIndex - 1].Instance << 8));
            else
                iDeviceID = NBioAPI.Type.DEVICE_ID.AUTO;

            // Close Device if before opened
            m_NBioAPI.CloseDevice(m_OpenedDeviceID);

            // Open device
            uint ret = m_NBioAPI.OpenDevice(iDeviceID);
            if (ret == NBioAPI.Error.NONE)
            {
                m_OpenedDeviceID = iDeviceID;
                buttonRollCapture2.Enabled = true;
                buttonRollCapture1.Enabled = true;
                labStatus.Text = "Device Open Success yahoo! - ";

                if (comboDevice.SelectedIndex > 0)
                    labStatus.Text += m_DeviceInfoEx[comboDevice.SelectedIndex - 1].Description;
                else
                    labStatus.Text += "Auto Detect Device";
            }
            else
            {
                DisplayErrorMsg("Device Open Failed! - ", ret);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            //f.InitialDirectory = "c:/Picture/";
            f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gig";
            //f.FilterIndex = 2;
            if (f.ShowDialog() == DialogResult.OK)
            {
                //textBox3.Text = f.FileName;
                User_photo.Image = Image.FromFile(f.FileName);
                User_photo.SizeMode = PictureBoxSizeMode.StretchImage;
                // pictureBox1.BorderStyle = BorderStyle.Fixed3D;

            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            uint dest = NBioAPI.Error.NONE;

            string szFileName = @"C:\Users\suip\Desktop\db\dtdb.ISDB";
            if (szFileName != "")
            {
                // Save SearchDB to File
                dest = m_IndexSearch.SaveDBToFile(szFileName);
                if (dest != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(dest);
                    return;
                }

                // Save list to file
                szFileName = Path.ChangeExtension(szFileName, "FID");

                FileStream fs = new FileStream(szFileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter fw = new StreamWriter(fs);

                for (int i = 0; i < listSearchDB.Items.Count; i++)
                {
                    fw.WriteLine(listSearchDB.Items[i].Text + "\t" + listSearchDB.Items[i].SubItems[1].Text + "\t" + listSearchDB.Items[i].SubItems[2].Text);
                }

                fw.Close();
                fs.Close();

                MessageBox.Show("Save SearchDB to file success!");
            }
            else
            {
                MessageBox.Show("You must enter filename !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            try
            {
                if (User_photo.Image != null)
                {


                    MemoryStream stream1 = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    User_photo.Image.Save(stream1, ImageFormat.Jpeg);
                    Thumb_photo.Image.Save(stream2, ImageFormat.Jpeg);

                    byte[] pic1 = stream1.ToArray();
                    byte[] pic2 = stream2.ToArray();


                    SqlConnection con = new SqlConnection(@"Data Source=XOX;Initial Catalog=student;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO info1(Citizen_no,First_Name,Middle_Name,Last_Name,Gender,DOB,Email,Country,Zone,District,Municipality,VDC,Ward_no,Photo,Thumb) VALUES(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o)", con);
                    cmd.Parameters.AddWithValue("@a", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@b", First_Name.Text);
                    cmd.Parameters.AddWithValue("@c", Middle_Name.Text);
                    cmd.Parameters.AddWithValue("@d", metroTextBox13.Text);
                    if (radioButton1.Checked)
                    {
                        cmd.Parameters.AddWithValue("@e", "male");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@e", "female");
                    }
                    cmd.Parameters.AddWithValue("@f", DOB.Text);

                    cmd.Parameters.AddWithValue("@g", metroTextBox10.Text);
                    cmd.Parameters.AddWithValue("@h", metroTextBox14.Text);
                    cmd.Parameters.AddWithValue("@i", metroTextBox5.Text);
                    cmd.Parameters.AddWithValue("@j", metroTextBox6.Text);
                    cmd.Parameters.AddWithValue("@k", metroTextBox7.Text);
                    cmd.Parameters.AddWithValue("@l", metroTextBox8.Text);
                    cmd.Parameters.AddWithValue("@m", metroTextBox9.Text);
                    cmd.Parameters.Add(new SqlParameter("@n", pic1));
                    cmd.Parameters.Add(new SqlParameter("@o", pic2));
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("hel loooo");
                }
                else
                {
                    MessageBox.Show("image is empty");

                }




            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }





        }



        private void metroButton9_Click(object sender, EventArgs e)
        {
            {
                NBioAPI.Type.HFIR hNewFIR;
                uint nUserID = 0;
                // Get User ID
                try
                {
                    int test = Convert.ToInt32(TextBox1.Text, 10);
                    if (test == 0)
                        throw (new Exception());
                }
                catch
                {
                    MessageBox.Show("User ID must be have numeric type and greater than 0.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                nUserID = Convert.ToUInt32(TextBox1.Text, 10);

                // Get FIR data
                m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                uint ret = m_NBioAPI.Enroll(out hNewFIR, null);
                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                    return;
                }

                // m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);

                // Regist FIR to IndexSearch DB
                NBioAPI.IndexSearch.FP_INFO[] fpInfo;
                ret = m_IndexSearch.AddFIR(hNewFIR, nUserID, out fpInfo);
                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    return;
                }

                // Add item to list of SearchDB
                foreach (NBioAPI.IndexSearch.FP_INFO sampleInfo in fpInfo)
                {
                    ListViewItem listItem = new ListViewItem();
                    listItem.Text = sampleInfo.ID.ToString();
                    listItem.SubItems.Add(sampleInfo.FingerID.ToString());
                    listItem.SubItems.Add(sampleInfo.SampleNumber.ToString());
                    listSearchDB.Items.Add(listItem);
                }
                MessageBox.Show(TextBox1.Text);
            }
        }

        private void metroButton9_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            
            panel4.Show();
            panel5.Hide();
            panel3.Hide();
            panel2.Hide();
            panel1.Hide();
            panel6.Hide();
            metroLabel1.Text = "normal";

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel5.Show();
            panel7.Hide();
            metroLabel1.Text = "normal";

        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(metroTextBox3.Text == string.Empty))
                {
                    if (!(metroTextBox12.Text == string.Empty))
                    {
                        String str = "Data Source=XOX;Initial Catalog=xxx;Integrated Security=True";
                        String query = "select * from admins where UserName = '" + this.metroTextBox3.Text + "'and Password = '" + this.metroTextBox12.Text + "'";
                        SqlConnection con = new SqlConnection(str);
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader dbr;
                        con.Open();
                        dbr = cmd.ExecuteReader();
                        int count = 0;
                        while (dbr.Read())
                        {
                            count = count + 1;
                        }
                        if (count == 1)
                        {
                            pictureBox2.Show();
                            panel2.Visible = !panel2.Visible;
                            metroTextBox3.Clear();
                            metroTextBox12.Clear();
                            panel4.Hide();
                            panel6.Show();
                            metroTile1.Hide();
                            metroTile6.Show();
                            metroTile7.Show();
                            panel12.Show();
                            metroLabel1.Text = "signed in successfully...";

                            // MessageBox.Show("username and password is correct");
                        }
                        else if (count > 1)
                        {
                            metroLabel1.Text = "Duplicate username and password";
                            metroLabel1.Show();
                        }
                        else
                        {

                            metroLabel1.Text = " the username and password is incorrect please check them again  !!!";
                            metroLabel1.Show();

                        }
                    }
                    else
                    {
                        metroLabel1.Text = "password is empty !!!";
                        metroLabel1.Show();

                    }
                }

                else
                {
                    metroLabel1.Text = " username is empty !!!";
                    metroLabel1.Show();

                }
                // con.Close();

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);

            }
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            panel1.Show();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {

            if (!(search_text.Text == string.Empty))
            {

                var a = search_text.Text;

                try
                {
                    String str = "Data Source=XOX;Initial Catalog=student;Integrated Security=True";
                    String query = "select * from info1 where Citizen_no =" + a;
                    SqlConnection con = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dbr;
                    con.Open();
                    dbr = cmd.ExecuteReader();
                    int count = 0;
                    while (dbr.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {

                        //MessageBox.Show("citizen found..");

                        metroLabel1.Text = "citizen found......";
                        profile_form frm = new profile_form();
                        frm.id = search_text.Text;
                        frm.Show();

                    }

                    else
                    {
                        metroLabel1.Text = "no citizen found; data has not been registered";
                        metroLabel1.Text = "listing matching attributes...........";

                        internet_search_form frm = new internet_search_form();
                        frm.id = search_text.Text;
                        frm.Show();
                    }


                }
                catch (Exception)
                {
                    // MessageBox.Show(es.Message);
                    metroLabel1.Text = "no citizen found; data has not been registered";
                    metroLabel1.Text = "listing matching attributes...........";

                    internet_search_form frm = new internet_search_form();
                    frm.id = search_text.Text;
                    frm.Show();
                }


            }
            else
            {
                metroLabel1.Text = "type citizen no. or name";
            }

        }

        public uint myCallback(ref NBioAPI.IndexSearch.CALLBACK_PARAM_0 cbParam0, IntPtr userParam)
        {
            progressIdentify.Value = Convert.ToInt32(cbParam0.ProgressPos);
            return NBioAPI.IndexSearch.CALLBACK_RETURN.OK;
        }
        private void metroButton13_Click(object sender, EventArgs e)
        {


            NBioAPI.Type.HFIR hCapturedFIR;



            // Get FIR data
            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            uint ret = m_NBioAPI.Capture(out hCapturedFIR);
            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                return;
            }

            m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);


            uint nMax;
            m_IndexSearch.GetDataCount(out nMax);
            progressIdentify.Minimum = 0;
            progressIdentify.Maximum = Convert.ToInt32(nMax);

            NBioAPI.IndexSearch.CALLBACK_INFO_0 cbInfo0 = new NBioAPI.IndexSearch.CALLBACK_INFO_0();
            cbInfo0.CallBackFunction = new NBioAPI.IndexSearch.INDEXSEARCH_CALLBACK(myCallback);

            // Identify FIR to IndexSearch DB
            NBioAPI.IndexSearch.FP_INFO fpInfo;
            ret = m_IndexSearch.IdentifyData(hCapturedFIR, NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL, out fpInfo, cbInfo0);
            if (ret != NBioAPI.Error.NONE)
            {
                //   DisplayErrorMsg("Match not found!!", ret);
                // MessageBox.Show("Match not found");
                metroLabel1.Text = "match not found.......";
                return;
            }
            else
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = fpInfo.ID.ToString();
                //    MessageBox.Show(listItem.Text);
                var a = listItem.Text;
                if (a != null)
                {
                    metroLabel1.Text = "match found successfully..";

                    // MessageBox.Show("Match found...");

                    profile_form frm = new profile_form();

                    frm.id = listItem.Text;

                    frm.Show();



                }




                //MessageBox.Show("match found");

            }










        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            panel4.Show();
            panel5.Hide();
            panel3.Hide();
            panel2.Hide();
            panel1.Hide();
            panel6.Hide();
            metroLabel1.Text = "normal";
            metroTile6.Hide();
            metroTile1.Show();
            pictureBox2.Hide();
            metroTile7.Hide();
        }

        private void listSearchDB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();
                metroTextBox1.Text = row.Cells["First_Name"].Value.ToString();

            }
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Rows.Add(metroTextBox1.Text, metroTextBox2.Text, metroTextBox4.Text, metroTextBox11.Text);

                dataGridView1.DataSource = dt;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                dataGridView1.DataSource = dt;

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            panel6.Show();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            panel6.Show();
        }


    }
}
