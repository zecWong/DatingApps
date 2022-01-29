using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApps.Shared.Domain
{
    public class Subscription : BaseDomainModel
    {
        public DateTime Sub_DateStart { get; set; }
        public DateTime Sub_DateEnd { get; set; }
        public virtual Payment Payment_Id { get; set; }

        public virtual User User_Id { get; set; }
    }
}
