using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Data
{
    public class Organizations
    {
        public string name { get; set; }

        public string region { get; set; }

        public string city { get; set; }

        public string phone { get; set; }

        public string adress { get; set; }

        public string link { get; set; }

        public List<Currencies> currencies { get; set; }
    }
}
