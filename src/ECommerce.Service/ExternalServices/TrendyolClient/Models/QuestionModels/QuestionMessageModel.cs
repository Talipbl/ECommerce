using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.QuestionModels
{
    public class QuestionMessageModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        public QuestionMessageModel(string text)
        {
            Text = text;
        }
    }
}
