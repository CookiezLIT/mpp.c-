using MPP_Problema1.Model;
using MPP_Problema1.Service;
using SimpleSql;
using System.ComponentModel;
using System.Windows.Forms;

namespace MPP_Problema1
{
    public partial class MainForm : Form
    {
        private FlightService _flightService;
        private DataGridView _dataGridView = new DataGridView();
        public MainForm(FlightService flightServ)
        {
            InitializeComponent();

            this._flightService = flightServ;

            var flights = _flightService.GetFlights();

            //for (int i = 0; i < flights.Count; i++)
            //{
            //    var flight = flights[i];
            //    dataGridView1.Rows.Add();
            //}

        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            
           
            
            //var bindnigList = new BindingList<Flight>(_flightService.GetFlights());
            //var source = new BindingSource(bindnigList, null);
            // _dataGridView.DataSource = source;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
