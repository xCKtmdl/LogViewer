using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogViewer.Models.CEF
{
    public class CEFs
    {
        public List<CEF> ListCEFs { get; set; }
        public int totalAlerts { get; set; }
    }
    public class CEF
    {
        public int id { get; set; }
        public string dhost { get; set; }
        public string dhostStyle { get; set; }
        public string SourceTransIP { get; set; }
        public string cs1 { get; set; }
        public string cs1Style { get; set; }
        public int mysteryNumber { get; set; }
        public string SourceIP {get; set;}
        public string SourceIPstyle { get; set; }
        public bool SourceIP_Private { get; set; }
      
        public string Dest_IP { get; set; }
        public string Dest_IPStyle { get; set; }
        public bool Dest_IP_Private { get; set; }
        

        public int AlertLevel { get; set; }
        public string RowStyle { get; set; }

    }
}
