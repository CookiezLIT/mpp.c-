using MPP_Problema1.Model;
using MPP_Problema1.Service;
using SimpleSql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MPP_Problema1
{
    public partial class MainForm : Form
    {
        private FlightService _flightService;
        private List<Flight> _flights;
        public MainForm(FlightService flightServ)
        {
            InitializeComponent();

            this._flightService = flightServ;

            _flights = _flightService.GetFlights();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            for (int i = 0; i < _flights.Count; i++)
            {
                var flight = _flights[i];
                dataGridView1.Rows.Add(flight.Id, flight.Departure, flight.Destination, flight.DepartureDateTime, flight.ArrivalDateTime, flight.Capacity);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonStartCautare_Click(object sender, System.EventArgs e)
        {
            Cautare form = new Cautare(_flightService);
            form.ShowDialog();
        }
    }
}
