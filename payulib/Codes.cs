﻿/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/
using System.Collections.Generic;

namespace PayuConfig
{
    public static class Codes 
    {
        public static int StatusCode = 0;
        public static int CodeLiteral = 1;
        public static int Code = 2;
        public static int Location = 3;
        public static int i18nEN = 4;
        public static int i18nTR = 5;
        public static Stack<string[]> Status;

        public static string[] GetCode(string Code, string version) 
        {
            Stack<string[]> st = Codes.Status as Stack<string[]>;
            foreach (string[] item in st) {
                if (Code == item[2]) {
                    return item;
                }
            }
            return null;
        }

        public static void Generate()
        {            
            Codes.Status = new Stack<string[]>();
            Status.Push(new string[] { 
                "OPENPAYU_SIGNATURE_INVALID",
                "SIGNATURE_INVALID",
                "10900", 
                "Order",
                "Merchant send wrong OpenPayu-Signature in header.",
                "SatÄ±cÄ± yanlÄ±ÅŸ OpenPayu-Signature imza gÃ¶nderdi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_UNKNOWN_MERCHANT_POS",
                "UNKNOWN_MERCHANT",
                "10910", 
                "Order",
                "Merchant not found in PayU system",
                "SatÄ±cÄ± PayU sisteminde bulunamadÄ±."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "DATA_NOT_FOUND",
                "10920", 
                "Order",
                "Xml DOCUMENT not found or empty",
                "XML dokÃ¼man yok ya da boÅŸ."
            });
            Status.Push(new string[] { 
                "OPENPAYU_SIGNATURE_INVALID",
                "SIGNATURE_INVALID",
                "10901", 
                "Order",
                "Invalid algoritm for signature.",
                "Signature imza iÃ§in GeÃ§ersiz algoritma"
            });
            Status.Push(new string[] { 
                "OPENPAYU_SIGNATURE_INVALID",
                "SIGNATURE_INVALID",
                "10902", 
                "Order",
                "Signature not confirmed.",
                "Kimlik (Signature) konfirme edilemedi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_SIGNATURE_INVALID",
                "ORDER_BUYER_INVALID",
                "10801", 
                "Order",
                "Buyer node in OrderCreateRequest is invalid or missing.",
                "OrderCreateRequest iÃ§indeki alÄ±cÄ± bÃ¶lÃ¼mÃ¼ geÃ§ersiz ya da eksik"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_BUYER_INVALID_EMAIL",
                "10802", 
                "Order",
                "Buyer email is invalid or missing.",
                "MÃ¼ÅŸteri E-posta adresi geÃ§ersiz ya da yok."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_BUYER_INVALID_FIRST_NAME",
                "10803", 
                "Order",
                "Buyer first name is invalid or missing",
                "AlÄ±cÄ± ilk adÄ± geÃ§eriz ya da eksik"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_BUYER_INVALID_LAST_NAME",
                "10804", 
                "Order",
                "Buyer lat name is invalid or missing.",
                "AlÄ±cÄ± soyadÄ± geÃ§eriz ya da eksik"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_CURRENCY",
                "10805", 
                "Order",
                "Invalid currency (allowed options: TRY).",
                "GeÃ§eriz para birimi (Ä°zin verilen seÃ§enek: TRY)."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_AMOUNT",
                "10806", 
                "Order",
                "Invalid amount",
                "GeÃ§ersiz miktar"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_INVOICE",
                "10850", 
                "Order",
                "Invalid invoice information in OrderCreateRequest",
                "OrderCreateRequest iÃ§inde geÃ§ersiz fatura bilgisi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_DELIVERY",
                "10870", 
                "Order",
                "Invalid delivery information in OrderCreateRequest",
                "OrderCreateRequest iÃ§inde geÃ§ersiz teslimat adresi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_PRODUCTS",
                "10820", 
                "Order",
                "Invalid products information in OrderCreateRequest.",
                "OrderCreateRequest iÃ§inde geÃ§ersiz Ã¼rÃ¼n bilgisi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_MISSING",
                "ORDER_MISSING_PRODUCTS",
                "10821", 
                "Order",
                "Missing products information in OrderCreateRequest.",
                "OrderCreateRequest iÃ§inde eksik Ã¼rÃ¼n bilgisi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_PRODUCT",
                "10830", 
                "Order",
                "A product has invalid information in OrderCreateRequest.",
                "OrderCreateRequest iÃ§inde bir Ã¼rÃ¼n geÃ§ersiz bilgiye sahip."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID",
                "10703", 
                "Payment or InstallmentPayment",
                "Error load order.",
                "SipariÅŸ yÃ¼kleme hatasÄ±"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "INVALID_ORDER_ID",
                "10704", 
                "Payment or InstallmentPayment",
                "Error load order.",
                "SipariÅŸ yÃ¼kleme hatasÄ±"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "INVALID_PAY_METHOD",
                "10701", 
                "Payment or InstallmentPayment",
                "Not credit card payment method.",
                "Kredi kart Ã¶deme yÃ¶netmi deÄŸil."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "INVALID_PAY_METHOD",
                "10702", 
                "Payment or InstallmentPayment",
                "Merchant don't support this payment method.",
                "AlÄ±cÄ± bu Ã¶deme yÃ¶netimini desteklemiyor."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "TRANSACTION_PROCESSING_PROBLEMS",
                "10710", 
                "Payment or InstallmentPayment",
                "Could not load merchant gateway.",
                "AlÄ±cÄ± geÃ§idi yÃ¼klenemedi"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "TRANSACTION_GENERAL_ERROR",
                "10500to10599", 
                "Payment or InstallmentPayment",
                "Authorization failed by some internal reason.",
                "BazÄ± iÃ§ nedenlerden dolayÄ± yetkilendirme baÅŸarÄ±sÄ±z."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "GATEWAY_ERROR",
                "Code from gateway", 
                "Payment or InstallmentPayment",
                "Authorization declined.",
                "Yetkilendirme reddedildi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "INVALID_MESSAGE",
                "10751", 
                "Payment or InstallmentPayment",
                "Invalid response receive from bank.",
                "Bankadan geÃ§ersiz cevabÄ± alÄ±ndÄ±"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "ALREADY_AUTHORIZED",
                "10752", 
                "Payment or InstallmentPayment",
                "Order is allready authorize.",
                "SipariÅŸ Ã¶nceden yetkilendirildi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_WARNING_CONTINUE_3DS",
                "OPENPAYU_WARNING_CONTINUE_3DS",
                "3", 
                "Payment or InstallmentPayment",
                "Payment will continue in 3DSecure. Process is handle automatically by OpenPayU",
                "Ã–deme 3D secure devam edecek. Proses OpenPayU tarafÄ±ndan otomatik gerÃ§ekleÅŸtirilecek."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "UNSUPPORTED_INSTALLMENT_NUMBER",
                "10101,10201", 
                "InstallmentPayment",
                "This order can't be paid with this number of installments. Buyer can try to pay in one time with this card.",
                "Bu sipariÅŸ iÃ§in bu taksit sayÄ±sÄ±yla Ã¶deme olamaz. AlÄ±cÄ± tek Ã§ekimde Ã¶demeyi denemelidir."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "NOT_CREDIT_CARD",
                "10102,10202", 
                "InstallmentPayment",
                "Card used for this payment is not a credit card. Buyer can try to pay in one time with this card.",
                "Bu Ã¶deme iÃ§in kullanÄ±lan kart, bir kredi kartÄ± deÄŸildir. AlÄ±cÄ± tek Ã§ekimde Ã¶demeyi denemelidir."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "UNSUPPORTED_LOYALTY_PROGRAM",
                "10103,10203", 
                "InstallmentPayment",
                "Card is enrolled in a loyalty program unsupported by this order or merchant. Buyer can try to pay in one time with this card.",
                "Kart bu emir veya tÃ¼ccar tarafÄ±ndan desteklenmeyen bir sadakat programÄ± kayÄ±tlÄ±. AlÄ±cÄ± tek Ã§ekimde Ã¶demeyi denemelidir."
            });
            Status.Push(new string[] {
                "OPENPAYU_SUCCESS",
                "SUCCESS", 
                "0", 
                "Any Location",
                "Action finish successfully. Depend of locatation aditional information will be receive.",
                "Ä°ÅŸlem baÅŸarÄ±yla tamamlandÄ±. Ek bilgiler e-posta adresinize gÃ¶nderilecek."
            });
        }
    }
}