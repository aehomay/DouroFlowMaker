using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Parser
    {
        [TestMethod]
        public void Parse()
        {
            DouroFlowMaker.CSharpParser.Instance.Execute(@"C:\Users\aehom\Documents\Visual Studio 2015\Projects\FlowMaker\UnitTest\bin\Debug\Test.cs", "TestMethod");
            
        }
    }
}
