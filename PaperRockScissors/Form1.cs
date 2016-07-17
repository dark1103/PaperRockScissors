using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace PaperRockScissors
{
    public partial class Form1 : Form
    {
        private ClientOnSide client;
        public Form1()
        {
            InitializeComponent();
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            imageList.Images.Add("Empty_Image", PaperRockScissors.Properties.Resources.Image_Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Disconnect();
                client = null;
            }
            else
            {
                client = ClientOnSide.Create(Host_Textbox.Text, 7777, Name_Textbox.Text);
                if (client != null)
                {
                    client.OnPlayersListChanged = OnPlayersListChanged;
                    client.OnBegin = OnBegin;
                    client.OnReset = OnReset;
                    client.OnWinnersGet = OnWinnerGet;
                    client.OnDisconnect = OnDisconnect;
                    Ready_Button.Enabled = true;
                    tabControl1.SelectedIndex = 1;
                }
            }
        }

        private void OnPlayersListChanged(string[] names)
        {
            //Players_Listbox.DataSource = names;
            listView1.Clear();
            foreach (var item in names)
            {
                listView1.Items.Add(item, item, "Empty_Image");
            }
        }
        private void OnBegin()
        {
            EnableTimer();
            foreach (ListViewItem p in listView1.Items)
            {
                p.BackColor = Color.White;
            }
            Ready_Button.Enabled = false;
            tableLayoutPanel1.Enabled = true;
            tableLayoutPanel2.Enabled = true;
        }
        private void OnReset()
        {
            Ready_Button.Enabled = true;
            tableLayoutPanel1.Enabled = false;
            tableLayoutPanel2.Enabled = false;
            if (client != null)
            {
                if (!string.IsNullOrWhiteSpace(Checkbox_BottleCooldown.Text))
                {
                    int count = int.Parse(Checkbox_BottleCooldown.Text);
                    if (count > 1)
                    {
                        Checkbox_BottleCooldown.Text = (count - 1).ToString();
                    }
                    else
                    {
                        Checkbox_BottleCooldown.Text = "";
                        Checkbox_BottleCooldown.Checked = true;
                    }
                }
                if (!string.IsNullOrWhiteSpace(Checkbox_GunCooldown.Text))
                {
                    int count = int.Parse(Checkbox_GunCooldown.Text);
                    if (count > 1)
                    {
                        Checkbox_GunCooldown.Text = (count - 1).ToString();
                    }
                    else
                    {
                        Checkbox_GunCooldown.Text = "";
                        Checkbox_GunCooldown.Checked = true;
                    }
                }

                if (client.symbol == Symbol.Bottle)
                {
                    Checkbox_BottleCooldown.Text = Server.bottleCooldown.ToString();
                    Checkbox_BottleCooldown.Checked = false;
                }
                else if (client.symbol == Symbol.Gun)
                {
                    Checkbox_GunCooldown.Text = Server.gunCooldown.ToString();
                    Checkbox_GunCooldown.Checked = false;
                }
            }
            else
            {
                Checkbox_BottleCooldown.Text = "";
                Checkbox_BottleCooldown.Checked = true;
                Checkbox_GunCooldown.Text = "";
                Checkbox_GunCooldown.Checked = true;
            }
        }
        private void OnWinnerGet(List<string> winners)
        {
            foreach(ListViewItem p in listView1.Items)
            {
                if (winners.Contains(p.Text))
                {
                    p.BackColor = Color.Lime;
                }
                else
                {
                    p.BackColor = Color.Red;
                }
            }
            if (winners.Contains(client.Name))
            {
                OnReset();
            }
        }
        private void OnDisconnect()
        {
            client = null;
            OnReset();
            tabControl1.SelectedIndex = 0;
        }
        private void Ready_Button_Click(object sender, EventArgs e)
        {
            client.SendReady();
        }
        
        private void ItemButton_Click(object sender, EventArgs e)
        {
            string item = (string)(sender as Button).Tag;
            Symbol symbol = (Symbol)Enum.Parse(typeof(Symbol), item);
            switch (symbol)
            {
                case Symbol.Bottle:
                if (Checkbox_BottleCooldown.Checked)
                {
                    client.SendSymbol(symbol);
                }
                else
                {
                    MessageBox.Show("Bottle isn't avaible");
                }
                break;
                case Symbol.Gun:
                if (Checkbox_GunCooldown.Checked)
                {
                    client.SendSymbol(symbol);
                }
                else
                {
                    MessageBox.Show("Gun isn't avaible");
                }
                break;
                default:
                client.SendSymbol(symbol);
                break;
            }
        }

        private void EnableTimer()
        {
            Task task = new Task(new Action(() =>
            {
                int count = Server.gameTime / 1000;
                for (int i = count; i >= 0; i--)
                {
                    Time_Lable.Text = count.ToString();
                    count--;
                    System.Threading.Thread.Sleep(1000);
                }
            }));
            task.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void Checkbox_GunCooldown_CheckedChanged(object sender, EventArgs e)
        {
            Button_Gun.Enabled = (sender as CheckBox).Checked;
        }

        private void Checkbox_BottleCooldown_CheckedChanged(object sender, EventArgs e)
        {
            Button_Bottle.Enabled = (sender as CheckBox).Checked;
        }

        private void Time_Lable_Click(object sender, EventArgs e)
        {

        }
    }
}
