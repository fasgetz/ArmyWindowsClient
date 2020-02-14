using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.Models.ModelSocialNetworks
{
    public partial class SocialNetworkSessions
    {
        public int Id { get; set; }

        public int IdSocialNetworkUser { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public virtual SocialNetworkUser SocialNetworkUser { get; set; }
    }
}
