using System.Xml.Linq;

namespace WebsiteBanSach.Class
{
    public class XMLtoSQL
    {
        Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(@"Data Source=DESKTOP-D6HVN2B;Initial Catalog=dbBanSach;Integrated Security=True;Encrypt=False");

        public void BackUpData()
        {
            BackUpData("KhachHang");
            BackUpData("NhaXuatBan");
            BackUpData("DanhMuc");
            BackUpData("TacGia");
            BackUpData("TheLoai");
            BackUpData("Sach");
            BackUpData("HoaDon");
            BackUpData("ChiTietHoaDon");
        }

        string toString(XElement elm)
        {
            string result = "";
            foreach (XElement x in elm.Elements())
            {
                if (x == elm.LastNode)
                    result += "N'" + x.Value + "'";
                else
                {
                    result += "N'" + x.Value + "',";
                }
            }
            return "(" + result + "),\n";
        }

        private void BackUpData(string XMLFileName)
        {
            XDocument XDoc = XDocument.Load(XMLFileName + ".xml");
            Console.WriteLine();
            conn.Open();
            Microsoft.Data.SqlClient.SqlCommand command;
            string query = "DELETE FROM " + XMLFileName + "\n insert into " + XMLFileName + " values\n";
            try
            {
                foreach (XElement x in XDoc.Descendants(XMLFileName))
                {
                    toString(x);
                    query += toString(x);
                }
                Console.WriteLine(query.Substring(0, query.Length - 2));
                command = new Microsoft.Data.SqlClient.SqlCommand(query.Substring(0, query.Length - 2), conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            Console.Read();
        }
    }
}
