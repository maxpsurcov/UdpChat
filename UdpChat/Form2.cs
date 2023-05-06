using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UdpChat
{
    public partial class Form2 : Form
    {
        // Поля для зберігання налаштувань
        private string address;
        private int localPort;
        private int remotePort;
        private Font chatFont;
        public Form2()
        {
            InitializeComponent();
            this.address = address;
            this.localPort = localPort;
            this.remotePort = remotePort;
            this.chatFont = chatFont;

            // Відображення поточних налаштувань
            addressTextBox.Text = address;
            localPortTextBox.Text = localPort.ToString();
            remotePortTextBox.Text = remotePort.ToString();
            fontLabel.Text = chatFont.Name + ", " + chatFont.Size + " pt";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Збереження введених налаштувань
            address = addressTextBox.Text;
            int.TryParse(localPortTextBox.Text, out localPort);
            int.TryParse(remotePortTextBox.Text, out remotePort);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public string Address
        {
            get { return address; }
        }

        public int LocalPort
        {
            get { return localPort; }
        }

        public int RemotePort
        {
            get { return remotePort; }
        }

        public Font ChatFont
        {
            get { return chatFont; }
        }
    }
}
