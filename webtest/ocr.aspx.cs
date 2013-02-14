using System;
using System.Collections.Generic;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using payu = PayuLib;
using PayuLib;
using System.Text;
using System.Collections.Specialized;

namespace webtest {
    public partial class ocr : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            NameValueCollection nvc = Request.Form;

            payu.AppConfig conf = new payu.AppConfig();

            conf.SetSignatureKey("SECRET_KEY");
            conf.SetEnvironment("https://secure.payu.com.tr/openpayu/v2/order.xml");
            conf.CurrentVersion = "TR";
            conf.Set(payu.Constants.ReqId, payu.OpenPayU.gen_uuid())
                .Set(payu.Constants.CurrencyCode, "TRY")
                .Set(payu.Constants.CustomerIp, "127.0.0.1")
                .Set(payu.Constants.ExtOrderId, "ExtOrderId0")
                .Set(payu.Constants.MerchantPosId, "OPU_TEST")
                .Set(payu.Constants.Description, nvc["Description"])
                .Set(payu.Constants.TotalAmount, nvc["Amount"]);

            conf.SetBuyer(payu.Constants.FirstName, nvc["FirstName"])
                .SetBuyer(payu.Constants.LastName, nvc["LastName"])
                .SetBuyer(payu.Constants.CountryCode, "tr")
                .SetBuyer(payu.Constants.Email, nvc["Email"])
                .SetBuyer(payu.Constants.PhoneNumber, nvc["Phone"])
                .SetBuyer(payu.Constants.Language, "en");

            conf.SetProduct(payu.Constants.Name, "My Product1 Name")
                .SetProduct(payu.Constants.UnitPrice, "75")
                .SetProduct(payu.Constants.Quantity, "2")
                .Update();

            conf.SetProduct(payu.Constants.Name, "My Product 2 Name")
                .SetProduct(payu.Constants.UnitPrice, "40")
                .SetProduct(payu.Constants.Quantity, "1")
                .Update();

            conf.Set(payu.Constants.PayMethod, "DEFAULT")
                .Completed();

            string JsonStr = "";
            string XMLStr = "";
            XmlDocument doc = new XmlDocument();

            if (PayuLib.Request.Complete(conf)) {
                XMLStr = payu.Response.GetXMLString();
                
                doc.LoadXml(XMLStr);                
                JsonStr = PayuLib.JsonSerializer.XmlToJSON(doc);
            } else {
                
            }
            Response.AddHeader("Content-type", "text/json");
            Response.Write(JsonStr);
        }
    }

}