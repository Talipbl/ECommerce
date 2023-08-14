using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.Models
{
    public class ApiAuthorizationModel
    {
        public string ApiKey { get; set; } = string.Empty;
        public string ApiSecretKey { get; set; } = string.Empty;
        public string Authorization { get; set; } = string.Empty;
    }
}
