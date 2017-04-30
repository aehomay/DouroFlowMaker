using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMaker.Elements
{
    /// <summary>
    /// Iteration statements enable you to loop through collections like arrays, or perform the same set of statements repeatedly 
    /// until a specified condition is met. For more information, see the following topics:
    /// do, for, foreach, in, while
    /// </summary>
    public class IterationStatement:JumpStatement
    {
        public override StatementsType StatementType
        {
            get
            {
                return StatementsType.Iteration_Statements;  
            }
        }
        
        public IterationStatement(string body) : base(body)
        {
        }

    }
}
