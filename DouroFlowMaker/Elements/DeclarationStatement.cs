using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMaker.Elements
{
    /// <summary>
    ///A declaration statement introduces a new variable or constant. A variable declaration can optionally 
    ///assign a value to the variable. In a constant declaration, the assignment is required.
    ///1-Variable declaration statements.
    /// double area;
    /// double radius = 2;
    ///
    ///2-Constant declaration statement.
    /// const double pi = 3.14159;
    /// </summary>
    public class DeclarationStatement:Statement
    {
        public StatementsType StatementsType
        { get { return StatementsType.Declaration_Statements; } }

        public DeclarationStatement(string body) : base(body)
        {
        }

        public string Type { get; set; }
    }
}
