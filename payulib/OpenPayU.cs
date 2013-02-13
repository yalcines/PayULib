﻿/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/
using System.Xml;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Net;


namespace PayuLib {
    public static class OpenPayU 
    {
        private static Random rnd = new Random();
        public static string buildOpenPayUDocument(object config,
            string startElement = "OrderCreateRequest", int request = 1, 
            string xml_version = "1.0", string xml_encoding = "UTF-8") 
        {
            if (config.GetType().ToString() != "System.Collections.Hashtable") {
                return null;
            }      
            StringWriter sw = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(sw);            
            writer.WriteStartElement(startElement);
            Hashtable data1 = config as Hashtable;
            OpenPayU.arr2xml(writer, data1);
            writer.WriteEndElement();
            writer.Flush();
            StringBuilder sb = new StringBuilder();
            string xmlString = sb.AppendFormat(PayuLib.PayuInternals.xmlStringFormat, sw.ToString()).ToString();
            
            string xmlStringOLD = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                   "<OpenPayU xmlns=\"http://www.openpayu.com/openpayu.xsd\">" + 
                   sw.ToString() + "</OpenPayU>";
            writer.Close();
            sw.Close();
            return xmlString;
        }

        private static void arr2xml(XmlWriter xml, Hashtable data) {
            string substr = "";
            int status = 0;
            if (data != null && data.GetType().ToString() == "System.Collections.Hashtable") {
                foreach (DictionaryEntry item in data) {
                    if (item.Value.GetType().ToString() == "System.Collections.Hashtable") {
                        xml.WriteStartElement(item.Key.ToString());
                        Hashtable v2 = item.Value as Hashtable;
                        OpenPayU.arr2xml(xml, v2);
                        xml.WriteEndElement();
                        status = 0;
                        continue;
                    } else {
                        status = 0;
                        substr = item.Value.GetType().ToString();
                        if (substr.Length > 30)
                            substr = item.Value.GetType().ToString().Substring(0, 32);
                        if (substr == "System.Collections.Generic.Stack") {
                            xml.WriteStartElement(item.Key.ToString());
                            status = 1;
                            Stack<Hashtable> v3 = item.Value as Stack<Hashtable>;
                            foreach (Hashtable item2 in v3) {

                                Hashtable v4 = item2 as Hashtable;
                                OpenPayU.arr2xml(xml, v4);

                            }
                            xml.WriteEndElement();
                            continue;
                        }
                    }
                    if (status == 0)
                        xml.WriteElementString(item.Key.ToString(), item.Value.ToString());
                    status = 0;
                }
            }
        }

        public static string sendOpenPayuDocumentAuth(string xml, string merchantPosId,
            string signatureKey, string openPayuEndPointUrl, AppConfig config) 
        {
            if (openPayuEndPointUrl == "") {
                throw new Exception(PayuLib.SystemMessages.getMessage(config.CurrentVersion, PayuLib.SystemMessages.openPayuEndPointUrl));
            }

            if (signatureKey == null || signatureKey == "") {
                throw new Exception(PayuLib.SystemMessages.getMessage(config.CurrentVersion, PayuLib.SystemMessages.signatureKey));
            }

            if (merchantPosId == null || merchantPosId == "") {
                throw new Exception(PayuLib.SystemMessages.getMessage(config.CurrentVersion, PayuLib.SystemMessages.merchantPosId));
            }
            string tosigndata = xml + signatureKey;
            xml = System.Web.HttpUtility.UrlEncode(xml);
            string signature = OpenPayU.PayuSHA256(tosigndata);
            
            StringBuilder sb = new StringBuilder();
            string authData = sb.AppendFormat(PayuLib.PayuInternals.auth_data_string_format, merchantPosId, signature).ToString();
            string authData2 = "OpenPayu-Signature:sender=" + merchantPosId +
                    ";signature=" + signature +
                    ";algorithm=SHA256" +
                    ";content=DOCUMENT";
            string response = "";
            response = OpenPayU.sendDataAuth(openPayuEndPointUrl, "DOCUMENT=" + xml, authData);
            return response;
        }
        private static string PayuSHA256(string str) {
            SHA256 shaM = new SHA256Managed();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(str);
            string result = BitConverter.ToString(shaM.ComputeHash(inputBytes))
                    .Replace("-", string.Empty)
                    .ToLower();
            return result;
        }
        public static string sendDataAuth(string url, string doc, string authData) 
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(doc);            
            WebRequest request = WebRequest.Create(url);  
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.Headers.Add(authData);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        public static bool IsNumeric(string text) 
        {
            return Regex.IsMatch(text, "^\\d+$");
        }

        public static string gen_uuid() {
            string uuid =
                OpenPayU.ForBitHex() + OpenPayU.ForBitHex() +
                OpenPayU.ForBitHex() + "-" + OpenPayU.ForBitHex() + "-" + OpenPayU.ForBitHex() + "-" +
                OpenPayU.ForBitHex() + OpenPayU.ForBitHex() + OpenPayU.ForBitHex();
            return uuid.ToLower();
        }

        private static string ForBitHex() {
            string hexString = "";
            var buffer = new byte[sizeof(UInt16)];
            OpenPayU.rnd.NextBytes(buffer);
            hexString = BitConverter.ToUInt16(buffer, 0).ToString("X");
            string Zeros = new StringBuilder().Insert(0, "0", 4 - Convert.ToInt32(hexString.Length)).ToString();
            return Zeros + hexString;
        }

    }
}