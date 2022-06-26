using HtmlAgilityPack; //HtmlDocument
using Quartz;   //IJob
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebClientHelper;

namespace ExchangeRateJob.UI.Jobs
{
    public class ExchangeRateJobs : IJob
    {
        public HtmlDocument htmlDocument_ { get; set; }

        //public Task Execute(IJobExecutionContext context)
        //{

        //    //Web sitesinden Kur çekilecek 
        //    string onsRate = ClientHelper.GetHtmlContentByDocumentId("https://altin.in/", "ofiy");
        //    Console.WriteLine($"Altin Fiyatı : {new Random().Next()}");
        //    string dollarRate = ClientHelper.GetHtmlContentByDocumentId("https://altin.in/", "dfiy");
        //    Console.WriteLine($"Dolar Fiyatı : {new Random().Next()}");
        //    string euroRate = ClientHelper.GetHtmlContentByDocumentId("https://altin.in/", "efiy");
        //    Console.WriteLine($"Euro Fiyatı : {new Random().Next()}");
        //    return Task.CompletedTask;
        //}


        public Task Execute(IJobExecutionContext context)
        {
            GetDocument();
            //Web sitesinden Kur çekilecek 
            string onsRate = GetDocumentData("ofiy");
            Console.WriteLine($"Altin Fiyatı : {new Random().Next()}");
            string dollarRate = GetDocumentData("dfiy");
            Console.WriteLine($"Dolar Fiyatı : {new Random().Next()}");
            string euroRate = GetDocumentData("efiy");
            Console.WriteLine($"Euro Fiyatı : {new Random().Next()}");
            return Task.CompletedTask;
        }


        public void GetDocument()
        {
            htmlDocument_ = ClientHelper.GetHtmlDocument("https://altin.in/");
        }

        public string  GetDocumentData(string id)
        {
            return htmlDocument_.GetElementbyId(id).InnerText;
        }

    }
}
