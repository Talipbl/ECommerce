using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class QuestionMessageModel
    {
        public string Text { get; set; }
        public QuestionMessageModel(string text)
        {
            Text = text;
        }
    }
}
