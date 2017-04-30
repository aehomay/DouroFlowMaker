using FlowMaker.Elements;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DouroFlowMaker
{
    public enum ParsingState
    {
        Start,
        End,
        Normal,
        Conditiona,
        None
    }
    public class CSharpParser
    {

        CSharpCodeProvider csharp = new CSharpCodeProvider();
        Stack<Statement> _stack = new Stack<Statement>();
        static CSharpParser _instance = null;
        
        bool freez = false;
        

        /// <summary>
        /// Singltone
        /// </summary>
        public static CSharpParser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CSharpParser();
                return _instance;
            }
        }

        string[] _keywords = ("abstract,event,new,struct,as,explicit,null,switch,base,extern,object,this,bool," +
            "false,operator,throw,break,finally,out,true,byte,fixed,override,try,case,float,params,typeof,catch," +
            "for,private,uint,char,foreach,protected,ulong,checked,goto,public,unchecked,class,if,readonly,unsafe," +
            "const,implicit, ref, ushort,continue,in,return,using,decimal,int,sbyte,virtual,default,interface,sealed," +
            "volatile,delegate,internal,short,void,do,is,sizeof,while,double,lock,stackalloc,else,long,static,enum," +
            "namespace,string").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        string[] _declaration = new string[] { "bool","byte", "sbyte","char","decimal","double","float","int","uint","long","ulong","object","short","ushort","string",
            "System.Boolean" ,"System.Byte","System.SByte","System.Char","System.Decimal","System.Double","System.Single",
            "System.Int32","System.UInt32","System.Int64","System.UInt64","System.Object","System.Int16","System.UInt16","System.String"};
        char[] _separators = new char[] { ' ', '{', '}', '(', ')', '=', ';' };
        string[] _modifiers = new string[] { "implicit", "delegate", "event", "public", "private", "static", "virtual", "interface", "protected", "override", "abstract", "internal" };
        string[] _experssion = new string[] { "+", "=", "/", "*", "-", "&", "^","|", "||","&","&&" };
        string[] _selection = new string[] { "if", "else", "switch", "case" };
        string[] _iteration = new string[] { "do", "for", "foreach", "in", "while" };
        string[] _jump = new string[] { "break", "continue", "default", "goto", "return", "yield" };
        string[] _exception = new string[] { "throw", "try-catch", "try-finally", "try-catch-finally" };
        string[] _he_await = new string[] { "Async", "Await" };
        List<string> _tokens = new List<string>();
        Dictionary<string, string[]> _statements = new Dictionary<string, string[]>();

        /// <summary>
        /// Source code file path
        /// </summary>
        public string Path { get; set; }

        public char[] Separators
        {
            get
            {
                return _separators;
            }

            set
            {
                _separators = value;
            }
        }

        public string[] Keywords
        {
            get
            {
                return _keywords;
            }
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        private CSharpParser()
        {
            _statements.Add("Declaration_statements", _declaration);
            _statements.Add("Expression_statements", _experssion);
            _statements.Add("Selection_statements", _selection);
            _statements.Add("Iteration_statements", _iteration);
            _statements.Add("Jump_statements", _jump);
            _statements.Add("Exception_handling_statements", _exception);
            _statements.Add("he_await_statement", _he_await);
            _statements.Add("The_yield_return_statement", new string[] { "Iterators" });
            _statements.Add("The_fixed_statement", new string[] { "fixed" });
            _statements.Add("The_lock_statement", new string[] { "lock" });
            _statements.Add("Labeled_statements", new string[] { "goto" });
            _statements.Add("The_empty_statement", null);

        }
        /// <summary>
        /// Read source code and create table
        /// </summary>
        /// <param name="path">Source code path</param>
        /// <param name="mathod">Method name</param>
        public Method Execute(string path, string methodName)
        {
            Path = path;
            StreamReader sr = new StreamReader(path);
       
            if (sr.BaseStream.CanRead == false)
                throw new Exception("File is not readable.");

            return ExtractMethod(sr, methodName);
        }

        private Method ExtractMethod(StreamReader sr, string methodName)
        {
            Method method = null;
            bool successful = false;
            int count_exit_point = 0;
            string line = string.Empty;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine().Trim();

                var token_line = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var token in token_line)
                {
                    _tokens.Add(token);
                }
            }
           

            if (successful == false)
                throw new Exception("Method is not find or file is not correct.");
            return method;
        }

        public ParsingState ConvertTo(StatementsType type)
        {
            if (type == StatementsType.Selection_Statements || type == StatementsType.Iteration_Statements)
                return ParsingState.Conditiona;
            return ParsingState.Normal;
        }

        public Statement ConvertTo(string str)
        {
            if (_declaration.Any(d=>str.StartsWith(d)))
                return new DeclarationStatement(str);
            else if (_experssion.Any(e => str.Contains(e)) && str.EndsWith(";"))
                return new ExpressionStatement(str);
            else if (_selection.Any(s => str.StartsWith(s)))
                return new SelectionStatement("") { Condition = new ExpressionStatement(str) };
            else if (_iteration.Any(i => str.StartsWith(i)))
                return new IterationStatement("") { Condition = new ExpressionStatement(str) };
            else if (_jump.Any(j => str.StartsWith(j)))
                return new JumpStatement(str);
            return null;
        }

        public static Assembly GetAssemblyNameContainingType(String typeName)
        {
            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type t = currentassembly.GetType(typeName, false, true);
                if (t != null) { return currentassembly; }
            }

            return null;
        }

    }
}
