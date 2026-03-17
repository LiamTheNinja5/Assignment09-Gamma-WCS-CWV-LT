using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        List<Bread> employees = new List<Bread>();

        private void fillFromFile(string myFileName, ref string[] myArray)
        {
            StreamReader inputFile;
            if (File.Exists(myFileName))
            {
                inputFile = File.OpenText(myFileName);
                while (!inputFile.EndOfStream)
                {
                    myArray = addElement(myArray);
                    myArray[myArray.Length - 1] = inputFile.ReadLine().ToUpper();
                }
                inputFile.Close();
            }
            else
            {
                MessageBox.Show(myFileName + " does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fourmSetup()
        {
            pnlBread.Visible = false;
            pnlFilling.Visible = false;
            pnlCondiments.Visible = false;
            pnlButtons.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            standardFormSetup(btnSubmit, btnExit);
            fourmSetup();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(cmbBread.SelectedItem == null || cmbFilling.SelectedItem == null)
            {
                MessageBox.Show("Please select a bread and a filling");
            }
            //Part 2
            
        }
    }

    
}
