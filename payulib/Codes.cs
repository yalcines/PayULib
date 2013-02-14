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
                "Satıcı yanlış OpenPayu-Signature imza gönderdi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_UNKNOWN_MERCHANT_POS",
                "UNKNOWN_MERCHANT",
                "10910", 
                "Order",
                "Merchant not found in PayU system",
                "Satıcı PayU sisteminde bulunamadı."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "DATA_NOT_FOUND",
                "10920", 
                "Order",
                "Xml DOCUMENT not found or empty",
                "XML doküman yok ya da boş."
            });
            Status.Push(new string[] { 
                "OPENPAYU_SIGNATURE_INVALID",
                "SIGNATURE_INVALID",
                "10901", 
                "Order",
                "Invalid algoritm for signature.",
                "Signature imza için Geçersiz algoritma"
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
                "OrderCreateRequest içindeki alıcı bölümü geçersiz ya da eksik"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_BUYER_INVALID_EMAIL",
                "10802", 
                "Order",
                "Buyer email is invalid or missing.",
                "Müşteri E-posta adresi geçersiz ya da yok."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_BUYER_INVALID_FIRST_NAME",
                "10803", 
                "Order",
                "Buyer first name is invalid or missing",
                "Alıcı ilk adı geçeriz ya da eksik"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_BUYER_INVALID_LAST_NAME",
                "10804", 
                "Order",
                "Buyer lat name is invalid or missing.",
                "Alıcı soyadı geçeriz ya da eksik"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_CURRENCY",
                "10805", 
                "Order",
                "Invalid currency (allowed options: TRY).",
                "Geçeriz para birimi (İzin verilen seçenek: TRY)."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_AMOUNT",
                "10806", 
                "Order",
                "Invalid amount",
                "Geçersiz miktar"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_INVOICE",
                "10850", 
                "Order",
                "Invalid invoice information in OrderCreateRequest",
                "OrderCreateRequest içinde geçersiz fatura bilgisi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_DELIVERY",
                "10870", 
                "Order",
                "Invalid delivery information in OrderCreateRequest",
                "OrderCreateRequest içinde geçersiz teslimat adresi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_PRODUCTS",
                "10820", 
                "Order",
                "Invalid products information in OrderCreateRequest.",
                "OrderCreateRequest içinde geçersiz ürün bilgisi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_MISSING",
                "ORDER_MISSING_PRODUCTS",
                "10821", 
                "Order",
                "Missing products information in OrderCreateRequest.",
                "OrderCreateRequest içinde eksik ürün bilgisi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID_PRODUCT",
                "10830", 
                "Order",
                "A product has invalid information in OrderCreateRequest.",
                "OrderCreateRequest içinde bir ürün geçersiz bilgiye sahip."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "ORDER_INVALID",
                "10703", 
                "Payment or InstallmentPayment",
                "Error load order.",
                "Sipariş yükleme hatası"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "INVALID_ORDER_ID",
                "10704", 
                "Payment or InstallmentPayment",
                "Error load order.",
                "Sipariş yükleme hatası"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "INVALID_PAY_METHOD",
                "10701", 
                "Payment or InstallmentPayment",
                "Not credit card payment method.",
                "Kredi kart ödeme yönetmi değil."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "INVALID_PAY_METHOD",
                "10702", 
                "Payment or InstallmentPayment",
                "Merchant don't support this payment method.",
                "Alıcı bu ödeme yönetimini desteklemiyor."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "TRANSACTION_PROCESSING_PROBLEMS",
                "10710", 
                "Payment or InstallmentPayment",
                "Could not load merchant gateway.",
                "Alıcı geçidi yüklenemedi"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "TRANSACTION_GENERAL_ERROR",
                "10500to10599", 
                "Payment or InstallmentPayment",
                "Authorization failed by some internal reason.",
                "Bazı iç nedenlerden dolayı yetkilendirme başarısız."
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
                "Bankadan geçersiz cevabı alındı"
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_INTERNAL",
                "ALREADY_AUTHORIZED",
                "10752", 
                "Payment or InstallmentPayment",
                "Order is allready authorize.",
                "Sipariş önceden yetkilendirildi."
            });
            Status.Push(new string[] { 
                "OPENPAYU_WARNING_CONTINUE_3DS",
                "OPENPAYU_WARNING_CONTINUE_3DS",
                "3", 
                "Payment or InstallmentPayment",
                "Payment will continue in 3DSecure. Process is handle automatically by OpenPayU",
                "Ödeme 3D secure devam edecek. Proses OpenPayU tarafından otomatik gerçekleştirilecek."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "UNSUPPORTED_INSTALLMENT_NUMBER",
                "10101,10201", 
                "InstallmentPayment",
                "This order can't be paid with this number of installments. Buyer can try to pay in one time with this card.",
                "Bu sipariş için bu taksit sayısıyla ödeme olamaz. Alıcı tek çekimde ödemeyi denemelidir."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "NOT_CREDIT_CARD",
                "10102,10202", 
                "InstallmentPayment",
                "Card used for this payment is not a credit card. Buyer can try to pay in one time with this card.",
                "Bu ödeme için kullanılan kart, bir kredi kartı değildir. Alıcı tek çekimde ödemeyi denemelidir."
            });
            Status.Push(new string[] { 
                "OPENPAYU_ERROR_VALUE_INVALID",
                "UNSUPPORTED_LOYALTY_PROGRAM",
                "10103,10203", 
                "InstallmentPayment",
                "Card is enrolled in a loyalty program unsupported by this order or merchant. Buyer can try to pay in one time with this card.",
                "Kart bu emir veya tüccar tarafından desteklenmeyen bir sadakat programı kayıtlı. Alıcı tek çekimde ödemeyi denemelidir."
            });
            Status.Push(new string[] {
                "OPENPAYU_SUCCESS",
                "SUCCESS", 
                "0", 
                "Any Location",
                "Action finish successfully. Depend of locatation aditional information will be receive.",
                "İşlem başarıyla tamamlandı. Ek bilgiler e-posta adresinize gönderilecek."
            });
        }
    }
}