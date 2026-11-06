using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
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
