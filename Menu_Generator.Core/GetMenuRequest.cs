using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Core
{
    public class GetMenuRequest
    {
        public GetMenuRequest()
        {
            this.CategoriesFilters = new List<CategoriesFilter>();
        }    

        public int? CH { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? CHFlexibility { get; set; }
        public int? ProteinFlexibility { get; set; }
        public int? FatFlexibility { get; set; }
        public bool IsMenuIncluded { get; set; }
        public List<CategoriesFilter> CategoriesFilters { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
