using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            Login LoginForm = new Login();
            LoginForm.TopLevel = false;
            LoginForm.AutoScroll = true;
            this.ChatWindowPanel.Controls.Add(LoginForm);
            LoginForm.FormBorderStyle = FormBorderStyle.None;
            LoginForm.Dock = DockStyle.Fill;
            LoginForm.Show();
        }

    }
}
