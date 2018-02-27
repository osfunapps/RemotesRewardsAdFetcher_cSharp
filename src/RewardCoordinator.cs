using LayoutProject.program.values;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RewardsAdFetcher
{
    internal class RewardCoordinator : IUserActionsCallback, IXmlCallback, IClipboardCallback
    {
        //instances
        private UserActionsCoordinator uac;
        private XmlHandler xmlHandler;
        private ClipboardListener clipBoardListener;

        //strings xml list
        private FileInfo[] stringsXmlFiles;

        //etc
        private readonly string _STRINGS_XML = "strings.xml";
        private int counter;
        private FileInfo currentStringsXml;

        public RewardCoordinator()
        {
            uac = new UserActionsCoordinator(this);
            xmlHandler = new XmlHandler(this);
            clipBoardListener = new ClipboardListener(this);
        }

        internal void Coordinate(string remotesPath)
        {
            stringsXmlFiles = new DirectoryInfo(remotesPath).GetFiles(_STRINGS_XML, SearchOption.AllDirectories);
            //show the mouse dialog

            NextValue();
            uac.ShowDialog();

        }

        private void NextValue()
        {
            if (counter == stringsXmlFiles.Length)
            {
                Finish();
                return;
            }
            //work with current xml file
            currentStringsXml = stringsXmlFiles[counter];
            xmlHandler.SetStringsDocument(currentStringsXml.FullName);
            if (!xmlHandler.IsRewardTagExists())
            {
                string appName = Directory.GetParent(currentStringsXml.FullName).Name;
                uac.ShowMouseNotification(appName);
                clipBoardListener.ListinToClipboard();
                //uac.WaitForUserActions();
            }
            else
            {
                counter++;
                NextValue();
            }
        }



        //todo: switch?
        public void OnUserCallback()
        {
            //send him the copied to board string
            string rewardId = "fdsa";
            xmlHandler.AppendRewardTag(rewardId);
        }

        public void OnClipboardCopy(string copiedTxt)
        {
            xmlHandler.AppendRewardTag(copiedTxt);
        }


        public void OnXmlAppendDone()
        {
            counter++;
            NextValue();
        }

        private void Finish()
        {
            MessageBox.Show("All done! (" + stringsXmlFiles.Length + " values)");
        }



    }



}