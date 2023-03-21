using MPP_Problema1.Service;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPP_Problema1
{
    public partial class Form1 : Form
    {

        public readonly UserService _userService;

        public Form1()
        {
            _userService = Program.GetService<UserService>();
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

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            bool login = await _userService.LogInAsync(UsernameInput.Text, PasswordInput.Text);
            if (login)
            {
                throw new Exception("LOGIN SUCCESS!");
            }
            else
            {
                throw new Exception("LOGIN FAILED");
            }
        }

        
    }
}
