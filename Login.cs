using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZataHub.Properties;

namespace ZataHub
{
    public partial class frmLogin : Form
    {
        const string _messageIdPlaceHolderText = "Enter meeting ID:";

        public frmLogin()
        {
            InitializeComponent();

            this.txtJoin.Text = _messageIdPlaceHolderText;
        }

        private void tblLogin_Paint(object sender, PaintEventArgs e) { }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //InitRoundBorders();
            //txtJoin.Text = "Enter Meeting Id ";
            //txtJoin.ForeColor = ColorTranslator.FromHtml("#736D83");
        }

        void InitRoundBorders()
        {
            //control card
            GraphicsPath gp = CreatePath(
                new Rectangle(Point.Empty, tblLoginInputBorder.Size),
                20,
                false
            );
            Region rg = new Region(gp);
            tblLoginInputBorder.Region = rg;

            //login input table border
            gp = null;
            rg = new Region();
            gp = CreatePath(new Rectangle(Point.Empty, tblLoginInputBorder.Size), 10, false);
            rg = new Region(gp);
            tblLoginInputBorder.Region = rg;
        }

        public static GraphicsPath CreatePath(Rectangle rect, int nRadius, bool bOutline)
        {
            int nShift = bOutline ? 1 : 0;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X + nShift, rect.Y, nRadius, nRadius, 180f, 90f);
            path.AddArc((rect.Right - nRadius) - nShift, rect.Y, nRadius, nRadius, 270f, 90f);
            path.AddArc(
                (rect.Right - nRadius) - nShift,
                (rect.Bottom - nRadius) - nShift,
                nRadius,
                nRadius,
                0f,
                90f
            );
            path.AddArc(
                rect.X + nShift,
                (rect.Bottom - nRadius) - nShift,
                nRadius,
                nRadius,
                90f,
                90f
            );
            path.CloseFigure();
            return path;
        }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void SetJoinButtonEnabled(bool flag)
        {
            btnJoin.BackgroundImage = flag
                ? ZataHub.Properties.Resources.btnJoin
                : ZataHub.Properties.Resources.btnJoinDisabled;
            btnJoin.Enabled = flag;
        }

        private bool IsValidMeetingID(string meetingID)
        {
            return meetingID.Length == 7 && meetingID.All(char.IsDigit);
        }

        private void txtJoin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtJoin.Text.Equals(_messageIdPlaceHolderText))
            {
                txtJoin.Text = "";
            }
        }

        private void txtJoin_KeyUp(object sender, KeyEventArgs e)
        {
            SetJoinButtonEnabled(IsValidMeetingID(this.txtJoin.Text));
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (txtJoin.Text.Length >= 7)
            {
                this.Visible = false;
                LoadingScreen loadingScreen = new LoadingScreen();
                loadingScreen.Show();
            }
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmSignUp frmSignUp = new frmSignUp();
            frmSignUp.ShowDialog();
        }

        private void lblSignUp_MouseHover(object sender, EventArgs e)
        {
            lblSignUp.ForeColor = ColorTranslator.FromHtml("#fc8328");
        }

        private void lblSignUp_MouseLeave(object sender, EventArgs e)
        {
            lblSignUp.ForeColor = ColorTranslator.FromHtml("#FF6D00");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtJoin_Enter(object sender, EventArgs e) { }

        #region TitleBarPositionMove

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frmLogin_MouseDown(object sender, MouseEventArgs e) { }

        private void tblTitleBarLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

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

        private void pcbResizeButton_Click(object sender, EventArgs e) { }
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

        private void tblTitleBar_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                Resources.IsNotImplementedMessage,
                Resources.IsNotImplementedCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void pictureBox5_Click(object sender, EventArgs e)
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
