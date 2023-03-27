using MPP_Problema1.Model;
using MPP_Problema1.Service;
using SimpleSql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace MPP_Problema1
{
    public partial class Cautare : Form
    {
        private FlightService _flightService;
        private List<Flight> _flights;
        public Cautare(FlightService flightServ)
        {
            InitializeComponent();

            this._flightService = flightServ;

            _flights = _flightService.GetFlights();

            this.FlightDateTimePicker.CustomFormat = "dd/MM/yyyy hh:mm";
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            UpdateTable(_flights);

        }

        private void UpdateTable(List<Flight> flights)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < flights.Count; i++)
            {
                var flight = flights[i];
                dataGridView1.Rows.Add(flight.Id, flight.Departure, flight.Destination, flight.DepartureDateTime, flight.ArrivalDateTime, flight.Capacity);
            }
        }

        private void buttonCauta_Click(object sender, System.EventArgs e)
        {
            var departure = departureTextBox.Text;
            var departureDateTime = FlightDateTimePicker.Value;

            var result = _flights.Where(f => f.Departure == departure && f.DepartureDateTime > departureDateTime).ToList();

            UpdateTable(result);
        }
    }
}
