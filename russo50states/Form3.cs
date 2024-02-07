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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        
            private void kryptonSearchButton_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.OK; // Set the dialog result
                this.Close(); // Close the form to return control to Form2
            }

        public string SearchTerms
        {
            get { return textBoxSearchTerms.Text; }
        }

    }
}
