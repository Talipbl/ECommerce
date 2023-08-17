using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public enum QuestionStatus
    {
        WAITING_FOR_ANSWER,
        WAITING_FOR_APPROVE,
        ANSWERED,
        REPORTED,
        REJECTED
    }
}
