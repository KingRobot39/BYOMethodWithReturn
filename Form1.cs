using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carcostcomparison___dylan_hughes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //constants
        //declair required constants
        const decimal fuelconst = 2.50m;
        const decimal milesperyearconst = 12000;

        private void calculatebutton_Click(object sender, EventArgs e)
        {
            //input
            //declair A LOT of variables
            decimal mpgc1V = 0;
            decimal mpgc2V = 0;
            decimal totalfuelcostc1V = 0;
            decimal totalfuelcostc2V = 0;
            decimal purchasepricec1V = 0;
            decimal purchasepricec2V = 0;
            decimal repaircostc1V = 0;
            decimal repaircostc2V = 0;
            decimal insurancecostc1V = 0;
            decimal insurancecostc2V = 0;
            decimal totalcostc1V = 0;
            decimal totalcostc2V = 0;

            //try/catch to make sure numbers are entered in required textboxes
            //parses each input
            try
            {
                mpgc1V = decimal.Parse(mpgc1box.Text);
                mpgc2V = decimal.Parse(mpgc2box.Text);
                purchasepricec1V = decimal.Parse(purchasepricec1box.Text);
                purchasepricec2V = decimal.Parse(purchasepricec2box.Text);
                repaircostc1V = decimal.Parse(repaircostc1box.Text);
                repaircostc2V = decimal.Parse(repaircostc2box.Text);
                insurancecostc1V = decimal.Parse(insurancecostc1box.Text);
                insurancecostc2V = decimal.Parse(insurancecostc2box.Text);
            }

            catch
            {
                MessageBox.Show("Please enter each cars requested information.");
                return;
            }

            //processing
            //formulas to calculate requested information
            totalfuelcostc1V = dylanhughesMETHODCalc1YearFuelCost(milesperyearconst, fuelconst, mpgc1V);
            totalfuelcostc2V = dylanhughesMETHODCalc1YearFuelCost(milesperyearconst, fuelconst, mpgc2V);
            totalcostc1V = purchasepricec1V + 5 * (totalfuelcostc1V + repaircostc1V + insurancecostc1V);
            totalcostc2V = purchasepricec2V + 5 * (totalfuelcostc2V + repaircostc2V + insurancecostc2V);


            //output
            //displays results of above calculations in the correct labels
            c1fuelcostlabel.Text = totalfuelcostc1V.ToString("c");
            c2fuelcostlabel.Text = totalfuelcostc2V.ToString("c");
            c1allcostlabel.Text = totalcostc1V.ToString("c");
            c2allcostlabel.Text = totalcostc2V.ToString("c");

            //colors higher cost label red
            if (totalcostc1V > totalcostc2V)
            {
                c1allcostlabel.BackColor = Color.Red;
            }

            else
            {
                c2allcostlabel.BackColor = Color.Red;
            }
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            //clears all textboxes
            mpgc1box.Text = "";
            mpgc2box.Text = "";
            purchasepricec1box.Text = "";
            purchasepricec2box.Text = "";
            repaircostc1box.Text = "";
            repaircostc2box.Text = "";
            insurancecostc1box.Text = "";
            insurancecostc2box.Text = "";
            c1fuelcostlabel.Text = "";
            c2fuelcostlabel.Text = "";
            c1allcostlabel.Text = "";
            c2allcostlabel.Text = "";

            //reverts label colors back to default
            c1allcostlabel.BackColor = default(Color);
            c2allcostlabel.BackColor = default(Color);

        }

        private decimal dylanhughesMETHODCalc1YearFuelCost(decimal milesdriven, decimal fulecost, decimal carmpg)
        {
            decimal yearlyfulecostout = 0;

            yearlyfulecostout = (milesdriven / carmpg) * fulecost;

            return yearlyfulecostout;
        }
    }
}
