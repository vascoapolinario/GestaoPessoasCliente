using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestaoPessoasCliente.ApiClients
{
    public partial record Worker
    {
        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
