using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApps.Shared.Domain
{
    public class Match : BaseDomainModel
    {

        public virtual User User_Id { get; set; }
        public int unmatch_ID { get; set; }
        public virtual Location location { get; set; }
        public DateTime match_timestamp { get; set; }
    }
}
