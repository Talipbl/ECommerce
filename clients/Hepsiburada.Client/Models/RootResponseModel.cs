using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Hepsiburada
{
    public class RootResponseModel<T>
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public int Version { get; set; }
        public string Message { get; set; }
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public int Number { get; set; }
        public int NumberOfElements { get; set; }
        public bool First { get; set; }
        public bool Last { get; set; }
        public List<T> Data { get; set; }
    }
}
