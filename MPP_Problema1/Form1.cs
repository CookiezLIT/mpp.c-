using MPP_Problema1.Service;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPP_Problema1
{
    public partial class Form1 : Form
    {

        public readonly UserService _userService;
        public readonly FlightService _flightService;

        public Form1(UserService userServ, FlightService flightServ)
        {
            //_userService = Program.GetService<UserService>();
            _userService = userServ;
            _flightService = flightServ;
            InitializeComponent();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            bool login = _userService.LogInAsync(UsernameInput.Text, PasswordInput.Text);
            if (login)
            {
                var main  = new MainForm(this._flightService);
                main.Visible = true;
                main.Show();
            }
            else
            {
                throw new Exception("LOGIN FAILED");
            }
        }

        
    }
}
