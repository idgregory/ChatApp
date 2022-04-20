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
        private List<Recipient> RecipientList = null;
        private Recipient CurrRecipient = null;
        public ChatWindow()
        {
            InitializeComponent();
        }

        private async Task LoadMessagesFromCurrRecipient()
        {

        }

        private async Task LoadRecipientComboBox()
        {
            RecipientList = await Queries.GetListOfUsers(Globals.UserID);
            foreach (Recipient r in RecipientList)
                RecipientComboBox.Items.Add(r.username);
            RecipientComboBox.SelectedIndex = 0;
            CurrRecipient = RecipientList[0];
        }

        private async Task LoadChatBox(List<Models.Message> msgs)
        {
            foreach(Models.Message msg in msgs)
            {
                string username = await Queries.GetUserName(msg.fk_users_from);
                ChatLogInput.Text += $"{username}: {msg.message} \r\n";
            }
        }

        private async void ChatWindow_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            await LoadRecipientComboBox();
            List<Models.Message> MessageList = await Queries.LoadMessages(Globals.UserID, CurrRecipient.iid);
            await LoadChatBox(MessageList);


        }

        private async void SendBtn_Click(object sender, EventArgs e)
        {
            string input = SendInput.Text;
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) return;
            await Queries.InsertMessage(Globals.UserID, CurrRecipient.iid, input);

        }

        private async void RecipientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChatLogInput.Text = "";
            CurrRecipient = RecipientList[RecipientComboBox.SelectedIndex];
            List<Models.Message> MessageList = await Queries.LoadMessages(Globals.UserID, CurrRecipient.iid);
            await LoadChatBox(MessageList);
        }
    }
}
