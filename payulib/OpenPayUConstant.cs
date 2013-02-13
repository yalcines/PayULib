﻿/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/﻿
using PayuConfig;

namespace PayuLib {
    public static class OpenPayUConstant {
        //public static PayuConfig.Buyer Buyer;
        //public static PayuConfig.Product Product;

        public static string ReqId = "ReqId";
        public static string CustomerIp = "CustomerIp";
        public static string ExtOrderId = "ExtOrderId";
        public static string MerchantPosId = "MerchantPosId";
        public static string Description = "Description";
        public static string CurrencyCode = "CurrencyCode";
        public static string TotalAmount = "TotalAmount";
        public static string PayMethod = "PayMethod";

        public static string FirstName = "FirstName";
        public static string LastName = "LastName";
        public static string CountryCode = "CountryCode";
        public static string Email = "Email";
        public static string PhoneNumber = "PhoneNumber";
        public static string Language = "Language";

        public static string Name = "Name";
        public static string UnitPrice = "UnitPrice";
        public static string Quantity = "Quantity";

    }
}
