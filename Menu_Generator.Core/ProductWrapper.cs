using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Core
{
    public class ProductWrapper
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int? Calorie { get; set; }
        public int? Carbohydrate { get; set; }
        public int? Protein { get; set; }
        public int? Fat{ get; set; }
        public string Day { get; set; }
        public bool IsMenu { get; set; }
    }
}
