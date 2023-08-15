using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object ParentId { get; set; }
        public List<SubCategoryModel> SubCategories { get; set; }

        public class SubCategoryModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ParentId { get; set; }
            public List<SubCategoryModel> SubCategories { get; set; }
        }
    }
}
