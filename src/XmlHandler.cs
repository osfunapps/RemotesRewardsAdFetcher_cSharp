using System;
using System.Xml;

namespace RewardsAdFetcher
{
    internal class XmlHandler
    {

        private readonly string _CMNT_PACKAGE_NAME = "Package Name ";
        private readonly string _CMNT_MISSING = " IS MISSING";

        private readonly string _RESOURCES_NODE_TAG = "string";

        private readonly string _ATT_NAME_KEY = "name";
        private readonly string _ATT_NAME_VAL = "reward_ad_unit_id";

        private readonly string _ATT_TRANSLATEABLE_KEY = "translatable";
        private readonly string _ATT_TRANSLATEABLE_VAL = "false";


        //instances
        private IXmlCallback callback;
        private string stringsPath;
        private XmlDocument stringsDocument;
        private XmlNode elementRes;

        public XmlHandler(IXmlCallback callback)
        {
            this.callback = callback;
        }

        public void SetStringsDocument(string stringsXmlPath)
        {
            stringsPath = stringsXmlPath;
            stringsDocument = new XmlDocument();
            stringsDocument.Load(stringsXmlPath);
            elementRes = stringsDocument.GetElementsByTagName("resources")[0];
        }

        internal bool IsRewardTagExists()
        {
            foreach (XmlNode node in elementRes.ChildNodes)
                if (!node.Name.Equals("#comment") && node.Attributes[0].Value.Equals("reward_ad_unit_id"))
                    return true;

            return false;
        }


        internal void AppendRewardTag(string rewardId)
        {
            XmlElement fileProviderNode = stringsDocument.CreateElement(_RESOURCES_NODE_TAG);
            fileProviderNode.SetAttribute(_ATT_NAME_KEY, _ATT_NAME_VAL);
            fileProviderNode.SetAttribute(_ATT_TRANSLATEABLE_KEY, _ATT_TRANSLATEABLE_VAL);
            fileProviderNode.InnerText = rewardId;
            elementRes.AppendChild(fileProviderNode);

            RemoveRewardIsMissingNote();
            stringsDocument.Save(stringsPath);
            callback.OnXmlAppendDone();
        }

        private void RemoveRewardIsMissingNote()
        {
            foreach(XmlNode node in elementRes.ChildNodes)
            {
                if (node.Name.Equals("#comment") && node.Value.Contains("reward_ad_unit_id"))
                {
                    elementRes.RemoveChild(node);
                    return;
                }
            }
        }
    }


}

public interface IXmlCallback
{
    void OnXmlAppendDone();
}