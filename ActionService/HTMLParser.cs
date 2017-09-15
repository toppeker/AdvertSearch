using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Net.Mail;

namespace ActionLayer
{
    public class CAR_CONTAINER
    {
        // public int ID { get; set; }
        public string BRAND { get; set; }
        public string SERIES { get; set; }
        public string MODEL { get; set; }
        public string YEAR { get; set; }
        public string KM { get; set; }
        public string MONEY { get; set; }
        public string COLOR { get; set; }
        public string LINK { get; set; }
    }




    public class HTMLParser
    {
        public string html;
        public Uri url;
        public WebClient client;
        public HtmlAgilityPack.HtmlDocument doc;
        public string brandName;
        public string seriesName;

        // to hold user data
        public string emailAddress;     // database'e kaydet
        public string userName;         // database'e kaydet

        public List<CAR_CONTAINER> storedList = new List<CAR_CONTAINER>();      // database'e kaydet

        public CAR_CONTAINER storeCarData(int carRow, HtmlAgilityPack.HtmlDocument Doc)
        {
            string brand = brandName;
            string series = seriesName;
            string model;
            string year;
            string km;
            string color;
            string money;
            string link;

            CAR_CONTAINER car = new CAR_CONTAINER();

            try
            {
                //string seriesXPath = "//*[@id='searchResultsTable']/tbody/tr[" + carRow.ToString() + "]/td[2]";
                //series = Doc.DocumentNode.SelectSingleNode(seriesXPath).InnerText;
                //series = series.Replace("&nbsp;", "");
                //series = series.Trim();

                string modelXPath = "//*[@id='searchResultsTable']/tbody/tr[" + carRow.ToString() + "]/td[2]";
                model = Doc.DocumentNode.SelectSingleNode(modelXPath).InnerText;
                model = model.Replace("&nbsp;", "");
                model = model.Trim();

                string linkXPath = "//*[@id='searchResultsTable']/tbody/tr[" + carRow.ToString() + "]/td[3]/a[1]";
                link = Doc.DocumentNode.SelectSingleNode(linkXPath).Attributes["href"].Value;
                link = link.Trim();
                link = "https://www.sahibinden.com" + link;

                string yearXPath = "//*[@id='searchResultsTable']/tbody/tr[" + carRow.ToString() + "]/td[4]";
                year = Doc.DocumentNode.SelectSingleNode(yearXPath).InnerText;
                year = year.Replace("&nbsp;", "");
                year = year.Trim();

                string kmXPath = "//*[@id='searchResultsTable']/tbody/tr[" + carRow.ToString() + "]/td[5]";
                km = Doc.DocumentNode.SelectSingleNode(kmXPath).InnerText;
                km = km.Replace("&nbsp;", "");
                km = km.Trim();

                string colorXPath = "//*[@id='searchResultsTable']/tbody/tr[" + carRow.ToString() + "]/td[6]";
                color = Doc.DocumentNode.SelectSingleNode(colorXPath).InnerText;
                color = color.Replace("&nbsp;", "");
                color = color.Trim();

                string moneyXPath = "//*[@id='searchResultsTable']/tbody/tr[" + carRow.ToString() + "]/td[7]/div";
                money = Doc.DocumentNode.SelectSingleNode(moneyXPath).InnerText;
                money = money.Replace("&nbsp;", "");
                money = money.Trim();

                car.BRAND = brand;
                car.SERIES = series;
                car.MODEL = model;
                car.YEAR = year;
                car.MONEY = money;
                car.COLOR = color;
                car.KM = km;
                car.LINK = link;

                return car;

            }
            catch (NullReferenceException)
            {
                // Console.WriteLine("NullReferenceException");
                return car;

            }
        }

        public void makeClient()
        {
            client = new WebClient();
            client.Encoding = Encoding.UTF8;

            try
            {
                html = client.DownloadString(url);
            }
            catch (WebException)
            {
                Console.WriteLine("WebException");
            }
        }

        public void getCarList(List<CAR_CONTAINER> CarList)
        {
            for (int carCounter = 1; carCounter <= 50; carCounter++)
            {
                CarList.Add(storeCarData(carCounter, doc));
            }

            CarList.RemoveAll(item => item.BRAND == null);     // NULL GELENLERİ SİL.
        }

        public void getHTML()
        {
            doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
        }

        public void getUrl(string Url)
        {
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {
                Console.WriteLine("UriFormatException");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException");
            }
        }

        public void storeList(List<CAR_CONTAINER> listToStore)
        {
            storedList = listToStore;   // assign list to other list
        }

        public void getUserData(string usrName, string EmailAddress)
        {
            userName = usrName;
            emailAddress = EmailAddress;
        }

        public void sendEmailToUser(string from, string to, string subject, string body, string senderMail = "", string senderPassword = "", string host = "")
        {
            var mail = new MailMessage();
            mail.To.Add(new MailAddress(to));  // replace with valid value 
            mail.From = new MailAddress(from);  // replace with valid value
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = senderMail,  // replace with valid value
                    Password = senderPassword  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = host;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }

    }
}
