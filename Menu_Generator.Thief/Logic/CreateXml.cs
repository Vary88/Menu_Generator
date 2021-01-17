using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using Menu_Generator.Common;
using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief.Logic
{
    public class CreateXml
    {
        private CreateXml() { }
        public static void Create(Products products, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement xProducts = doc.CreateElement(string.Empty, "Produts", string.Empty);
            doc.AppendChild(xProducts);

            foreach (Product product in products.Items)
            {
                XmlElement xProduct = doc.CreateElement(string.Empty, "Product", string.Empty);
                xProducts.AppendChild(xProduct);

                XmlElement code = doc.CreateElement(string.Empty, Const.Code_Node, string.Empty);
                XmlText codeValue = doc.CreateTextNode(product.Code);
                code.AppendChild(codeValue);
                xProduct.AppendChild(code);

                XmlElement category = doc.CreateElement(string.Empty, Const.Category_Node, string.Empty);
                XmlText categoryValue = doc.CreateTextNode(product.Category);
                category.AppendChild(categoryValue);
                xProduct.AppendChild(category);

                XmlElement subCategory = doc.CreateElement(string.Empty, "SubCategory", string.Empty);
                XmlText subCategoryValue = doc.CreateTextNode(product.SubCategory);
                subCategory.AppendChild(subCategoryValue);
                xProduct.AppendChild(subCategory);

                XmlElement price = doc.CreateElement(string.Empty, "Price", string.Empty);
                XmlText priceValue = doc.CreateTextNode(product.Price.ToString());
                price.AppendChild(priceValue);
                xProduct.AppendChild(price);

                XmlElement weeklyMenu = doc.CreateElement(string.Empty, "WeeklyMenu", string.Empty);
                XmlText weeklyMenuValue = doc.CreateTextNode(product.WeeklyMenu.ToString());
                weeklyMenu.AppendChild(weeklyMenuValue);
                xProduct.AppendChild(weeklyMenu);

                XmlElement details = doc.CreateElement(string.Empty, Common.Const.Name_Node, string.Empty);
                XmlText detailsValue = doc.CreateTextNode(product.Details);
                details.AppendChild(detailsValue);
                xProduct.AppendChild(details);

                XmlElement whichDay = doc.CreateElement(string.Empty, Common.Const.Day_Node, string.Empty);
                XmlText whichDayValue = doc.CreateTextNode(product.WhichDay);
                whichDay.AppendChild(whichDayValue);
                xProduct.AppendChild(whichDay);

                XmlElement soldOut = doc.CreateElement(string.Empty, "SoldOut", string.Empty);
                XmlText soldOutValue = doc.CreateTextNode(product.SoldOut.ToString());
                soldOut.AppendChild(soldOutValue);
                xProduct.AppendChild(soldOut);

                XmlElement calorie = doc.CreateElement(string.Empty, Common.Const.Calorie_Node, string.Empty);
                XmlText calorieValue = doc.CreateTextNode(product.Calorie.ToString());
                calorie.AppendChild(calorieValue);
                xProduct.AppendChild(calorie);

                XmlElement carbohydrate = doc.CreateElement(string.Empty, Common.Const.Carbonhydrate_Node, string.Empty);
                XmlText carbohydrateValue = doc.CreateTextNode(product.Carbohydrate.ToString());
                carbohydrate.AppendChild(carbohydrateValue);
                xProduct.AppendChild(carbohydrate);

                XmlElement sugar = doc.CreateElement(string.Empty, "Sugar", string.Empty);
                XmlText sugarValue = doc.CreateTextNode(product.Sugar.ToString());
                sugar.AppendChild(sugarValue);
                xProduct.AppendChild(sugar);

                XmlElement protein = doc.CreateElement(string.Empty, Common.Const.Protein_Node, string.Empty);
                XmlText proteinValue = doc.CreateTextNode(product.Protein.ToString());
                protein.AppendChild(proteinValue);
                xProduct.AppendChild(protein);

                XmlElement fat = doc.CreateElement(string.Empty, "Fat", string.Empty);
                XmlText fatValue = doc.CreateTextNode(product.Fat.ToString());
                fat.AppendChild(fatValue);
                xProduct.AppendChild(fat);

                XmlElement saturatedFattyAcid = doc.CreateElement(string.Empty, "SaturatedFattyAcid", string.Empty);
                XmlText saturatedFattyAcidValue = doc.CreateTextNode(product.SaturatedFattyAcid.ToString());
                saturatedFattyAcid.AppendChild(saturatedFattyAcidValue);
                xProduct.AppendChild(saturatedFattyAcid);

                XmlElement salt = doc.CreateElement(string.Empty, "Salt", string.Empty);
                XmlText saltValue = doc.CreateTextNode(product.Salt.ToString());
                salt.AppendChild(saltValue);
                xProduct.AppendChild(salt);
            }
            doc.Save(filePath);
        }
    }
}
