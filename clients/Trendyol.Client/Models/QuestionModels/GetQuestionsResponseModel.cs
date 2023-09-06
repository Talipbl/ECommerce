using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class GetQuestionsResponseModel
    {
        public List<ContentModel> Content { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }


        public class Answer
        {
            public int CreationDate { get; set; }
            public bool HasPrivateInfo { get; set; }
            public int Id { get; set; }
            public string Reason { get; set; }
            public string Text { get; set; }
        }

        public class ContentModel
        {
            public Answer Answer { get; set; }
            public string AnsweredDateMessage { get; set; }
            public int CreationDate { get; set; }
            public int CustomerId { get; set; }
            public int Id { get; set; }
            public string ImageUrl { get; set; }
            public string ProductName { get; set; }
            public bool Public { get; set; }
            public string Reason { get; set; }
            public RejectedAnswer RejectedAnswer { get; set; }
            public int RejectedDate { get; set; }
            public string ReportReason { get; set; }
            public int ReportedDate { get; set; }
            public bool ShowUserName { get; set; }
            public string Status { get; set; }
            public string Text { get; set; }
            public string UserName { get; set; }
            public string WebUrl { get; set; }
            public string ProductMainId { get; set; }
        }

        public class RejectedAnswer
        {
            public int CreationDate { get; set; }
            public int Id { get; set; }
            public string Reason { get; set; }
            public string Text { get; set; }
        }
    }
}
