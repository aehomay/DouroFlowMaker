using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMaker.Elements
{
    /// <summary>
    /// Jump statements transfer control to another section of code. For more information, see the following topics:
    /// break, continue, default, goto, return, yield
    /// </summary>
    public class JumpStatement : Statement
    {
        public override StatementsType StatementType
        {
            get
            {
                return StatementsType.Jump_Statements;
            }
        }
        public ExpressionStatement Condition { get; set; }

        public JumpStatement(string body) : base(body)
        {
        }
        
    }
}
