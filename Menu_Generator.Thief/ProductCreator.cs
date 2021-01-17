using System;
using System.Collections.Generic;
using System.Text;

using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief
{
    public class ProductCreator : IProductCreator
    {
        #region Fields
        private string categoryColor = string.Empty;
        private List<Product> products = new List<Product>();
        private int tempWhichDay = 1;
        private bool tempWhichDayAssist = default(bool);
        private string tempSubCategory = string.Empty;
        private bool isRealProduct = default(bool);
        private bool isBreak = default(bool);

        private string code = string.Empty;
        private string category = string.Empty;
        private string subCategory = string.Empty;
        private int price = default(int);
        private bool weeklyMenu = default(bool);
        private string details = string.Empty;
        private string whichDay = string.Empty;
        private int calorie = default(int);
        private int carbohydrate = default(int);
        private int protein = default(int);
        private int fat = default(int);
        private int salt = default(int);
        private int saturatedFattyAcid = default(int);
        private int sugar = default(int);
        private bool soldOut = default(bool);
        #endregion

        public Products Create(DownLoadedData downloadData)
        {
            foreach (string[] arrayData in downloadData.Data)
            {
                if (isBreak)
                {
                    isBreak = false;
                    break;
                }
                
                for (int i = 0; i < arrayData.Length; i++)
                {
                    if (i == 0)
                    {
                        code = (arrayData[i].Split("</td>")[0].Split(">")[1]);
                        categoryColor = arrayData[i].Split("style=\"")[1].Split(";\">")[0];
                        CategoryOrganizer(categoryColor);
                        if (code == "MM")
                        {
                            category = "AllFreeDessert";
                        }
                    }
                    
                    if (i == 1)
                    {
                        if (code.Contains("M") && code != "MM" && !code.Contains("GM"))
                        {
                            details = arrayData[i].Split("<span class=\"mealname\">")[1].Split("</span><br>")[0];
                            tempSubCategory = details;
                        }
                        if (category != "Menu" && !code.Contains("GM"))
                        {
                            tempSubCategory = arrayData[i].Split("<i>")[1].Split("</i>")[0];
                        }
                    }
                    
                    if (i == 2)
                    {
                        if (!arrayData[i].Contains("</i>"))
                        {
                            PriceOrganizer(arrayData[i]);
                            weeklyMenu = true;
                            products.Add(new Product(code,
                                    category: category,
                                    price: price,
                                    weeklyMenu: weeklyMenu,
                                    details: details));
                        }
                    }
                    
                    if (i > 4)
                    {
                        if (arrayData[i].Contains("<td class=\"etlapcella col-nap"))
                        {
                            if (!code.Contains("GM"))
                            {
                                if (!arrayData[i].Contains("data-kaloria="))
                                {
                                    continue;
                                }
                                DetailsOrganizer(arrayData[i].Split("data-kaloria=")[1].Split("</span>")[0]);
                            }
                        }
                        
                        if (arrayData[i].Contains("\"etlapar\">"))
                        {
                            isRealProduct = true;
                            PriceOrganizer(arrayData[i]);
                        }
                        
                        if (arrayData[i].Contains("ELFOGYOTT!"))
                        {
                            soldOut = true;
                        }
                        
                        if (arrayData[i] == "</td>")
                        {
                            if (!code.Contains("M") && !code.Contains("GM"))
                            {
                                subCategory = tempSubCategory;
                            }
                            
                            else
                            {
                                subCategory = tempSubCategory.Split(" Heti Menü")[0];
                            }
                            
                            DayOrganizer(tempWhichDay);
                            weeklyMenu = false;

                            if (isRealProduct && !code.Contains("GM"))
                            {
                                products.Add(new Product(code,
                                        category,
                                        subCategory,
                                        price,
                                        weeklyMenu,
                                        details,
                                        whichDay,
                                        soldOut,
                                        calorie,
                                        carbohydrate,
                                        sugar,
                                        protein,
                                        fat,
                                        saturatedFattyAcid,
                                        salt));
                            }
                            tempWhichDayAssist = false;

                            if (tempWhichDay == 5)
                            {
                                tempWhichDayAssist = true;
                                tempWhichDay = 1;
                            }

                            if (!weeklyMenu && !tempWhichDayAssist && isRealProduct)
                            {
                                tempWhichDay++;
                            }

                            isRealProduct = false;
                        }
                    }

                    if (arrayData[i].Contains("Fine Dining"))
                    {
                        isBreak = true;
                        break;
                    }
                }
            }

            return new Products(products);
        }

        #region PrivateMethods
        private void PriceOrganizer(string arrayData)
        {
            StringBuilder builder = new StringBuilder();
            string tempPrice = arrayData.Split("class=\"etlapar\">")[1].Split("Ft</div>")[0].Trim();
            
            foreach (char item in tempPrice)
            {
                if (item != ' ')
                {
                    builder.Append(item);
                }
            }

            if (!Int32.TryParse(builder.ToString(), out price))
            {
                price = 0;
            }
        }
        private void DetailsOrganizer(string paramDetails)
        {
            string[] detailsElement = paramDetails.Split("data-cikkno=");
            details = detailsElement[1].Split("mealname\">")[1].Split("\"")[0];
            string[] ingredients = detailsElement[0].Split("=");

            for (int i = 0; i < ingredients.Length; i++)
            {
                int ingredient = Convert.ToInt32(ingredients[i].Split(" ")[0]);
                switch (i)
                {
                    case 0:
                        calorie = ingredient;
                        break;
                    case 1:
                        carbohydrate = ingredient;
                        break;
                    case 2:
                        protein = ingredient;
                        break;
                    case 3:
                        fat = ingredient;
                        break;
                    case 4:
                        salt = ingredient;
                        break;
                    case 5:
                        saturatedFattyAcid = ingredient;
                        break;
                    case 6:
                        sugar = ingredient;
                        break;
                }
            }
        }
        private void CategoryOrganizer(string categoryColor)
        {
            switch (categoryColor)
            {
                case "background-color:#ED1E24;color:#fff":
                    category = "Menu";
                    break;
                case "background-color:#F8931D;color:#fff":
                    category = "Soup";
                    break;
                case "background-color:#008039;color:#fff":
                    category = "Dish";
                    break;
                case "background-color:#3820ac;color:#fff":
                    category = "vegetable";
                    break;
                case "background-color:#1AF499;color:#fff":
                    category = "freshFried";
                    break;
                case "background-color:#9C4A9D;color:#fff":
                    category = "freshFriedMeatFree";
                    break;
                case "background-color:#AAF436;color:#fff":
                    category = "freshFriedLight";
                    break;
                case "background-color:#FF0000;color:#fff":
                    category = "Dessert";
                    break;
                case "background-color:#59F999;color:#fff":
                    category = "Pickles";
                    break;
                case "background-color:#76aa25;color:#fff":
                    category = "HealthyCuisineSpecial1";
                    break;
                case "background-color:#FFB914;color:#fff":
                    category = "Breakfast";
                    break;
                case "background-color:#2F9CFF;color:#fff":
                    category = "GlutenFree";
                    break;
            }
        }
        private void DayOrganizer(int tempWhichDay)
        {
            switch (tempWhichDay)
            {
                case 1:
                    whichDay = "Monday";
                    break;
                case 2:
                    whichDay = "Tuesday";
                    break;
                case 3:
                    whichDay = "Wednesday";
                    break;
                case 4:
                    whichDay = "Thursday";
                    break;
                case 5:
                    whichDay = "Friday";
                    break;
            }
        }
        #endregion
    }
}
