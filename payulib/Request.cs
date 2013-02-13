﻿/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/
using System;
using System.Collections;
using payu = PayuLib;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;
namespace PayuLib {
    public static class Request {
        public static int VALUE_XML_REQUEST = 0;
        public static int VALUE_XML_RESPONSE = 1;
        public static int VALUE_ERROR = 2;

        private static string[] LOG = { "", "", "" };
        /// <summary>
        /// Girilen parametrelerle request başlatır ve response bilgileri ile döner
        /// </summary>
        /// <param name="config">PayuLib.Config türünde configurations</param>
        /// <returns></returns>
        public static bool Complete(AppConfig config) {
            try {
                Hashtable cnf = AppConfig.My;
                string account = cnf[PayuLib.Constants.MerchantPosId].ToString();
                string secretKey = config.SignatureKey;
                string openPayuEndPointUrl = config.Environment;
                string xml = OpenPayU.buildOpenPayUDocument(cnf);
                Request.LOG[VALUE_XML_REQUEST] = xml;
                string responseXMLstring = OpenPayU.sendOpenPayuDocumentAuth(
                    xml, account, secretKey, openPayuEndPointUrl, config);
                Request.LOG[VALUE_XML_RESPONSE] = responseXMLstring;
                Response.SetXMLString(responseXMLstring);
                Request.setResponse(responseXMLstring);
                if (Response.Succes(config.CurrentVersion)) {
                    Request.LOG[VALUE_ERROR] = Response.GetErrorMessage();
                    return true;
                } else {
                    Request.LOG[VALUE_ERROR] = Response.GetErrorMessage();
                    return false;
                }
            } catch (Exception e) {
                Response.SetErrorMessage("Library Exception: " + e.Message);
                Request.LOG[VALUE_ERROR] = Response.GetErrorMessage();
                return false;
            }
        }

        public static string GetLOG(int indice) {
            return Request.LOG[indice];
        }

        public static void setResponse(string xmlString) {
            string element = "", value = "";
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString))) {
                while (reader.Read()) {
                    switch (reader.NodeType) {
                        case XmlNodeType.Element:
                            element = reader.Name;
                            break;
                        case XmlNodeType.Text:
                            value = reader.Value;
                            Response.send(element, value);
                            break;
                    }
                }

            }
        }
    }
}
