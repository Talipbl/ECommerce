using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class CategoryListModel
    {
        [JsonProperty("categories")]
        public List<CategoryModel> Categories { get; set; }
    }
    public class CategoryModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentId")]
        public int? ParentId { get; set; }

        [JsonProperty("subCategories")]
        public List<CategoryModel> SubCategories { get; set; }
    }

    public class SubCategoryModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentId")]
        public int ParentId { get; set; }

        [JsonProperty("subCategories")]
        public List<SubCategoryModel> SubCategories { get; set; }
    }
}
