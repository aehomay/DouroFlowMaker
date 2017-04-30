using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMaker.Elements
{
   public class ExceptionHandlingStatement : Statement
    {
        public ExceptionHandlingStatement(string body) : base(body)
        {
        }

        public StatementsType StatementsType
        { get { return StatementsType.Exception_Handling_Statements; } }
        
    }
}
