using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApps.Shared.Domain
{
    public class Message : BaseDomainModel
    {
        public string Message_content { get; set; }
        public DateTime Message_timestamp { get; set; }
        public string Message_read { get; set; }
        public virtual Match Match_Id { get; set; }


    }
}
