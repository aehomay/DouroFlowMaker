using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMaker.Elements
{
    public interface IStatement
    {
        StatementsType StatementType { get; }

    }
}
