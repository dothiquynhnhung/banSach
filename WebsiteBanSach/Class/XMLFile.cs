using System.Xml;

namespace WebsiteBanSach.Class
{
    internal class XMLFile
    {
        internal XmlDocument getXmlDocument(string v)
        {
            XmlDocument Xd = new XmlDocument();
            Xd.Load(v);
            return Xd;
        }
    }
}
