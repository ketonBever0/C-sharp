using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutok
{
    class AutoList
    {
        private List<Autok> _autok;
        public List<Autok> Autok { get { return _autok; } }

        public AutoList(string file, char splitChar, int start = 1)
        {
            _autok = new List<Autok>();
            var lines = File.ReadAllLines(file, Encoding.Default);
            for (int i = start; i < lines.Length; i++)
            {
                _autok.Add(new Autok(lines[i], splitChar));
            }
        }
        

    }
}
