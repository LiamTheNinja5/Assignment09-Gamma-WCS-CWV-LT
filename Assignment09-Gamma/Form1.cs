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

        // Which step the user is on in the form.
        int fourmIndex;

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
            // Disable and set the default text of the combo boxes and checked list box.
            cmbBread.Enabled = false;
            cmbBread.Text = "Select a bread";

            cmbFilling.Enabled = false;
            cmbFilling.Text = "Select a filling";

            cxbCondiments.Enabled = false;

            btnSubmit.Text = "&Start";
            btnSubmit.Enabled = true;

            btnExit.Text = "&Exit";

            fourmIndex = 0;

            // set the sandwich to a new sandwich object (this way it can be reset).
            sandwich = new Sandwich();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            standardFormSetup(btnSubmit, btnExit);

            // fill the lists with the data from the files.
            fillFromFile("bread.txt");
            fillFromFile("fillings.txt");
            fillFromFile("condiments.txt");

            // set the data source of the combo boxes and checked list box to the lists.
            cmbBread.DataSource = breadList;
            cmbFilling.DataSource = fillingList;
            cxbCondiments.DataSource = condimentList;

            fourmSetup();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnExit.Text == "&Exit")
            {
                Close();
            }

            if (btnExit.Text == "&Restart")
            {
                fourmSetup();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            // Index 0: User has not started.
            // Index 1: User has selected bread
            // Index 2: User has selected bread and filling.
            // Index 3: User has selected bread, filling, condiments. Show the order summary to the user.
            // Index 4: Start the program over again.

            switch (fourmIndex)
            {
                // Enable Bread
                case 0:
                    cmbBread.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbBread.Enabled = true;

                    btnSubmit.Enabled = false;
                    btnSubmit.Text = "&Next";
                    break;
                // Disable Bread, Enable fillings
                case 1:
                    cmbBread.Enabled = false;
                    cmbFilling.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbFilling.Enabled = true;
                    btnSubmit.Enabled = false;
                    break;
                // Disable fillings, enable condiments
                case 2:
                    cmbFilling.Enabled = false;
                    cxbCondiments.Enabled = true;
                    btnSubmit.Text = "&Submit";
                    break;
                // Disable condiments, create the sandwich object, and show the order summary to the user.
                case 3:
                    cxbCondiments.Enabled = false;

                    // Create the sandwich object with the user's selections.
                    sandwich = new Sandwich((Bread)cmbBread.SelectedItem, (SandwichFilling)cmbFilling.SelectedItem, cxbCondiments.CheckedItems.Cast<Condiment>().ToList());


                    // Calculate the total calories of the condiments.
                    double condimentsTotal = 0;

                    foreach (var c in sandwich.getCondiments())
                    {
                        condimentsTotal += c.getCalories();
                    }

                    // Get the total calories of the sandwich by adding the calories of the bread, filling, and condiments.
                    double totalCal = sandwich.getBread().getCalories() + sandwich.getFilling().getCalories() + condimentsTotal;


                    //get the names of the condiments into a string
                    List<Condiment> condiments = sandwich.getCondiments();
                    string condimentNames = "";
                    if (condiments.Count > 0)
                    {
                        for (int i = 0; i < condiments.Count; i++)
                        {
                            condimentNames = condimentNames + (" " + condiments[i].getName());
                        }
                    }
                    else
                    {
                        condimentNames = "no condiments";
                    }
                    // Show order summary to the user with the total calories of the sandwich.
                    btnSubmit.Text = "&Finish";
                    MessageBox.Show("Your bread is: " + "(" + sandwich.getBread() + ")" + ". Your filling is: " + "(" + sandwich.getFilling() + ")" + ". Your condiments are: " + "(" + condimentNames + ")" + ". For a total of " + totalCal + " calories.", "Sandwich Calories", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 4:
                    //Exit the program, and show the slogan.
                    MessageBox.Show("Thank you for eating with us! Remember to keep calm and sandwich on!", "Thank you!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    break;
            }


            fourmIndex++;
        }

        private void cmbBread_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Allow the user to move on after they have made a selection.
            btnSubmit.Enabled = true;

        }

        private void cmbFilling_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Allow the user to move on after they have made a selection.
            btnSubmit.Enabled = true;
        }
    }


}


/* 
    Assignemnt 09 - William Sneller - La'Trell Thomas - Caroline Voorheis    

What concepts did your team find challenging about this program? (Please be specific)
    - we found commentting our code to be challenging, as when working with others you need comments to explain what your code is doing.

What did your team learn in this program? (Please be specific)
    - we learned how to work with others on programming projects.

*/