using System;
using System.Windows.Forms;
using SomeProject.Library;
using SomeProject.Library.Client;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SomeProject.TcpClient
{
    public partial class ClientMainWindow : Form
    {
        OpenFileDialog openFileDialog1;
        RichTextBox richTextBox1;
        public ClientMainWindow()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
            
            richTextBox1 = new RichTextBox();
        }

        private void OnMsgBtnClick(object sender, EventArgs e)
        {
            Client client = new Client();
            Result res = client.SendMessageToServer(textBox.Text).Result;
            if(res == Result.OK)
            {
                textBox.Text = "";
                labelRes.Text = "Message was sent succefully!";
            }
            else
            {
                labelRes.Text = "Cannot send the message to the server.";
            }
            timer.Interval = 2000;
            timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            labelRes.Text = "";
            timer.Stop();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 

                Client client = new Client();
                Result res = client.SendFileToServer(openFileDialog1.FileName).Result;
                if (res == Result.OK)
                {
                    textBox.Text = "";
                    labelRes.Text = "File was sent succefully!";
                }
                else
                {
                    labelRes.Text = "Cannot send the message to the server.";
                }
                timer.Interval = 2000;
                timer.Start();
            }
        }
       
    }
}
