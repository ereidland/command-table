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

        private void MainForm_Load(object sender, EventArgs e)
        {
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
