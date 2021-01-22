using Menu_Generator.Core;
using Menu_Generator_Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Menu_Generator_Api.Service
{
    public class MenuGeneratorService
    {
        public List<IEnumerable<ProductWrapper>> GetMenu(GetMenuRequest request)
        {
            List<ProductWrapper> products = ServiceHelpers.GetAllProductFromXml().Where(x => x.Day == request.Day.ToString()).ToList();
            var result = MenuCalculator.CalculateMenu(products, request);

            return result;
        }   
    }
}
