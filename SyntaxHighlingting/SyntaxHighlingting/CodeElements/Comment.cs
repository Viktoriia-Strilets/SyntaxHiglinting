using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SyntaxHighlingting.Interfaces;

namespace SyntaxHighlingting.CodeElements
{

    public class Comment : CodeElement
    {
        public Comment(string content) : base(content, color => Console.ForegroundColor = color)
        {
            _setColor(ConsoleColor.Green);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCodeElement(this);
        }
       
    }
}

