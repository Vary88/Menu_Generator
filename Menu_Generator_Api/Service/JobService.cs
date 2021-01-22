using Menu_Generator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu_Generator_Api.Service
{
    public class JobService
    {
        public void GenerateCombinationFile(DayOfWeek day)
        {
            List<ProductWrapper> products = ServiceHelpers.GetAllProductFromXml().Where(x => x.Day == day.ToString()).ToList();
            List<IEnumerable<ProductWrapper>> combinations = new List<IEnumerable<ProductWrapper>>();
            for (int i = 1; i <= products.Count(); i++)
            {
                combinations.AddRange(products.DifferentCombinations(i).ToList());
            }
        }
    }
}
