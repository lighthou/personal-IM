using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class client : Form
    {
        private System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        public client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            //Output to textbox that program has started
            msg("Client Started");
            //Local IP Address to connect to
            clientSocket.Connect("192.168.0.19", 8888);
            //Tell textbox you've connected by setting label
            label1.Text = "Client Socket Program - Server Connected ...";

        }

        private void button1_Click(object sender, EventArgs e)

        {
            //Get the stream on ifnormation
            NetworkStream serverStream = clientSocket.GetStream();
            //What you'll output plus a $ based on textBox2
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");
            //Write to the stream making sure the length is appropriate
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
                


            byte[] inStream = new byte[8192];

            serverStream.Read(inStream, 0, inStream.Length);

            int bytesRead = serverStream.Read(inStream, 0, inStream.Length);

            string returndata = System.Text.Encoding.ASCII.GetString(inStream, 0 , bytesRead);

            //Message to textbox1 and reset the textbox2
            msg(returndata);
            textBox2.Text = "";
            textBox2.Focus();

        }



        public void msg(string mesg)
        {
            Console.WriteLine("ok");
            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;
        }

    }
}
