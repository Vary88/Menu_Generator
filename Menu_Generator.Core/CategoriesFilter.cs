using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Core
{
    public class CategoriesFilter
    {
        public Categories Category { get; set; }
        public int AmountAtLeast { get; set; }
        public int AmountFlexible_Plus { get; set; }
    }
}
