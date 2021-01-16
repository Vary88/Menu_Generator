using Menu_Generator.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menu_Generator_Api.Models
{
    public class IndexVM
    {
        public IndexVM()
        {
            Menus = new List<IEnumerable<ProductWrapper>>();
        }

        public int? CarboHydrate { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? CarboHydrateFlexibility { get; set; }
        public int? ProteinFlexibility { get; set; }
        public int? FatFlexibility { get; set; }
        public List<IEnumerable<ProductWrapper>> Menus { get; set; }
    }
}
