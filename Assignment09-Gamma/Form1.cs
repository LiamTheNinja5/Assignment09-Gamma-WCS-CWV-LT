using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment09_Gamma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void standardFormSetup(Button btnAccept, Button btnCancel)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            this.MaximizeBox = false;
            //this.Size = new Size(300,300)
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.CancelButton = btnCancel;
            this.AcceptButton = btnAccept;
            this.Text = System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace + " - WCS - CWV - LT";
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
