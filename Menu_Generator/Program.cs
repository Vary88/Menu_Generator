using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Menu_Generator.Core;

namespace Menu_Generator
{
    class Program
    {
        private const string Code_Node = "code";
        private const string Name_Node = "details";
        private const string Calorie_Node = "calorie";
        private const string Carbonhydrate_Node = "carbohydrate";
        private const string Protein_Node = "protein";
        private const string Fat_Node = "fat";
        private const string Category_Node = "category";
        private const string Day_Node = "whichDay";
        static void Main(string[] args)
        {
            List<ProductWrapper> allProduct = GetAllProductFromXml();
            GetMenuRequest getMenuRequest = new GetMenuRequest()
            {
                CH = 509,
                Protein = 168,
                Fat = 129,
                IsMenuIncluded = false,
                CategoriesFilters = new List<CategoriesFilter>()
                {
                    new CategoriesFilter()
                    {
                        Category = Categories.Breakfast,
                        AmountAtLeast = 1,
                        AmountFlexible_Plus = 4
                    },
                    new CategoriesFilter()
                    {
                        Category = Categories.Soup,
                        AmountAtLeast = 1,
                        AmountFlexible_Plus = 2
                    },
                    new CategoriesFilter()
                    {
                        Category = Categories.Freshschnitzel,
                        AmountAtLeast = 2,
                        AmountFlexible_Plus = 6
                    },
                    new CategoriesFilter()
                    {
                        Category = Categories.Dish,
                        AmountAtLeast = 2,
                        AmountFlexible_Plus = 6
                    }
                }
            };

            Console.WriteLine("-----PARAMTERS-----");
            Console.WriteLine($"Protein: {getMenuRequest.Protein}");
            Console.WriteLine($"Carbohydrate: {getMenuRequest.CH}");
            Console.WriteLine($"Fat: {getMenuRequest.Fat}");
            getMenuRequest.CategoriesFilters.ForEach(x => Console.WriteLine($"{x.Category}: {x.AmountAtLeast} db."));

            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine("-----RESULTS-----");
            List<IEnumerable<ProductWrapper>> dailyMenus = GetMenu(DayOfWeek.Tuesday, allProduct, getMenuRequest);
            foreach (var dailyMenu in dailyMenus)
            {
                Console.WriteLine($"Calorie: {dailyMenu.Sum(x => x.Calorie)}");
                Console.WriteLine($"Protein: {dailyMenu.Sum(x => x.Protein)}");
                Console.WriteLine($"Carbohydrate: {dailyMenu.Sum(x => x.Carbohydrate)}");
                Console.WriteLine($"Fat: {dailyMenu.Sum(x => x.Fat)}");
                dailyMenu.GroupBy(x => x.Category).ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Count()} db."));
                Console.WriteLine();
                Console.WriteLine();
                dailyMenu.ToList().ForEach(x => Console.WriteLine($"{x.Category} - {x.Name}"));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        private static List<IEnumerable<ProductWrapper>> GetMenu(DayOfWeek day, List<ProductWrapper> allProduct, GetMenuRequest getMenuRequest)
        {
            List<ProductWrapper> result = new List<ProductWrapper>();
            List<ProductWrapper> dailyProducts = allProduct.Where(x => x.Day == day.ToString()).ToList();
            return dailyProducts.CalculateMenu(getMenuRequest);
        }
        private static List<ProductWrapper> GetAllProductFromXml()
        {
            var filename = "Products.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine($"{currentDirectory}/../../..", filename);

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
