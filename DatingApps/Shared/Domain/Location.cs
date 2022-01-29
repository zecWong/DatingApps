using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApps.Shared.Domain
{
    public class Location : BaseDomainModel
    {
        public virtual User User_Id { get; set; }
        public string Location_Gps { get; set; }
    }
}
