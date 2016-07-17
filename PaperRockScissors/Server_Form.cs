using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaperRockScissors
{
    public partial class Server_Form : Form
    {
        public Server_Form()
        {
            InitializeComponent();
            instance = this;
        }
        public static Server_Form instance;
        public static void Log(string message)
        {
            if(instance != null)
            {
                instance.Invoke(new Action(()=> instance.listBox1.Items.Add(message)));
            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}
