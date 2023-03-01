using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutok
{
    class AutoDataContext
    {
        AutoList autok;
        public List<Autok> Autok { get; set; }
        public AutoDataContext(string file)
        {
            autok = new AutoList(file, ';');
            Autok = autok.Autok;
        }
    }
}
