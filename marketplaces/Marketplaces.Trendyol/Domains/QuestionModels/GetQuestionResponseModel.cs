using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Trendyol
{
    public class GetQuestionResponseModel
    {
        public long CreationDate { get; set; }
        public int CustomerId { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public bool Public { get; set; }
        public string ReportReason { get; set; }
        public long ReportedDate { get; set; }
        public bool ShowUserName { get; set; }
        public string Status { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public string WebUrl { get; set; }
        public string ProductMainId { get; set; }
    }
}
