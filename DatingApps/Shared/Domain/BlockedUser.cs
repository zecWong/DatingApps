using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApps.Shared.Domain
{
    public abstract class BlockedUser : BaseDomainModel
    {

        public string BUser_Cause { get; set; }
        public virtual User User_Id { get; set; }
    }
}
