using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CommandTable
{
    [ComVisible(true)]
    public class StringPipe
    {
        Action<string> _sendMessageCallback;
        Action<string> _receiveMessageCallback;

        public void ReceiveMessage(string message)
        {
            _receiveMessageCallback(message);
        }

        [ComVisible(false)]
        public void SendMessage(string message)
        {
            _sendMessageCallback(message);
        }

        public StringPipe(Action<string> sendMessageCallback, Action<string> receiveMessageCallback)
        {
            _sendMessageCallback = sendMessageCallback;
            _receiveMessageCallback = receiveMessageCallback;
        }
    }
}
