using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowMaker.Elements
{
    public enum IOType
    {
        Input,
        Output,
        InOut
    }

    public enum StatementsType
    {
        Declaration_Statements,
        Expression_Statements,
        Selection_Statements,
        Iteration_Statements,
        Jump_Statements,
        Exception_Handling_Statements,
        He_Await_Statement,
        The_Yield_Return_Statement,
        The_Fixed_Statement,
        The_Lock_Statement,
        Labeled_Statements,
        The_Empty_Statement,
        None
    }

    public abstract class Statement : object,IStatement, ICloneable
    {
        Statement _next = null;
        Statement _previous = null;

        public virtual StatementsType StatementType { get; }

        public IOType IOType { get; set; }
        
        public string Body { get; set; }

        public virtual Statement Next
        {
            get
            {
                return _next;
            }

            set
            {
                _next = value;
            }
        }

        public virtual Statement Previous
        {
            get
            {
                return _previous;
            }

            set
            {
                _previous = value;
            }
        }

        public Statement(string body)
        {
            Body = body;
            Next = null;
        }
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
