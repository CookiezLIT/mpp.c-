using MPP_Problema1.Model;
using MPP_Problema1.Service;
using SimpleSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MPP_Problema1
{
    public partial class MainForm : Form
    {
        private FlightService _flightService;
        private FlightTicketService _flightTicketService;
        private List<Flight> _flights;
        public MainForm(FlightService flightServ, FlightTicketService flightTicketService)
        {
            InitializeComponent();

            this._flightService = flightServ;

            this._flightTicketService = flightTicketService;
            
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            UpdateDataTable();

        }

        private void UpdateDataTable()
        {
            _flights = _flightService.GetFlights();
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

        private void buyButton_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                Guid flight_id = (Guid) row.Cells["id"].Value;

                string name = nameInput.Text;
                string email = emailInput.Text;
                string address = addressInput.Text;

                bool result = this._flightTicketService.BuyTicketForClient(flight_id, name, email, address);

                if (result)
                {
                    UpdateDataTable();
                }
            }
        }

    
    }
}
