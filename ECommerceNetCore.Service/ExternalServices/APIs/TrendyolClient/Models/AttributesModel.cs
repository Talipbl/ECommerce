using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class AttributesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<CategoryAttributeModel> CategoryAttributes { get; set; }
    }

    public class AttributeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AttributeValueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryAttributeModel
    {
        public int CategoryId { get; set; }
        public AttributeModel Attribute { get; set; }
        public bool Required { get; set; }
        public bool AllowCustom { get; set; }
        public bool Varianter { get; set; }
        public bool Slicer { get; set; }
        public List<AttributeValueModel> AttributeValues { get; set; }
    }
}
