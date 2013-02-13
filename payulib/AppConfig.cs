﻿/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/
using System.Collections.Generic;
using System.Collections;
using PC = PayuConfig;

namespace PayuLib
{
    public class AppConfig 
    {
        public static Hashtable My;
        public Hashtable ProductSpec;
        public Hashtable ProductItem;
        public static Stack<Hashtable> ProductArray;
        public string SignatureKey;
        public string Environment = "https://secure.payu.com.tr/openpayu/v2/order.xml";
        public string CurrentVersion = "TR";

        public void SetEnvironment(string url) 
        {
            Environment = url;
        }

        public void SetSignatureKey(string SecretKey)
        {
            SignatureKey = SecretKey;
        }
        
        public AppConfig() 
        {
            PC.Codes.Generate();
            ProductArray = new Stack<Hashtable>();
            My = new Hashtable();
            PC.Buyer.reset();
            PC.Product.reset();
            ProductSpec = new Hashtable();
            ProductItem = new Hashtable();
        }

        public AppConfig Set(string key, string val) 
        {
            My.Add(key, val);
            return this;
        }

        public AppConfig SetBuyer(string key, string val) {
            PC.Buyer.Add(key, val); 
            return this;
        }

        public AppConfig SetProduct(string key, string val) 
        {
            ProductSpec.Add(key, val);
            return this;
        }

        public AppConfig Update() 
        {
            ProductItem.Add("Product", ProductSpec);
            ProductArray.Push(ProductItem);
            ProductSpec = new Hashtable();
            ProductItem = new Hashtable();
            PC.Product.reset();
            return this;
        }
        
        public AppConfig Completed() {
            My.Add("Buyer", PC.Buyer.My);
            My.Add("Products", ProductArray);
            PayuLib.PayuInternals.GenerateSystemMessages();
            return this;
        }
    }
}