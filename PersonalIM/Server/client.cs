
using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PersonalIM
{
    public partial class Form1 : Form
    {
        //Create the client
        private System.Net.Sockets.TcpClient client = new TcpClient(); 
        public Form1()
        {
            
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)

        {

            msg("Client Started");

            client.Connect("127.0.0.1", 8888);

            label1.Text = "Client Socket Program - Server Connected ...";

        }
        
        private void button1_Click(object sender, EventArgs e)

        {

            NetworkStream serverStream = client.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");

            serverStream.Write(outStream, 0, outStream.Length);

            serverStream.Flush();



            byte[] inStream = new byte[10025];

            serverStream.Read(inStream, 0, (int)client.ReceiveBufferSize);

            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            msg(returndata);

            textBox2.Text = "";

            textBox2.Focus();

        }



        public void msg(string mesg)

        {

            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;

        } 
    }
}
