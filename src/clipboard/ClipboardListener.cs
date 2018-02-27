using EventHook;
using System;
using System.Threading;
using System.Windows.Forms;

namespace RewardsAdFetcher
{
    internal class ClipboardListener
    {
        //instances
        private IClipboardCallback callback;
        private bool copied;

        public ClipboardListener(IClipboardCallback callback)
        {
            this.callback = callback;
            ClipboardWatcher.OnClipboardModified += new EventHandler<ClipboardEventArgs>(ClipboardOpen);
        }

        internal void ListinToClipboard()
        {
            copied = false;
            ClipboardWatcher.Start();
        }

        private void ClipboardOpen(object sender, ClipboardEventArgs e)
        {
            if (copied)return;

            copied = true;
            Thread.Sleep(150);
            ClipboardWatcher.Stop();
            callback.OnClipboardCopy(Clipboard.GetText(TextDataFormat.Text));
        }

    }

    public interface IClipboardCallback
    {
        void OnClipboardCopy(string copiedTxt);
    }
}