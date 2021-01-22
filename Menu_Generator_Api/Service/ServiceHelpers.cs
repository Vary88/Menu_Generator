using Menu_Generator.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Menu_Generator_Api.Service
{
    public static class ServiceHelpers
    {
        private const string Code_Node = "code";
        private const string Name_Node = "details";
        private const string Calorie_Node = "calorie";
        private const string Carbonhydrate_Node = "carbohydrate";
        private const string Protein_Node = "protein";
        private const string Fat_Node = "fat";
        private const string Category_Node = "category";
        private const string Day_Node = "whichDay";

        public static List<ProductWrapper> GetAllProductFromXml()
        {
            var filename = "Products.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine($"{currentDirectory}/TestData", filename);

            XDocument productsXml = XDocument.Load(purchaseOrderFilepath);
            List<ProductWrapper> result = productsXml.Descendants("product").ToList().Select(x =>
            new ProductWrapper()
            {
                Code = x.Element(Code_Node).Value,
                Name = x.Element(Name_Node).Value,
                Category = x.Element(Category_Node).Value,
                Calorie = x.Element(Calorie_Node).Value.ParseInt(),
                Carbohydrate = x.Element(Carbonhydrate_Node).Value.ParseInt(),
                Protein = x.Element(Protein_Node).Value.ParseInt(),
                Fat = x.Element(Fat_Node).Value.ParseInt(),
                Day = x.Element(Day_Node).Value
            }).Where(x => x.Protein != null).ToList();

            return result.Where(x => x.Category != "Menu").ToList(); //TODO: get rid of the filter
        }
    }
}
