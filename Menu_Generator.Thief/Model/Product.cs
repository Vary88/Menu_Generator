using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Thief.Model
{
    public class Product
    {
        public Product(
            string code = null,
            string category = null,
            string subCategory = null,
            int? price = null,
            bool? weeklyMenu = null,
            string details = null,
            string whichDay = null,
            bool? soldOut = null,
            int? calorie = null,
            int? carbohydrate = null,
            int? sugar = null,
            int? protein = null,
            int? fat = null,
            int? saturatedFattyAcid = null,
            int? salt = null)
        {
            Code = code;
            Category = category;
            SubCategory = subCategory;
            Price = price;
            WeeklyMenu = weeklyMenu;
            Details = details;
            WhichDay = whichDay;
            SoldOut = soldOut;
            Calorie = calorie;
            Carbohydrate = carbohydrate;
            Sugar = sugar;
            Protein = protein;
            Fat = fat;
            SaturatedFattyAcid = saturatedFattyAcid;
            Salt = salt;
        }

        public string Code { get; }
        public string Category { get; }
        public string SubCategory { get; }
        public int? Price { get; }
        public bool? WeeklyMenu { get; }
        public string Details { get; }
        public string WhichDay { get; }
        public bool? SoldOut { get; }
        public int? Calorie { get; }
        public int? Carbohydrate { get; }
        public int? Sugar { get; }
        public int? Protein { get; }
        public int? Fat { get; }
        public int? SaturatedFattyAcid { get; }
        public int? Salt { get; }
    }
}

