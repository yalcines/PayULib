﻿/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/
using System.Collections;

namespace PayuLib 
{    
    public static class SystemMessages
    {
        public static string currentVersion = "TR";
        public static string i18nTR = "TR";
        public static string i18nEN = "EN";

        public static string openPayuEndPointUrl = "openPayuEndPointUrl";
        public static string signatureKey = "signatureKey";
        public static string merchantPosId = "merchantPosId";

        public static string errOpenPayuEndPointUrlENG = "OpenPayuEndPointUrl is empty";
        public static string errSignatureKeyENG = "Merchant Signature Key should not be null or empty";
        public static string errMerchantPosIdENG = "MerchantPosId should not be null or empty.";

        public static string getMessage(string version, string key) 
        {
            
            Hashtable messagesEN = new Hashtable();
            messagesEN.Add(SystemMessages.openPayuEndPointUrl, "OpenPayuEndPointUrl is empty.");
            messagesEN.Add(SystemMessages.signatureKey, "Merchant Signature Key should not be null or empty.");
            messagesEN.Add(SystemMessages.merchantPosId, "MerchantPosId should not be null or empty.");
            Hashtable messagesTR = new Hashtable();
            messagesTR.Add(SystemMessages.openPayuEndPointUrl, "OpenPayuEndPointUrl boÅŸtur.");
            messagesTR.Add(SystemMessages.signatureKey, "MÃ¼ÅŸteri Signature Key null ya da emty olamaz.");
            messagesTR.Add(SystemMessages.merchantPosId, "MerchantPosId null ya da empty olamaz.");

            if (version == SystemMessages.i18nEN) {
                return messagesEN[key].ToString();
            }
            if (version == SystemMessages.i18nTR) {
                return messagesTR[key].ToString();
            }
            return null;
        }
    }
}