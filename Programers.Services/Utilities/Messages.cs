﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programers.Services.Utilities
{
    public static class Messages
    {
        // Messages.Category.NotFound()
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kategori bulunamadı.";
                return "Böyle bir kategori bulunamadı.";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla arşivden geri getirilmiştir.";
            }
        }

        public static class Product
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Ürün bulunamadı.";
                return "Böyle bir ürün bulunamadı.";
            }
            public static string Add(string productTitle)
            {
                return $"{productTitle} başlıklı ürün başarıyla eklenmiştir.";
            }

            public static string Update(string productTitle)
            {
                return $"{productTitle} başlıklı ürün başarıyla güncellenmiştir.";
            }
            public static string Delete(string productTitle)
            {
                return $"{productTitle} başlıklı ürün başarıyla silinmiştir.";
            }
            public static string HardDelete(string productTitle)
            {
                return $"{productTitle} başlıklı ürün başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string productTitle)
            {
                return $"{productTitle} adlı ürün başarıyla arşivden geri getirilmiştir.";
            }
            public static string IncreaseViewCount(string productTitle)
            {
                return $"{productTitle} başlıklı ürün'nün okunma sayısı başarıyla arttırılmıştır.";
            }
        }
        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }

            public static string Approve(int commentId)
            {
                return $"{commentId} no'lu yorum başarıyla onaylanmıştır.";
            }
            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla arşivden geri getirilmiştir.";
            }

        }
    }
}
