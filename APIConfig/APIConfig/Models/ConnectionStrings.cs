using System;
using System.Collections.Generic;

namespace APIConfig.Models
{
    public partial class ConnectionStrings
    {
        public int Id { get; set; }
        public string Db { get; set; }
        public string DatabaseName { get; set; }
    }
}
