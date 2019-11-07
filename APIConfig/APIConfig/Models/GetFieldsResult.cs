using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConfig.Models
{
    public class GetFieldsResult
    {
        public string table_catalog { get; set; }
        public string table_name { get; set; }
        public string column_name { get; set; }
        public string is_nullable { get; set; }
        public string data_type { get; set; }
    }
}
