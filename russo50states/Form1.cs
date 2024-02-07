using System;//           John Russo cpt 206  the bomb
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace russo50states
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            fittyStatescomboBox.SelectedIndexChanged += fittyStatescomboBox_SelectedIndexChanged;// this is for my panel as button mouse hover change color

            selectState.MouseEnter += SelectState_MouseEnter;
            selectState.MouseLeave += SelectState_MouseLeave;
            selectState.Click += SelectState_Click;
            label1.MouseEnter += SelectState_MouseEnter;
            label1.MouseLeave += SelectState_MouseLeave;//                                         all of this all of it.  dont be Jelly
            label2.MouseEnter += OpenStateWiki_MouseEnter;
            label2.MouseLeave += OpenStateWiki_MouseLeave;
            labelUpdateStates.MouseEnter += UpdateStatesPanel_MouseEnter;
            labelUpdateStates.MouseLeave += UpdateStatesPanel_MouseLeave;
            labelUpdateStates.Click += UpdateStatesPanel_Click;
            updateStatesPanel.MouseEnter += UpdateStatesPanel_MouseEnter;
            updateStatesPanel.MouseLeave += UpdateStatesPanel_MouseLeave;
            updateStatesPanel.Click += UpdateStatesPanel_Click;

            openStateWiki.MouseEnter += OpenStateWiki_MouseEnter;
            openStateWiki.MouseLeave += OpenStateWiki_MouseLeave;
            openStateWiki.MouseClick += OpenStateWiki_Click;
            updateStatesPanel.BackColor = Color.LightGray;

            selectState.BackColor = Color.LightGray;
            openStateWiki.BackColor = Color.LightGray;

            openStateWiki.MouseClick += OpenStateWiki_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStatesIntoComboBox(); // Populate the ComboBox with state names
            LoadStatesData(); // Initially load all states data into the DataGridView
        }

        private void LoadStatesIntoComboBox()
        {
            using (var db = new DataClasses1DataContext())
            {
                var stateNames = db.States
                                   .OrderBy(state => state.Name) // Good practice to sort names
                                   .Select(state => state.Name)
                                   .ToList();

                fittyStatescomboBox.DataSource = stateNames;
            }
        }

        private void LoadStatesData(string selectedStateName = null)// more loading states into the datagrid
        {
            using (var db = new DataClasses1DataContext())
            {
                var statesQuery = string.IsNullOrEmpty(selectedStateName)
                    ? db.States.ToList()
                    : db.States.Where(state => state.Name.Equals(selectedStateName)).ToList();

                stateDataGridView.DataSource = statesQuery;
            }
        }

        private void fittyStatescomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fittyStatescomboBox.SelectedIndex >= 0) // Ensure an item is selected
            {
                var selectedStateName = fittyStatescomboBox.SelectedItem.ToString();
                LoadStatesData(selectedStateName); // Filter data in DataGridView based on selected state
            }
        }

        private void SelectState_MouseEnter(object sender, EventArgs e)
        {
            selectState.BackColor = Color.BlueViolet; // Hover color
        }



        private void SelectState_MouseLeave(object sender, EventArgs e)
        {
            selectState.BackColor = Color.LightGray; // Revert to original color
        }

        private void SelectState_Click(object sender, EventArgs e)
        {
            if (fittyStatescomboBox.SelectedIndex >= 0) // Ensure a state is selected
            {
                var selectedStateName = fittyStatescomboBox.SelectedItem.ToString();
                GenerateAndOpenHTML(selectedStateName); // Generate and open the HTML document
            }
        }

        private void UpdateStatesPanel_Click(object sender, EventArgs e)
        {
            UpdateStatesForm updateForm = new UpdateStatesForm();
            updateForm.Show(); // Just what it says
        }


        private void UpdateStatesPanel_MouseEnter(object sender, EventArgs e)
        {
            updateStatesPanel.BackColor = Color.BlueViolet; // Hover color
        }

        private void UpdateStatesPanel_MouseLeave(object sender, EventArgs e)
        {
            updateStatesPanel.BackColor = Color.LightGray; // Revert to original color
        }

        private void OpenStateWiki_MouseEnter(object sender, EventArgs e)
        {
            openStateWiki.BackColor = Color.BlueViolet; 
        }

        private void OpenStateWiki_MouseLeave(object sender, EventArgs e)
        {
            openStateWiki.BackColor = Color.LightGray; // Revert to the default color
        }


        private void OpenStateWiki_Click(object sender, EventArgs e)
        {
            if (fittyStatescomboBox.SelectedIndex >= 0) // Ensure a state is selected
            {
                var selectedStateName = fittyStatescomboBox.SelectedItem.ToString();
                var wikiUrl = $"https://en.wikipedia.org/wiki/{selectedStateName.Replace(" ", "_")}";

                try
                {
                    Process.Start(new ProcessStartInfo(wikiUrl) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not open the Wikipedia page: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a state first.");
            }
        }

        private void GenerateAndOpenHTML(string stateName)
        {
            string filePath = Path.Combine(Path.GetTempPath(), $"{stateName}.html");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("<html><body>");
                writer.WriteLine($"<h1>Details for {stateName}</h1>");

                using (var db = new DataClasses1DataContext())
                {
                    var stateData = db.States.FirstOrDefault(state => state.Name.Equals(stateName));
                    if (stateData != null)
                    {
                        writer.WriteLine($"<p><b>Name:</b> {stateData.Name}</p>");
                        writer.WriteLine($"<p><b>Population:</b> {stateData.Population}</p>");
                        writer.WriteLine($"<p><b>Flag Description:</b> {stateData.FlagDescription}</p>");
                        writer.WriteLine($"<p><b>State Flower:</b> {stateData.StateFlower}</p>");
                        writer.WriteLine($"<p><b>State Bird:</b> {stateData.StateBird}</p>");
                        writer.WriteLine($"<p><b>Colors:</b> {stateData.Colors}</p>");
                        writer.WriteLine($"<p><b>Largest Cities:</b> {stateData.LargestCities}</p>");
                        writer.WriteLine($"<p><b>Capitol:</b> {stateData.Capitol}</p>");
                        writer.WriteLine($"<p><b>Median Income:</b> {stateData.MedianIncome}</p>");
                        writer.WriteLine($"<p><b>Computer Jobs Percentage:</b> {stateData.ComputerJobsPercentage}%</p>");
                    }
                    else
                    {
                        writer.WriteLine("<p>State data not found.</p>");
                    }
                }

                writer.WriteLine("</body></html>");
            }

            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
