using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CommandTable
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        const string SendMessageCommand = "ReceiveMessage";

        string[] _sizeOneArray = new string[1];

        void SendMessage(string message)
        {
            _sizeOneArray[0] = message;
            MainWebBrowser.Document.InvokeScript(SendMessageCommand, _sizeOneArray);
        }

        void ReceiveMessage(string message)
        {
            MessageBox.Show("Host received: " + message);
            SendMessage("Echo: " + message);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainWebBrowser.ObjectForScripting = new StringPipe(SendMessage, ReceiveMessage);

            string basePath = Directory.GetCurrentDirectory();

            const string ModuleFolder = "Modules";
            const string MainModule = "main.html";

            while (!Directory.Exists(Path.Combine(basePath, ModuleFolder)))
            {
                var parent = Directory.GetParent(basePath);
                if (parent == null)
                {
                    MessageBox.Show(string.Format("Unable to find module root!"));
                    return;
                }
                else
                {
                    basePath = parent.FullName;
                }
            }

            basePath = Path.Combine(basePath, ModuleFolder);
            MainWebBrowser.Navigate(Path.Combine(basePath, MainModule));
        }

        private void MainBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
