using HtmlAgilityPack;
using System.Net;

namespace WebClientHelper
{
    public class ClientHelper
    {

  
        //Belirlenen url adresindeki web sitesinin html bilgilerini getirir 
        public static HtmlDocument GetHtmlDocument(string url)
        {
            WebClient client = new WebClient();
            string html = client.DownloadString(url);

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            return document;
        }


        public static HtmlNode GetHtmlNode(string url, string documentId)
        {
            HtmlDocument document = GetHtmlDocument(url);
            return document.GetElementbyId(documentId);
        }

        public static string GetHtmlContentByDocumentId(string url,string documentId)
        {
            var node = GetHtmlNode(url, documentId); 
            return node.InnerText;
        }



        //public string GetH(string url, string documentId)
        //{ 
        //    //Web Sitesine bağlanıp veri çekecez
        //    WebClient client = new WebClient();
        //    string html = client.DownloadString(url);

        //    HtmlDocument document = new HtmlDocument();
        //    document.LoadHtml(html);

        //    HtmlNode HtmlNode = document.GetElementbyId(documentId);
        //    var data = HtmlNode.InnerText;
        //    return data;
        //}
    }
}