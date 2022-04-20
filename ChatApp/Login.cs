using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApp.Models;
using ChatApp.LoginData;

namespace ChatApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
        private LoginModel GetLoginModel(string user, string pass)
        {
            LoginModel lgm = new LoginModel();
            lgm.username = user;
            lgm.password = pass;
            return lgm;
        }

        private async Task<bool> ValidateCreateCreds(LoginModel lgm)
        {
            bool IsValid = false;
            string caption = "ERROR!";
            MessageBoxButtons btns = MessageBoxButtons.OK;
            if (lgm.username.Length > 50) MessageBox.Show("Only 50 Charaters allowed for the username", caption, btns);
            else if (lgm.password.Length > 50) MessageBox.Show("Only 50 Charaters allowed for the password", caption, btns);
            else if (string.IsNullOrEmpty(lgm.username) || string.IsNullOrWhiteSpace(lgm.username)) MessageBox.Show("Enter Username", caption, btns);
            else if (string.IsNullOrEmpty(lgm.password) || string.IsNullOrWhiteSpace(lgm.password)) MessageBox.Show("Enter Password", caption, btns);
            else if ((await Queries.GetUserFromDB(lgm, false)).Count > 0) MessageBox.Show("Username already exists", caption, btns);
            else IsValid =  true;
            return IsValid;
        }

        private bool ValidateLoginCreds(LoginModel lgm)
        {
            bool IsValid = false;
            string caption = "ERROR!";
            MessageBoxButtons btns = MessageBoxButtons.OK;
            if (string.IsNullOrEmpty(lgm.username) || string.IsNullOrWhiteSpace(lgm.username)) MessageBox.Show("Enter Username", caption, btns);
            else if (string.IsNullOrEmpty(lgm.password) || string.IsNullOrWhiteSpace(lgm.password)) MessageBox.Show("Enter Password", caption, btns);
            else IsValid = true;
            return IsValid;
        }

        private async void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            LoginModel logm = GetLoginModel(UsernameInput.Text, PasswordInput.Text);
            if(await ValidateCreateCreds(logm))
            {
                await Queries.InsertUser(logm);
                MessageBox.Show("Account Created\nPlease Log in", "success", MessageBoxButtons.OK);
            }
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            LoginModel logm = GetLoginModel(UsernameInput.Text, PasswordInput.Text);
            if(ValidateLoginCreds(logm))
            {
                List<LoginModel> LoginList = await Queries.GetUserFromDB(logm, true);
                if (LoginList.Count > 0)
                {
                    Globals.UserID = LoginList[0].iid;
                    MessageBox.Show("Logged in", "success", MessageBoxButtons.OK);
                    Globals.MainWindow.ChatWindowPanel.Controls.Remove(this);
                    this.Dispose();
                    ChatWindow cw = new ChatWindow();
                    cw.TopLevel = false;
                    cw.AutoScroll = true;
                    Globals.MainWindow.ChatWindowPanel.Controls.Add(cw);
                    cw.FormBorderStyle = FormBorderStyle.None;
                    cw.Dock = DockStyle.Fill;
                    cw.Show();

                }
                else
                {
                    MessageBox.Show("Not a valid login", "ERROR!", MessageBoxButtons.OK);
                }
            }
        }


    }
}
