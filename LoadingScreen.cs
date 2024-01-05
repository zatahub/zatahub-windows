using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZataHub.Properties;

namespace ZataHub
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void lblTestSpeakerAndMicrophone_MouseHover(object sender, EventArgs e)
        {
            lblTestSpeakerAndMicrophone.ForeColor = ColorTranslator.FromHtml("#fc8328");
        }

        private void lblTestSpeakerAndMicrophone_MouseLeave(object sender, EventArgs e)
        {
            lblTestSpeakerAndMicrophone.ForeColor = ColorTranslator.FromHtml("#FF6D00");
        }

        private void LoadingScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e) { }

        #region Minimized Button

        #region Panel
        private void pnlMinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlMinimizeButton_MouseHover(object sender, EventArgs e)
        {
            pnlMinimizeButton.BackColor = ColorTranslator.FromHtml("#FF6D00");
        }

        private void pnlMinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            pnlMinimizeButton.BackColor = Color.White;
        }
        #endregion

        #region PictureBox
        private void pcbMinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pcbMinimizeButton_MouseHover(object sender, EventArgs e)
        {
            pnlMinimizeButton.BackColor = ColorTranslator.FromHtml("#FF6D00");
        }

        #endregion

        #endregion

        #region Resize Button

        #region Panel
        private void pnlResizeButton_MouseHover(object sender, EventArgs e)
        {
            pnlResizeButton.BackColor = ColorTranslator.FromHtml("#FF6D00");
        }

        private void pnlResizeButton_MouseLeave(object sender, EventArgs e)
        {
            pnlResizeButton.BackColor = Color.White;
        }

        private void pnlResizeButton_Click(object sender, EventArgs e) { }
        #endregion

        #region PictureBox
        private void pcbResizeButton_MouseHover(object sender, EventArgs e)
        {
            pnlResizeButton.BackColor = ColorTranslator.FromHtml("#FF6D00");
        }

        private void pcbResizeButton_MouseLeave(object sender, EventArgs e)
        {
            pnlResizeButton.BackColor = Color.White;
        }
        #endregion

        #endregion

        #region Close Button

        #region Panel
        private void pnlCloseButton_MouseLeave(object sender, EventArgs e)
        {
            pnlCloseButton.BackColor = Color.White;
        }

        private void pnlCloseButton_MouseHover(object sender, EventArgs e)
        {
            //pnlCloseButton.BackColor = ColorTranslator.FromHtml("#FF6D00");
            pnlCloseButton.BackColor = Color.Red;
        }

        private void pnlCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region PictureBox
        private void pcbCloseButton_MouseHover(object sender, EventArgs e)
        {
            //pnlCloseButton.BackColor = ColorTranslator.FromHtml("#FF6D00");
            pnlCloseButton.BackColor = Color.Red;
        }

        private void pcbCloseButton_MouseLeave(object sender, EventArgs e)
        {
            pnlCloseButton.BackColor = Color.White;
        }

        private void pcbCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #endregion

        #region TitleBarPositionMove

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void tblTitleBarLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        private void lblTestSpeakerAndMicrophone_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                Resources.IsNotImplementedMessage,
                Resources.IsNotImplementedCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
