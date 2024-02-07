using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace russo50states
{
    public partial class SortForm : Form
    {
        public bool SortAscending { get; private set; }
        public string SortColumn { get; private set; }

        public SortForm()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (yoMama.Checked)
            {

                System.Diagnostics.Process.Start("https://ponly.com/yo-mama-jokes/");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {

                SortAscending = radioButtonAsc.Checked;

                // Determine sort column
                if (radioButtonState.Checked) SortColumn = "State";
                else if (radioButtonPopulation.Checked) SortColumn = "Population";
                else if (radioButtonMedIncome.Checked) SortColumn = "MedianIncome";
                else if (radioButtonCompJobPercent.Checked) SortColumn = "ComputerJobPercentage";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
       
        }

    }
