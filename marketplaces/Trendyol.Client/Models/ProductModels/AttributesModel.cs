using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class AttributesModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("categoryAttributes")]
        public List<CategoryAttribute> CategoryAttributes { get; set; }

        public class Attribute
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class AttributeValue
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class CategoryAttribute
        {
            [JsonProperty("categoryId")]
            public int CategoryId { get; set; }

            [JsonProperty("attribute")]
            public Attribute Attribute { get; set; }

            [JsonProperty("required")]
            public bool Required { get; set; }

            [JsonProperty("allowCustom")]
            public bool AllowCustom { get; set; }

            [JsonProperty("varianter")]
            public bool Varianter { get; set; }

            [JsonProperty("slicer")]
            public bool Slicer { get; set; }

            [JsonProperty("attributeValues")]
            public List<AttributeValue> AttributeValues { get; set; }
        }
    }
}
