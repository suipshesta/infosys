using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using NITGEN.SDK.NBioBSP;

namespace BSPRollDemoCS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      NBioAPI                       m_NBioAPI;
      NBioAPI.Export                m_Export;

      short	                        m_OpenedDeviceID;
      NBioAPI.Type.HFIR	            m_hNewFIR;
      NBioAPI.Type.DEVICE_INFO_EX[] m_DeviceInfoEx;

      
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.PictureBox staticFP;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox comboDevice;
      private System.Windows.Forms.Button buttonOpen;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Button buttonRollCapture;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.Button buttonVerify;
      private System.Windows.Forms.Button buttonExit;
      private System.Windows.Forms.Label labStatus;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
         m_NBioAPI = new NBioAPI();
         m_Export = new NBioAPI.Export(m_NBioAPI);

         m_OpenedDeviceID = NBioAPI.Type.DEVICE_ID.NONE;
         m_hNewFIR = null;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.buttonOpen = new System.Windows.Forms.Button();
         this.comboDevice = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.buttonExit = new System.Windows.Forms.Button();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this.buttonVerify = new System.Windows.Forms.Button();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.buttonRollCapture = new System.Windows.Forms.Button();
         this.staticFP = new System.Windows.Forms.PictureBox();
         this.labStatus = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox4.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.buttonOpen);
         this.groupBox1.Controls.Add(this.comboDevice);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(8, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(648, 56);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Device function";
         // 
         // buttonOpen
         // 
         this.buttonOpen.Location = new System.Drawing.Point(416, 16);
         this.buttonOpen.Name = "buttonOpen";
         this.buttonOpen.Size = new System.Drawing.Size(216, 32);
         this.buttonOpen.TabIndex = 2;
         this.buttonOpen.Text = "Open";
         this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
         // 
         // comboDevice
         // 
         this.comboDevice.Location = new System.Drawing.Point(107, 21);
         this.comboDevice.Name = "comboDevice";
         this.comboDevice.Size = new System.Drawing.Size(293, 21);
         this.comboDevice.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(64, 23);
         this.label1.TabIndex = 0;
         this.label1.Text = "Device List";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.buttonExit);
         this.groupBox2.Controls.Add(this.groupBox4);
         this.groupBox2.Controls.Add(this.groupBox3);
         this.groupBox2.Controls.Add(this.staticFP);
         this.groupBox2.Location = new System.Drawing.Point(8, 72);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(648, 496);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Capture function";
         // 
         // buttonExit
         // 
         this.buttonExit.Location = new System.Drawing.Point(440, 448);
         this.buttonExit.Name = "buttonExit";
         this.buttonExit.Size = new System.Drawing.Size(192, 40);
         this.buttonExit.TabIndex = 3;
         this.buttonExit.Text = "Exit";
         this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this.buttonVerify);
         this.groupBox4.Location = new System.Drawing.Point(432, 128);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(208, 72);
         this.groupBox4.TabIndex = 2;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Verify";
         // 
         // buttonVerify
         // 
         this.buttonVerify.Enabled = false;
         this.buttonVerify.Location = new System.Drawing.Point(8, 24);
         this.buttonVerify.Name = "buttonVerify";
         this.buttonVerify.Size = new System.Drawing.Size(192, 40);
         this.buttonVerify.TabIndex = 0;
         this.buttonVerify.Text = "Verify";
         this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.buttonRollCapture);
         this.groupBox3.Location = new System.Drawing.Point(432, 32);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(208, 72);
         this.groupBox3.TabIndex = 1;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Roll Capture";
         // 
         // buttonRollCapture
         // 
         this.buttonRollCapture.Enabled = false;
         this.buttonRollCapture.Location = new System.Drawing.Point(8, 24);
         this.buttonRollCapture.Name = "buttonRollCapture";
         this.buttonRollCapture.Size = new System.Drawing.Size(192, 40);
         this.buttonRollCapture.TabIndex = 0;
         this.buttonRollCapture.Text = "Roll Capture Start";
         this.buttonRollCapture.Click += new System.EventHandler(this.buttonRollCapture_Click);
         // 
         // staticFP
         // 
         this.staticFP.BackColor = System.Drawing.SystemColors.GrayText;
         this.staticFP.Location = new System.Drawing.Point(11, 24);
         this.staticFP.Name = "staticFP";
         this.staticFP.Size = new System.Drawing.Size(416, 464);
         this.staticFP.TabIndex = 0;
         this.staticFP.TabStop = false;
         // 
         // labStatus
         // 
         this.labStatus.Location = new System.Drawing.Point(8, 576);
         this.labStatus.Name = "labStatus";
         this.labStatus.Size = new System.Drawing.Size(648, 24);
         this.labStatus.TabIndex = 2;
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(664, 613);
         this.Controls.Add(this.labStatus);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.Closed += new System.EventHandler(this.Form1_Closed);
         this.groupBox1.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox4.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.ResumeLayout(false);

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

      private void Form1_Load(object sender, System.EventArgs e)
      {
         NBioAPI.Type.VERSION version = new NBioAPI.Type.VERSION();
         m_NBioAPI.GetVersion(out version);

         Text = String.Format("BSP Demo for C#.NET (BSP Version : v{0}.{1:D4})", version.Major, version.Minor);

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
    
         buttonRollCapture.Enabled = false;
         buttonVerify.Enabled = false;

         labStatus.Text = "NBioBSP Init success !";
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
            buttonRollCapture.Enabled = true;
            labStatus.Text = "Device Open Success! - ";

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
         NBioAPI.Type.WINDOW_OPTION WinOption;
         NBioAPI.Type.HFIR hAudit;

         WinOption = new NBioAPI.Type.WINDOW_OPTION();
         hAudit = new NBioAPI.Type.HFIR();

         WinOption.WindowStyle = NBioAPI.Type.WINDOW_STYLE.INVISIBLE;
         WinOption.FingerWnd = staticFP.Handle;

         if (m_hNewFIR != null)
         {
            // Free native memory
            m_hNewFIR.Dispose();
            m_hNewFIR = null;
         }

         uint ret = m_NBioAPI.RollCapture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out m_hNewFIR, 20000, hAudit, WinOption);

         if (ret == NBioAPI.Error.NONE)
         {
            // If you want to save fir data then this FIR data write to DB or File.
            NBioAPI.Export.EXPORT_AUDIT_DATA exportData;

            ret = m_Export.NBioBSPToImage(hAudit, out exportData);

            if (ret == NBioAPI.Error.NONE)  {
               int nWidth = (int) exportData.ImageWidth;
               int nHeight = (int) exportData.ImageHeight;

               {     // raw image save...
                  FileStream fout; 
 
                  fout = new FileStream("RollImage.raw", FileMode.Create); 
                  fout.Write(exportData.AuditData[0].Image[0].Data, 0, nWidth * nHeight);
                  fout.Close();
               }

               {     // bmp image save...
                  Bitmap bmp = new Bitmap(nWidth, nHeight, PixelFormat.Format8bppIndexed);
                  BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

                  System.Runtime.InteropServices.Marshal.Copy(exportData.AuditData[0].Image[0].Data, 0, data.Scan0, nWidth * nHeight);
                  bmp.UnlockBits(data);

                  ColorPalette GrayscalePalette = bmp.Palette;

                  for (int i = 0; i < 256; i++)
                     GrayscalePalette.Entries[i] = Color.FromArgb(i, i, i);

                  bmp.Palette = GrayscalePalette;

                  bmp.Save("RollImage.bmp");
               }
            }

            // Free native memory
            hAudit.Dispose();

            labStatus.Text = "Roll Capture Function Success!";
            buttonVerify.Enabled = true;
         } 
         else 
         {
            DisplayErrorMsg("Roll Capture Function Failed! - ", ret);
         }
      }

      private void buttonVerify_Click(object sender, System.EventArgs e)
      {
         // Check exist enrolled fingerprint
         if (m_hNewFIR == null)
         {
            MessageBox.Show("Can not find enrolled fingerprint!");
            return;
         }

         uint ret;
         bool result;

         // Verify
         ret = m_NBioAPI.Verify(m_hNewFIR, out result, null);
    
         if (ret != NBioAPI.Error.NONE)
         {
            DisplayErrorMsg("Verify Function Failed! - ", ret);
            return;
         }

         // Check result of verify
         if (result)
         {
            MessageBox.Show("Verify Success!", "BSP Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            labStatus.Text = "Verify Success!";
         } 
         else 
         {
            // Show fail message.
            MessageBox.Show("Verify Failed!", "BSP Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            labStatus.Text= "Verify Failed!";
         }
      }

	}
}
