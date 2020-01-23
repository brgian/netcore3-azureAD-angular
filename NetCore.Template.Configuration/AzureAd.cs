using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Template.Configuration
{
    public class AzureAdConfiguration
    {
        public string Instance { get; set; }
        public string Domain { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
    }
}
