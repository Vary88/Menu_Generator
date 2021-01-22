using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Menu_Generator.Core
{
    public static class MenuCalculator
    {
        public static List<IEnumerable<ProductWrapper>> CalculateMenu(this List<ProductWrapper> products, GetMenuRequest getMenuRequest)
        {
            List<ProductWrapper> result = new List<ProductWrapper>();
            var allProduct = getMenuRequest.IsMenuIncluded ? products : products.Where(x => !x.IsMenu).ToList();

            var usableProducts = getMenuRequest.CategoryFilters.Any() ? products.Where(x => getMenuRequest.CategoryFilters.Any(c => c.Category.ToString() == x.Category)) : allProduct;

            List<IEnumerable<ProductWrapper>> combinations = new List<IEnumerable<ProductWrapper>>();

            //TODO: restrict the max number of i (i means how many items will be in the set) --> maybe 10 different food will be enough
            for (int i = 1; i <= usableProducts.Count(); i++)
            {
                combinations.AddRange(usableProducts.DifferentCombinations(i).ToList());
            }

            var selectedCombination = new List<IEnumerable<ProductWrapper>>();

            foreach (var categoryFilter in getMenuRequest.CategoryFilters)
            {
                combinations.RemoveAll(combination => combination.Where(cx => cx.Category == categoryFilter.Category.ToString()).Count() < categoryFilter.AmountAtLeast);    
            }
            
            if (getMenuRequest.CH != null)
            {
                combinations = combinations
                .Where(combination => combination.Sum(c => c.Carbohydrate) > getMenuRequest.CH - 30
                        && combination.Sum(c => c.Carbohydrate) < getMenuRequest.CH + 30).ToList();
            }
            if (getMenuRequest.Protein != null)
            {
                combinations = combinations
                .Where(combination => combination.Sum(c => c.Protein) > getMenuRequest.Protein - 30
                        && combination.Sum(c => c.Protein) < getMenuRequest.Protein + 30).ToList();
            }
            if (getMenuRequest.Fat != null)
            {
                combinations = combinations
                .Where(combination => combination.Sum(c => c.Fat) > getMenuRequest.Fat - 40
                        && combination.Sum(c => c.Fat) < getMenuRequest.Fat + 40).ToList();
            }

            return combinations;
        }

        public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }
}
