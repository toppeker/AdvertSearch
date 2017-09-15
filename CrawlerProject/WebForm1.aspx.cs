using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActionLayer;

namespace denemeLastBS
{
    public class FILTER_INFO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Brand { get; set; }
        public string Series { get; set; }
        public string MaxKm { get; set; }
        public string MaxPrice { get; set; }
        public string MinModelYear { get; set; }
        public string MaxModelYear { get; set; }
        public string Color { get; set; }
        
    }

    public partial class WebForm1 : System.Web.UI.Page
    {

        FILTER_INFO newFilterInfo = new FILTER_INFO();
        HTMLParser Parser = new HTMLParser();
        List<CAR_CONTAINER> carList = new List<CAR_CONTAINER>();    // database'e kaydet
        string bodyEmail;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setSeriesList();
            }


        }

        // listele button clicked
        protected void Button1_Click(object sender, EventArgs e)
        {
            getData();
            createTable(carList);

        }

        // reset button clicked
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBoxName.Text = string.Empty;
            TextBoxEmail.Text = string.Empty;
            TextBoxKm.Text = string.Empty;
            TextBoxFiyat.Text = string.Empty;
            TextBoxYear.Text = string.Empty;

            DropDownList1.SelectedIndex = 0;
            setSeriesList();    // set dropdowns to default

            RadioButtonList1.SelectedIndex = 4;     // select hepsi again
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setSeriesList();
        }

        protected void setSeriesList()
        {
            var selectedBrand = DropDownList1.SelectedValue;

            DropDownList2.Items.Clear();

            if (selectedBrand == "1")
            {
                ListItem I1 = new ListItem("A3", "1");
                DropDownList2.Items.Add(I1);
                ListItem I2 = new ListItem("A4", "2");
                DropDownList2.Items.Add(I2);
                ListItem I3 = new ListItem("A5", "3");
                DropDownList2.Items.Add(I3);
                ListItem I4 = new ListItem("A6", "4");
                DropDownList2.Items.Add(I4);

            }
            else if (selectedBrand == "2")
            {
                ListItem I1 = new ListItem("Egea", "1");
                DropDownList2.Items.Add(I1);
                ListItem I2 = new ListItem("Linea", "2");
                DropDownList2.Items.Add(I2);
                ListItem I3 = new ListItem("Albea", "3");
                DropDownList2.Items.Add(I3);
                ListItem I4 = new ListItem("Punto", "4");
                DropDownList2.Items.Add(I4);


            }
            else if (selectedBrand == "3")
            {
                ListItem I1 = new ListItem("Jetta", "1");
                DropDownList2.Items.Add(I1);
                ListItem I2 = new ListItem("Golf", "2");
                DropDownList2.Items.Add(I2);
                ListItem I3 = new ListItem("Passat", "3");
                DropDownList2.Items.Add(I3);
                ListItem I4 = new ListItem("Polo", "4");
                DropDownList2.Items.Add(I4);


            }
            else if (selectedBrand == "4")
            {
                ListItem I1 = new ListItem("Avensis", "1");
                DropDownList2.Items.Add(I1);
                ListItem I2 = new ListItem("Auris", "2");
                DropDownList2.Items.Add(I2);
                ListItem I3 = new ListItem("Corolla", "3");
                DropDownList2.Items.Add(I3);
                ListItem I4 = new ListItem("Yaris", "4");
                DropDownList2.Items.Add(I4);

            }
            else if (selectedBrand == "5")
            {
                ListItem I1 = new ListItem("Accord", "1");
                DropDownList2.Items.Add(I1);
                ListItem I2 = new ListItem("Civic", "2");
                DropDownList2.Items.Add(I2);
                ListItem I3 = new ListItem("Jazz", "3");
                DropDownList2.Items.Add(I3);
                ListItem I4 = new ListItem("City", "4");
                DropDownList2.Items.Add(I4);

            }
        }

        public string goSelectedUrl()
        {
            string carInfo = newFilterInfo.Brand + "-" + newFilterInfo.Series + "?";
            string yearInfo = "a5_min=" + newFilterInfo.MinModelYear;
            string yearInfo1 = "&a5_max=" + newFilterInfo.MaxModelYear;

            string colorInfo;
            if (newFilterInfo.Color == "beyaz")
            {
                colorInfo = "&a3=33611";
            }
            else if (newFilterInfo.Color == "siyah")
            {
                colorInfo = "&a3=33616";
            }
            else if (newFilterInfo.Color == "kırmızı")
            {
                colorInfo = "&a3=33613";
            }
            else if (newFilterInfo.Color == "mavi")
            {
                colorInfo = "&a3=33610";
            }
            else
            {
                colorInfo = "";
            }

            string priceInfo = "&price_max=" + newFilterInfo.MaxPrice;
            string kmInfo = "&a4_max=" + newFilterInfo.MaxKm;

            string totalUrl = "https://www.sahibinden.com/" + carInfo + yearInfo + yearInfo1 +  colorInfo + priceInfo + kmInfo + "&pagingSize=50";

            return totalUrl;

        }

        public void createTable(List<CAR_CONTAINER> tableCarList)
        {
            int count = 1;

            TableHeaderRow headerRow = new TableHeaderRow();

            TableHeaderCell cellHeader1 = new TableHeaderCell();
            TableHeaderCell cellHeader2 = new TableHeaderCell();
            TableHeaderCell cellHeader3 = new TableHeaderCell();
            TableHeaderCell cellHeader4 = new TableHeaderCell();
            TableHeaderCell cellHeader5 = new TableHeaderCell();
            TableHeaderCell cellHeader6 = new TableHeaderCell();
            TableHeaderCell cellHeader7 = new TableHeaderCell();
            TableHeaderCell cellHeader8 = new TableHeaderCell();
            TableHeaderCell cellHeader9 = new TableHeaderCell();

            cellHeader1.Text = "#";
            cellHeader2.Text = "Marka";
            cellHeader3.Text = "Seri";
            cellHeader4.Text = "Model";
            cellHeader5.Text = "Yıl";
            cellHeader6.Text = "Kilometre";
            cellHeader7.Text = "Renk";
            cellHeader8.Text = "Fiyat";
            cellHeader9.Text = "Link";


            headerRow.Cells.Add(cellHeader1);
            headerRow.Cells.Add(cellHeader2);
            headerRow.Cells.Add(cellHeader3);
            headerRow.Cells.Add(cellHeader4);
            headerRow.Cells.Add(cellHeader5);
            headerRow.Cells.Add(cellHeader6);
            headerRow.Cells.Add(cellHeader7);
            headerRow.Cells.Add(cellHeader8);
            headerRow.Cells.Add(cellHeader9);

            Table1.Rows.Add(headerRow);

            foreach (var k in tableCarList)
            {

                TableRow row = new TableRow();

                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();
                TableCell cell6 = new TableCell();
                TableCell cell7 = new TableCell();
                TableCell cell8 = new TableCell();

                HyperLink lnk1 = new HyperLink()
                {
                    Text = "Siteye git!",
                    NavigateUrl = k.LINK,
                };

                TableCell cell9 = new TableCell();


                cell1.Text = count.ToString();
                cell2.Text = k.BRAND.First().ToString().ToUpper() + k.BRAND.Substring(1);
                cell3.Text = k.SERIES.First().ToString().ToUpper() + k.SERIES.Substring(1);
                cell4.Text = k.MODEL;
                cell5.Text = k.YEAR;
                cell6.Text = k.KM;
                cell7.Text = k.COLOR;
                cell8.Text = k.MONEY;
                cell9.Controls.Add(lnk1);

                count++;

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                row.Cells.Add(cell6);
                row.Cells.Add(cell7);
                row.Cells.Add(cell8);
                row.Cells.Add(cell9);

                Table1.Rows.Add(row);
                
            }
            
        }

        // mail atma butonu
        protected void Button3_Click(object sender, EventArgs e)
        {
            getData();
            createEmailBody();
            Parser.sendEmailToUser("sipsakilan@gmail.com", newFilterInfo.Email, "Sizin için seçilen ilanlar (" + System.DateTime.Now.ToShortDateString() + ")", 
                bodyEmail, "sipsakilan@gmail.com", "ilanibul", "smtp.gmail.com");
            
        }

        public void getData()
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Eksik Alan", "<script>alert('Kullanıcı adını giriniz');</script>");
                TextBoxName.Focus();
            }
            else if (string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Eksik Alan", "<script>alert('Email adresini giriniz');</script>");
                TextBoxEmail.Focus();
            }
            else
            {
                newFilterInfo.UserName = TextBoxName.Text;
                newFilterInfo.Email = TextBoxEmail.Text;
                newFilterInfo.Brand = DropDownList1.SelectedItem.Text.ToLower();
                newFilterInfo.Series = DropDownList2.SelectedItem.Text.ToLower();

                int kmValid;
                if (string.IsNullOrEmpty(TextBoxKm.Text))
                {
                    newFilterInfo.MaxKm = null;
                }
                else if (!int.TryParse(TextBoxKm.Text, out kmValid))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Yanlış formatlı giriş", "<script>alert('Maksimum Kilometre alanı sadece sayı değerleri içermelidir');</script>");
                    TextBoxKm.Focus();
                }
                else
                {
                    newFilterInfo.MaxKm = TextBoxKm.Text;
                }


                int fiyatValid;
                if (string.IsNullOrEmpty(TextBoxFiyat.Text))
                {
                    newFilterInfo.MaxPrice = null;
                }
                else if (!int.TryParse(TextBoxFiyat.Text, out fiyatValid))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Yanlış formatlı giriş", "<script>alert('Maksimum Fiyat alanı sadece sayı değerleri içermelidir');</script>");
                    TextBoxFiyat.Focus();
                }
                else
                {
                    newFilterInfo.MaxPrice = TextBoxFiyat.Text;
                }


                int yearValid;
                if (string.IsNullOrEmpty(TextBoxYear.Text))
                {
                    newFilterInfo.MinModelYear = null;
                }
                else if (!int.TryParse(TextBoxYear.Text, out yearValid))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Yanlış formatlı giriş", "<script>alert('Minimum model yılı alanı sadece sayı değerleri içermelidir');</script>");
                    TextBoxYear.Focus();
                }
                else
                {
                    newFilterInfo.MinModelYear = TextBoxYear.Text;
                }

                int yearValid1;
                if (string.IsNullOrEmpty(TextBoxYear1.Text))
                {
                    newFilterInfo.MaxModelYear = null;
                }
                else if (!int.TryParse(TextBoxYear1.Text, out yearValid1))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Yanlış formatlı giriş", "<script>alert('Maksimum model yılı alanı sadece sayı değerleri içermelidir');</script>");
                    TextBoxYear.Focus();
                }
                else
                {
                    newFilterInfo.MaxModelYear = TextBoxYear1.Text;
                }

                newFilterInfo.Color = RadioButtonList1.SelectedValue.ToString();



                Parser.brandName = newFilterInfo.Brand;
                Parser.seriesName = newFilterInfo.Series;

                string totalURL = goSelectedUrl();

                Parser.getUrl(totalURL);    // create url to take the data
                Parser.makeClient();    // create client
                Parser.getHTML();   // load html file
                Parser.getCarList(carList);     // store filtered car list locally
                carList.Sort((x, y) => x.MONEY.CompareTo(y.MONEY));
                Parser.storeList(carList);      // copy the car list to action layer
                Parser.getUserData(newFilterInfo.UserName, newFilterInfo.Email);    // copy the user data to action layer

            }
        }

        public void createEmailBody()
        {
            if(carList.Count > 0)
            {
                bodyEmail = "<html><head><style>table{font-family:arial,sans-serif; border-collapse: collapse;width: 50%;} td, th{border: 1px solid #dddddd;text-align: left; padding: 8px;}tr:nth-child(even){background-color: #dddddd;}</style></head>";
                bodyEmail = bodyEmail + "<body><h1>Sayın " + newFilterInfo.UserName + "<h1>";
                bodyEmail = bodyEmail + "<h3>Belirlediğiniz kriterlere uyan taşıtlar aşağıda listelenmiştir:<h3>";
                bodyEmail = bodyEmail + "<table><tr><th>#</th><th>Marka</th><th>Seri</th><th>Model</th><th>Yıl</th><th>Kilometre</th><th>Renk</th><th>Fiyat</th><th>Link</th></tr>";
                int tableCounter = 1;
                foreach (var m in carList)
                {
                    bodyEmail = bodyEmail + "<tr><td>" + tableCounter + "</td><td>" + m.BRAND.First().ToString().ToUpper() + m.BRAND.Substring(1)
                    + "</td><td>" + m.SERIES.First().ToString().ToUpper() + m.SERIES.Substring(1) + "</td><td>" + m.MODEL + "</td><td>" + m.YEAR + "</td><td>" + m.KM + "</td><td>" + m.COLOR + "</td><td>" + m.MONEY + "</td><td>" + "<a href=" + m.LINK + ">" + "Siteye Git" + "</a>" + "</td></tr>";
                    tableCounter++;

                }

                bodyEmail = bodyEmail + "</table></body></html>";
            }
            else
            {
                bodyEmail = "<h3>Belirlediğiniz kriterlere uygun araç bulunamamıştır</h3>";
            }
            
        }

    }
}