using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntaxHighlingting.Interfaces;

namespace SyntaxHighlingting.CodeElements
{

    public class MyText : CodeElement
    {
        public MyText(string content) : base(content, color => Console.ForegroundColor = color)
        {
            _setColor(ConsoleColor.White);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCodeElement(this);
        }
      
    }
}
