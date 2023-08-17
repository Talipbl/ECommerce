using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class GetClaimAuditsResponse
    {
        public string claimId { get; set; }
        public string claimItemId { get; set; }
        public string previousStatus { get; set; }
        public string newStatus { get; set; }
        public UserInfoDocument userInfoDocument { get; set; }
        public long date { get; set; }

        public class UserInfoDocument
        {
            public string executorId { get; set; }
            public string executorApp { get; set; }
            public string executorUser { get; set; }
        }
    }
}
