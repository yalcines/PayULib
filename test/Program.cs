/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/

using System;
using payu = PayuLib;
using PayuLib;
namespace PayuLib {
    class Program {
        static void Main(string[] args) {
            payu.AppConfig conf = new payu.AppConfig();

            conf.SetSignatureKey("SECRET_KEY");
            conf.SetEnvironment("https://secure.payu.com.tr/openpayu/v2/order.xml");
            conf.CurrentVersion = "TR";
            conf.Set(payu.Constants.ReqId, payu.OpenPayU.gen_uuid())
                .Set(payu.Constants.CurrencyCode, "TRY")
                .Set(payu.Constants.CustomerIp, "127.0.0.1")
                .Set(payu.Constants.ExtOrderId, "ExtOrderId0")
                .Set(payu.Constants.MerchantPosId, "OPU_TEST")
                .Set(payu.Constants.Description, "My Description")
                .Set(payu.Constants.TotalAmount, "190");

            conf.SetBuyer(payu.Constants.FirstName, "Vefa")
                .SetBuyer(payu.Constants.LastName, "Kayacı")
                .SetBuyer(payu.Constants.CountryCode, "tr")
                .SetBuyer(payu.Constants.Email, "wefra@yahoo.com")
                .SetBuyer(payu.Constants.PhoneNumber, "09995320000")
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

            if (PayuLib.Request.Complete(conf)) {
                string XMLStr = payu.Response.GetXMLString();
                //Console.WriteLine(XMLStr);
            } else {
                //Console.WriteLine(payu.Response.GetErrorMessage());
            }
            Console.WriteLine("Payu Sunucuya Gönderilen XML İfade: " + Response.GetLOG(Request.VALUE_XML_REQUEST));
            Console.WriteLine("\nPayu Sunucudan Dönen XML İfade: " + Response.GetLOG(Request.VALUE_XML_RESPONSE));
            Console.WriteLine("\nİşlemlerden Dönen Kod " + Response.GetLOG(Request.VALUE_ERROR));
            Console.Read();
        }
    }
}