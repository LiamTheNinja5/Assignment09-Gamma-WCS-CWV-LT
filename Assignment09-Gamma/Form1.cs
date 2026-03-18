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
        // Lists that contain the data that the user will pick from.
        List<Bread> breadList = new List<Bread>();
        List<SandwichFilling> fillingList = new List<SandwichFilling>();
        List<Condiment> condimentList = new List<Condiment>();
        // User's sandwich that they are building.
        Sandwich sandwich;

        // load the data from the files into the lists depending on the file name.
        // the files need to be named "bread.txt", "filling.txt", and "condiments.txt" for the program to work correctly.
        // the file should be in the debug directory, and should be in the format of "name-calories" on each line.
        private void fillFromFile(string myFileName)
        {
            StreamReader inputFile;
            if (File.Exists(myFileName))
            {
                inputFile = File.OpenText(myFileName);
                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    string[] data = line.Split('-');
                    switch (myFileName)
                    {
                        case "bread.txt":
                            breadList.Add(new Bread(data[0], int.Parse(data[1])));
                            break;
                        case "fillings.txt":
                            fillingList.Add(new SandwichFilling(data[0], int.Parse(data[1])));
                            break;
                        case "condiments.txt":
                            condimentList.Add(new Condiment(data[0], int.Parse(data[1])));
                            break;
                        default:
                            MessageBox.Show("File name is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                    }
                }
                inputFile.Close();
            }
            else
            {
                MessageBox.Show(myFileName + " does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // set the form up to be ready for the user to use it, hiding all the panels.
        private void fourmSetup()
        {
            pnlFilling.Visible = false;
            pnlCondiments.Visible = false;
            pnlButtons.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            standardFormSetup(btnSubmit, btnExit);
            fourmSetup();

            // fill the lists with the data from the files.
            fillFromFile("bread.txt");
            fillFromFile("fillings.txt");
            fillFromFile("condiments.txt");

            // set the data source for the combo boxes to the lists.
            cmbBread.DataSource = breadList;
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
