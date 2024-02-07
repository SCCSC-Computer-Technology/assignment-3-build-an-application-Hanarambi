using System;
using System.Windows.Forms;
using System.Linq;

namespace russo50states
{
    public partial class EditStateForm : Form
    {
        private State _currentState; // Holds the current state being edited, null if adding

        // Constructor for adding a new state
        public EditStateForm()
        {
            InitializeComponent();
            _currentState = null; // Adding a new state
            SetupFormForAddNew();
        }

        // Constructor for editing an existing state
        public EditStateForm(State stateToEdit)
        {
            InitializeComponent();
            _currentState = stateToEdit;
            SetupFormForEdit(stateToEdit);
        }

        private void SetupFormForAddNew()
        {
            this.Text = "Add New State";
            buttonDelete.Enabled = true; 
        }

        private void SetupFormForEdit(State state)
        {
            this.Text = "Edit State";
            // Populate the controls with the state's data
            textBoxState.Text = state.Name;
            textBoxCapitol.Text = state.Capitol;
            numericUpDownPopulation.Value = state.Population.HasValue ? (decimal)state.Population.Value : 0;
            numericUpDownMedianIncome.Value = state.MedianIncome.HasValue ? (decimal)state.MedianIncome.Value : 0;
            numericUpDownComputerJobs.Value = state.ComputerJobsPercentage.HasValue ? (decimal)state.ComputerJobsPercentage.Value : 0;
            textBoxFlag.Text = state.FlagDescription;
            textBoxLargestCitite.Text = state.LargestCities;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var db = new DataClasses1DataContext()) // Assuming DataClasses1DataContext is your DataContext
            {
                if (_currentState == null)
                {
                    // Adding a new state
                    _currentState = new State()
                    {
                        Name = textBoxState.Text,
                        Capitol = textBoxCapitol.Text,
                        Population = Convert.ToInt32(numericUpDownPopulation.Value),
                        MedianIncome = Convert.ToInt32(numericUpDownMedianIncome.Value),
                        ComputerJobsPercentage = (double?)Convert.ToDouble(numericUpDownComputerJobs.Value), // conversion to double
                        FlagDescription = textBoxFlag.Text,
                        LargestCities = textBoxLargestCitite.Text
                    };
                    db.States.InsertOnSubmit(_currentState); // Add the new state to the database
                }
                else
                {
                    
                    var stateToUpdate = db.States.Where(s => s.Id == _currentState.Id).SingleOrDefault(); 
                    if (stateToUpdate != null)
                    {
                        // Update the state's properties
                        stateToUpdate.Name = textBoxState.Text;
                        stateToUpdate.Capitol = textBoxCapitol.Text;
                        stateToUpdate.Population = Convert.ToInt32(numericUpDownPopulation.Value);
                        stateToUpdate.MedianIncome = Convert.ToInt32(numericUpDownMedianIncome.Value);
                        stateToUpdate.ComputerJobsPercentage = (double?)Convert.ToDouble(numericUpDownComputerJobs.Value); // Explicit conversion to double
                        stateToUpdate.FlagDescription = textBoxFlag.Text;
                        stateToUpdate.LargestCities = textBoxLargestCitite.Text;
                    }
                }

                db.SubmitChanges(); // Commit the changes to the database
            }

           
            if (Application.OpenForms["UpdateStatesForm"] is UpdateStatesForm form)
            {
                form.LoadStatesData(); 
            }

            this.DialogResult = DialogResult.OK; 
            this.Close(); 
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_currentState == null)
            {
                MessageBox.Show("No state selected to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this state?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                using (var db = new DataClasses1DataContext())
                {
                    var stateToDelete = db.States.FirstOrDefault(s => s.Id == _currentState.Id);
                    if (stateToDelete != null)
                    {
                        db.States.DeleteOnSubmit(stateToDelete);
                        db.SubmitChanges();

                        // After deleting, refresh the DataGridView on UpdateStatesForm
                        if (Application.OpenForms["UpdateStatesForm"] is UpdateStatesForm form)
                        {
                            form.LoadStatesData();
                        }

                        MessageBox.Show("State deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("State not found or already deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}

