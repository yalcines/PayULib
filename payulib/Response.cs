﻿/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/
using System.Text;
namespace PayuLib {
    public static class Response {
        private static string ErrorMessage = "Success";
        private static string XMLString;

        public static string ResId_ = "ResId";
        public static string MerchantPosId_ = "MerchantPosId";
        public static string ExtOrderId_ = "ExtOrderId";
        public static string OrderId_ = "OrderId";
        public static string Status_ = "Status";
        public static string StatusCode_ = "StatusCode";
        public static string Code_ = "Code";
        public static string CodeLiteral_ = "CodeLiteral";
        public static string Location_ = "Location";

        public static string ResId;
        public static string MerchantPosId;
        public static string ExtOrderId;
        public static string OrderId;
        public static string Status;
        public static string StatusCode;
        public static string Code;
        public static string CodeLiteral;
        public static string Location;

        public static bool Succes(string version) {
            string[] ResponseStrings = PayuConfig.Codes.GetCode(Response.Code, version);
            if (Response.Code == "0") {
                return true;
            } else {
                if (version == "EN")
                    Response.SetErrorMessage("Payu Network Error: " + ResponseStrings[PayuConfig.Codes.i18nEN]);
                if (version == "TR")
                    Response.SetErrorMessage("Payu Network Hata: " + ResponseStrings[PayuConfig.Codes.i18nTR]);
                return false;
            }
        }

        public static void send(string Element, string Value) {
            string el;
            el = Response.ResId_; if (Element == el) Response.ResId = Value;
            el = Response.MerchantPosId_; if (Element == el) Response.MerchantPosId = Value;
            el = Response.ExtOrderId_; if (Element == el) Response.ExtOrderId = Value;
            el = Response.OrderId_; if (Element == el) Response.OrderId = Value;
            el = Response.StatusCode_; if (Element == el) Response.StatusCode = Value;
            el = Response.Code_; if (Element == el) Response.Code = Value;
            el = Response.CodeLiteral_; if (Element == el) Response.CodeLiteral = Value;
            el = Response.Location_; if (Element == el) Response.Location = Value;
        }

        public static string GetErrorMessage() {
            return Response.ErrorMessage;
        }

        public static string GetXMLString() {
            return Response.XMLString;
        }

        public static void SetErrorMessage(string err) {
            Response.ErrorMessage = err;
        }

        public static void SetXMLString(string xmlstr) {
            Response.XMLString = xmlstr;
        }

        public static string GetLOG(int logType) {

            return Request.GetLOG(logType);
        }
        public static string GetAllLOG() {
            StringBuilder sb = new StringBuilder();
            string str = sb.AppendFormat(PayuLib.PayuInternals.LOG, Request.GetLOG(0), Request.GetLOG(1), Request.GetLOG(2)).ToString();
            return str;
        }
    }
}
