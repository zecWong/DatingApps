using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApps.Shared.Domain
{
    public class Payment : BaseDomainModel
    {
        public int Payment_total { get; set; }

        public virtual User User_Id { get; set; }
    }
}
