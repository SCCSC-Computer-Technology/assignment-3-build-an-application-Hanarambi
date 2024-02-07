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
using System.Diagnostics;


namespace russo50states
{
    public partial class UpdateStatesForm : Form
    {
        // Fields in Form2 to store the state of checkboxes
       // private bool filterByPopulation = false;
       // private bool filterByCapital = false;
       // private bool filterByMedianIncome = false;
        //private bool filterByStateBird = false;
       // private bool filterByTechJob = false;
       // private bool filterByFlagDescription = false;
        //private bool filterByLargestCities = false;

        bool sidebarExpand;
        public UpdateStatesForm()
        {
            InitializeComponent();
            this.Load += UpdateStatesForm_Load;
        }

        public void LoadStatesData()
        {
            using (var db = new DataClasses1DataContext())
            {
                stateDataGridView.DataSource = db.States.ToList();
            }
        }

        private void UpdateStatesForm_Load(object sender, EventArgs e)
        {
            LoadStatesData();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                // Expand the sidebar
                sidebar.Width += 10; 
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebarTimer.Stop(); 
                }
            }
            else
            {
                // Collapse the sidebar
                sidebar.Width -= 10; 
                if (sidebar.Width <= sidebar.MinimumSize.Width)
                {
                    sidebarTimer.Stop(); 
                }
            }
        }


        private void menuButton_Click(object sender, EventArgs e)
        {
           //sexy sidebar,  still have not got it to work exactly the way i want it, but hey this is my first time
            sidebarExpand = !sidebarExpand;
            sidebarTimer.Start();
        }


        private void searchBut_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            if (searchForm.ShowDialog() == DialogResult.OK)
            {
                string searchTerms = searchForm.SearchTerms;
                PerformSearchAndGenerateHtml(searchTerms);
            }
        }

        internal void UpdateDataGridView()
        {
            throw new NotImplementedException();
        }

        private void PerformSearchAndGenerateHtml(string searchTerms)
        {
            var terms = searchTerms.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            using (var db = new DataClasses1DataContext())
            {
                var query = db.States.AsQueryable();

                foreach (var term in terms)
                {
                   //search funtions for database output
                    query = query.Where(s => s.Name.Contains(term) ||
                                             s.Capitol.Contains(term) ||
                                             s.StateBird.Contains(term) ||
                                             s.StateFlower.Contains(term) ||                                             
                                             (s.FlagDescription != null && s.FlagDescription.Contains(term)) ||
                                             (s.Colors != null && s.Colors.Contains(term)) ||
                                             (s.LargestCities != null && s.LargestCities.Contains(term)) ||
                                             (s.MedianIncome.ToString().Contains(term)) ||
                                             (s.ComputerJobsPercentage != null && s.ComputerJobsPercentage.ToString().Contains(term)));
                }

                var results = query.ToList();

                if (results.Any())
                {
                    GenerateHtml(results);
                }
                else
                {
                    MessageBox.Show("No results found.");
                }
            }
        }

        private void GenerateHtml(List<State> results)
        {
            string filePath = Path.Combine(Path.GetTempPath(), "SearchResults.html");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("<html><head><title>Search Results</title></head><body>");
                writer.WriteLine("<h1>Search Results</h1>");
                writer.WriteLine("<ul>");

                foreach (var state in results)
                {
                    
                    writer.WriteLine($"<li>Name: {state.Name}, Capitol: {state.Capitol}, State Bird: {state.StateBird}, State Flower: {state.StateFlower}, Population: {state.Population}, etc.</li>");
                }

                writer.WriteLine("</ul>");
                writer.WriteLine("</body></html>");
            }

            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            SortForm sortForm = new SortForm();
            if (sortForm.ShowDialog() == DialogResult.OK)
            {
                SortData(sortForm.SortColumn, sortForm.SortAscending);
            }
        }
        private void SortData(string sortColumn, bool ascending)
        {
            using (var db = new DataClasses1DataContext())
            {
                var query = db.States.AsQueryable();

                switch (sortColumn)
                {
                    case "State":
                        query = ascending ? query.OrderBy(s => s.Name) : query.OrderByDescending(s => s.Name);
                        break;
                    case "Population":
                        query = ascending ? query.OrderBy(s => s.Population) : query.OrderByDescending(s => s.Population);
                        break;
                    case "MedianIncome":
                       
                        query = ascending ? query.OrderBy(s => s.MedianIncome ?? 0) : query.OrderByDescending(s => s.MedianIncome ?? 0);
                        break;
                    case "ComputerJobPercentage":
                        
                        query = ascending ? query.OrderBy(s => s.ComputerJobsPercentage ?? 0) : query.OrderByDescending(s => s.ComputerJobsPercentage ?? 0);
                        break;
                }

                // Update DataGridView
                stateDataGridView.DataSource = query.ToList();
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            using (var filterForm = new FilterForm())
            {
                if (filterForm.ShowDialog() == DialogResult.OK)
                {
                    ApplyFilters(filterForm);
                }
            }
        }

        private void ApplyColumnVisibility(FilterForm filterForm)
        {

            stateDataGridView.Columns["Population"].Visible = filterForm.FilterByPopulation;
            stateDataGridView.Columns["Capitol"].Visible = filterForm.FilterByCapital;
            stateDataGridView.Columns["MedianIncome"].Visible = filterForm.FilterByMedianIncome;
            stateDataGridView.Columns["StateBird"].Visible = filterForm.FilterByStateBird;
            stateDataGridView.Columns["TechJobPercentage"].Visible = filterForm.FilterByTechJob;
            stateDataGridView.Columns["FlagDescription"].Visible = filterForm.FilterByFlagDescription;
            stateDataGridView.Columns["LargestCities"].Visible = filterForm.FilterByLargestCities;
        

           
        }

        private void ApplyFilters(FilterForm filterForm)
        {
            using (var db = new DataClasses1DataContext())
            {
                var query = db.States.AsQueryable();

                if (!string.IsNullOrEmpty(filterForm.SelectedState) && filterForm.SelectedState != "All States")
                {
                    query = query.Where(state => state.Name == filterForm.SelectedState);
                }

                if (filterForm.FilterByPopulation)
                {
                    query = query.Where(state => state.Population.HasValue && state.Population > 0);
                }

                if (filterForm.FilterByCapital)
                {
                    query = query.Where(state => state.Capitol != null && state.Capitol != "");
                }

                if (filterForm.FilterByMedianIncome)
                {
                    query = query.Where(state => state.MedianIncome.HasValue && state.MedianIncome > 0);
                }

                if (filterForm.FilterByStateBird)
                {
                    query = query.Where(state => state.StateBird != null && state.StateBird != "");
                }

                if (filterForm.FilterByTechJob)
                {
                    query = query.Where(state => state.ComputerJobsPercentage.HasValue && state.ComputerJobsPercentage > 0);
                }

                if (filterForm.FilterByFlagDescription)
                {
                    query = query.Where(state => state.FlagDescription != null && state.FlagDescription != "");
                }

                if (filterForm.FilterByLargestCities)
                {
                    query = query.Where(state => state.LargestCities != null && state.LargestCities != "");
                }

                stateDataGridView.DataSource = query.ToList();

            }
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            EditStateForm editForm = new EditStateForm(); 
            var dialogResult = editForm.ShowDialog(); 
            
            if (dialogResult == DialogResult.OK)
            {
               
                LoadStatesData(); 
            }
        }











        private void UpdateDataGridView(List<State> filteredStates)
        {
            stateDataGridView.DataSource = filteredStates;
        }


       //


    }
}

