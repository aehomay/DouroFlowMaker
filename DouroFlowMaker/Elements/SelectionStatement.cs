using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMaker.Elements
{
    /// <summary>
    /// Selection statements enable you to branch to different sections of code, depending on one or 
    /// more specified conditions. For more information, see the following topics:
    ///if, else, switch, case
    /// </summary>
    public class SelectionStatement : JumpStatement
    {
        public Statement FalseNext { get; set; }
        public override StatementsType StatementType
        {
            get
            {
                return StatementsType.Selection_Statements;
            }
        }
        public SelectionStatement(string body) : base(body)
        {
            FalseNext = null;
            IOType = IOType.InOut;
        }
    }
}
