using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApp.ChatData;
using ChatApp.Models;

namespace ChatApp
{
    public partial class ChatWindow : Form
    {
        public ChatWindow()
        {
            InitializeComponent();
        }

        private async void LoadRecipientComboBox()
        {
            List<Recipient> RecipientList = await Queries.GetListOfUsers(Globals.UserID);
            foreach (Recipient r in RecipientList)
                RecipientComboBox.Items.Add(r.username);
            RecipientComboBox.SelectedIndex = 0;
        }

        private async void ChatWindow_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            LoadRecipientComboBox();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {

        }

    }
}
