using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UdpChat
{
    public partial class Form1 : Form
    {
        bool alive = false; // чи буде працювати потік для приймання
        UdpClient client;
        const int LOCALPORT = 8001; // порт для приймання повідомлень
        const int REMOTEPORT = 8001; // порт для передавання повідомлень
        const int TTL = 20;
        const string HOST = "235.5.5.1"; // хост для групового розсилання
        IPAddress groupAddress; // адреса для групового розсилання
        string userName; // ім’я користувача в чаті
        public Form1()
        {
            InitializeComponent();
            loginButton.Enabled = true; // кнопка входу
            logoutButton.Enabled = false; // кнопка виходу
            sendButton.Enabled = false; // кнопка отправки
            chatTextBox.ReadOnly = true; // поле для повідомлень
            groupAddress = IPAddress.Parse(HOST);
           

        }
      
        
        // метод приймання повідомлення
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    // добавляем полученное сообщение в текстовое поле
                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.Text = time + " " + message + "\r\n"
                        + chatTextBox.Text;
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // вихід з чату
        private void ExitChat()
        {
            string message = userName + " покидает чат";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, HOST, REMOTEPORT);
            client.DropMulticastGroup(groupAddress);
            alive = false;
            client.Close();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
        }
        // обработчик события закрытия формы
        private void Form1_FormClosing(object sender,
       FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }

        // додати кнопку "Settings"
        private void AddSettingsButton()
        {
            Button settingsButton = new Button();
            settingsButton.Text = "Settings";
            settingsButton.Click += new EventHandler(settingsButton_Click);
            // додати кнопку на головну форму
            this.Controls.Add(settingsButton);
        }
        private void settingsButton_Click(object sender, EventArgs e)
        {
            // відкрити форму налаштувань
            Form2 settingsForm = new Form2();
            settingsForm.ShowDialog();
            if (settingsForm != null)
            {
                // вызываем метод или обращаемся к свойству объекта
            }
        }
        // додати кнопку "Save log"
        private void AddSaveLogButton()
        {
            Button saveLogButton = new Button();
            saveLogButton.Text = "Save log";
            saveLogButton.Click += new EventHandler(saveLogButton_Click);
            // додати кнопку на головну форму
            this.Controls.Add(saveLogButton);
        }

        private void saveLogButton_Click(object sender, EventArgs e)
        {
            // зберегти лог у текстовий файл
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (.txt)|.txt";
            saveFileDialog.Title = "Save chat log";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.Write(chatTextBox.Text);
                }
            }
        }
        // обробник натискання кнопок loginButton
        private void loginButton_Click_1(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;
            try
            {
                client = new UdpClient(LOCALPORT);
                //підєднання до групового розсилання
                client.JoinMulticastGroup(groupAddress, TTL);

                // задача на приймання повідомлень
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();
                // перше повідомлення про вхід нового користувача
                string message = userName + " вошел в чат";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // обробник натискання кнопки sendButton
        private void sendButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName,
               messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // обробник натискання кнопки logoutButton
        private void logoutButton_Click_1(object sender, EventArgs e)
        {
            ExitChat();
        }
    }
}
