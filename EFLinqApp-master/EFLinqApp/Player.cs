using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLinqApp
{
    public class Player
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

        public int? TeamId { get; set; }
        virtual public Team Team { get; set; }
    }
}
