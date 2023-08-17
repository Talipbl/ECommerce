using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class AttributesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<CategoryAttribute> CategoryAttributes { get; set; }

        public class Attribute
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class AttributeValue
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class CategoryAttribute
        {
            public int CategoryId { get; set; }
            public Attribute Attribute { get; set; }
            public bool Required { get; set; }
            public bool AllowCustom { get; set; }
            public bool Varianter { get; set; }
            public bool Slicer { get; set; }
            public List<AttributeValue> AttributeValues { get; set; }
        }
    }    
}
