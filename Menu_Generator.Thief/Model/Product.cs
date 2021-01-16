using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Thief.Model
{
    public class Product
    {
        private Product() { }
        public string Code { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public int Price { get; set; }
        public bool WeeklyMenu { get; set; }
        public string Details { get; set; }
        public string WhichDay { get; set; }
        public bool? SoldOut { get; set; }
        public int? Calorie { get; set; }
        public int? Carbohydrate { get; set; }
        public int? Sugar { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? SaturatedFattyAcid { get; set; }
        public int? Salt { get; set; }

        public static Product Create
            (
            string code,
            string category,
            string subCategory,
            int price,
            bool weeklyMenu,
            string details,
            string whichDay,
            bool? soldOut,
            int? calorie,
            int? Carbohydrate,
            int? sugar,
            int? protein,
            int? fat,
            int? saturatedFattyAcid,
            int? salt
            )
        {
            Product result = new Product();
            result.Code = code;
            result.Category = category;
            result.SubCategory = subCategory;
            result.Price = price;
            result.WeeklyMenu = weeklyMenu;
            result.Details = details;
            result.WhichDay = whichDay;
            result.SoldOut = soldOut;
            result.Calorie = calorie;
            result.Carbohydrate = Carbohydrate;
            result.Sugar = sugar;
            result.Protein = protein;
            result.Fat = fat;
            result.SaturatedFattyAcid = saturatedFattyAcid;
            result.Salt = salt;
            return result;
        }
    }
}
