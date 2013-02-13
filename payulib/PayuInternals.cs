﻿/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/
using System.Collections;

namespace PayuLib 
{
    public static class PayuInternals 
    {
        public static string startElement = "startElement";   

        public static string xmlStringFormat = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><OpenPayU xmlns=\"http://www.openpayu.com/openpayu.xsd\">{0}</OpenPayU>";

        public static Hashtable systemMessages;
        public static string auth_data_string_format = "OpenPayu-Signature:sender={0};signature={1};algorithm=SHA256;content=DOCUMENT";

        public static string LOG = "Request XML: {0}\nResponse XML: {1}\nPayuLib Messages: {2}";

        public static void GenerateSystemMessages() 
        {

        }
    }
}