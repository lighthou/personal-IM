
using System.Net.Sockets;
using System.Windows.Forms;

namespace PersonalIM
{
    public partial class Form1 : Form
    {
        //Create the client
        private System.Net.Sockets.TcpClient _client = new TcpClient();

        public Form1()
        {
            InitializeComponent();
            
        }
    }
}