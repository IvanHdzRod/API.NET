using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConfig.Models
{
    public class SchemaCrawlerRequest
    {
        public string server { get; set; }
        public string database { get; set; }
        public string command { get; set; }
        public string infoLevel { get; set; }
        public string outputFile { get; set; }
        public string outputFormat { get; set; }
    }
}
