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
using SimpleJSON;

namespace CommandTable
{
    public partial class MainForm : Form
    {
        CommandTableController _controller;
        
        public MainForm()
        {
            _controller = new CommandTableController();
            _controller.RegisterCommand("log", new SynchronousFunctionCommandModule(WriteLogCommand));
            _controller.RegisterCommand("run", new RunProcessCommandModule());

            InitializeComponent();
        }

        const string SendMessageCommand = "ReceiveMessage";

        string[] _sizeOneArray = new string[1];

        void SendMessage(string message)
        {
            _sizeOneArray[0] = message;
            MainWebBrowser.Document.InvokeScript(SendMessageCommand, _sizeOneArray);
        }

        void WaitForTask(object taskObject)
        {
            var task = taskObject as Task<JSONNode>;
            if (task == null)
                return;
            
            while (!task.IsCompleted)
                return;
        }

        void ReceiveMessage(string message)
        {
            Log.Message(Log.Level.Debug, "Host received: " + message);

            try
            {
                JSONNode command = JSON.Parse(message);

                //TODO: Handle this returned task and do something with it.
                var task = _controller.RunCommand(command);

                if (task != null)
                {
                    var waitTask = new Task(WaitForTask, task);
                    waitTask.Start();
                }
            }
            catch (System.Exception ex)
            {
                Log.MessageFormat(Log.Level.Exception, "Exception: {0}", ex.ToString());
            }
        }

        //So javascript can call our log function.
        JSONNode WriteLogCommand(JSONNode node)
        {
            if (node == null)
                return null;

            var message = node["message"];
            if (message == null)
                return null;

            Log.Message(Log.Level.Info, message);
            return null;
        }

        void WriteLog(Log.Level level, string message)
        {
            if (level == Log.Level.Raw)
            {
                LogBox.AppendText(message);
            }
            else
            {
                string logPrefix = string.Format("[{0}]", level);
                LogBox.AppendText(string.Format("{0:10} {1}\n", logPrefix, message));
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Log.AddLogCallback(WriteLog);
            
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
            Log.MessageFormat(Log.Level.Info, "Base path: {0}", basePath);

            MainWebBrowser.Navigate(Path.Combine(basePath, MainModule));
        }

        private void MainBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
