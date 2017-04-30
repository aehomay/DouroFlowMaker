using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMaker.Elements
{
    /// <summary>
    /// Expression statements that calculate a value must store the value in a variable.
    /// 
    /// Expression statement (assignment).
    /// area = 3.14 * (radius* radius);
    /// 
    ///  Error. Not  statement because no assignment:
    /// circ * 2;
    /// 
    ///  Expression statement (method invocation).
    /// System.Console.WriteLine();
    /// 
    ///  Expression statement (new object creation).
    /// System.Collections.Generic.List<string> strings =
    ///     new System.Collections.Generic.List<string>();
    /// </summary>
    public class ExpressionStatement : Statement
    {
        public  StatementsType StatementsType
        { get { return StatementsType.Expression_Statements; } }
        public bool Result { get; set; }

        public ExpressionStatement(string body) : base(body)
        {
        }
    }
}
