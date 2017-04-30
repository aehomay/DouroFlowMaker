using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMaker.Elements
{
    public class Method:Statement
    { 
        public string Name { get; set; }
        public Statement Output { get; set; }
        public string Signature { get; set; }
        public Stack<Statement> StatementStack { get; set; }

        public Method(string body) : base(body)
        {
            StatementStack = new Stack<Elements.Statement>();
        }


    }
}
