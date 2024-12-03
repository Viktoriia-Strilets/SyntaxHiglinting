using SyntaxHighlingting.CodeElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SyntaxHighlingting.Interfaces

{
    public interface IVisitor
    {
        List<CodeElement> VisitCodeElement(CodeElement сodeElement);
    }
}