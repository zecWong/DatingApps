using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApps.Shared.Domain
{
    public class User : BaseDomainModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }

        public string Birth { get; set; }
        public string Status { get; set; }
        public string GenderP { get; set; }
        public string Location { get; set; }
        public string Like { get; set; }
        public string Superlike { get; set; }
    }
}
