using MPP_Problema1.Service;
using System;
using System.Windows.Forms;

namespace MPP_Problema1
{
    public partial class Form1 : Form
    {

        public UserService UserServ { get; set; }
        public Form1(UserService serv)
        {
            UserServ = serv;
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool login = UserServ.LogIn(UsernameInput.Text, PasswordInput.Text);
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
