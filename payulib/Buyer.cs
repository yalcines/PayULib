﻿/************************************************************
 Payu Asp.Net Entegrasyon için Sınıf Kütüphanesi dosyası
 Yazan Vefa Kayacı <vefakayaci@gmail.com>
 http://www.gurafe.com
 Kullanımında ve dağıtımında herhangi bir kısıt yoktur
 ************************************************************/

using System.Collections;

namespace PayuConfig {
    public static class Buyer {
        public static Hashtable My;

        public static void reset() {
            My = new Hashtable();
        }

        public static void Add(string key, string val) {
            My.Add(key, val);
        }
    }
}
