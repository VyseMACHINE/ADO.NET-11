using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLinqApp
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        virtual public ICollection<Player> Players { get; set; }
        
        public Team()
        {
            Players = new List<Player>();
        }
    }
}
