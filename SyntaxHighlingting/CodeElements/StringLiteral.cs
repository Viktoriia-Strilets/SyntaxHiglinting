using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntaxHighlingting.Interfaces;

namespace SyntaxHighlingting.CodeElements
{

    public class StringLiteral : CodeElement
    {
        public StringLiteral(string content)
        {
            Content = content;
            _setColor(ConsoleColor.DarkYellow);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCodeElement(this);
        }
      /* public void VisitStringLiteral(StringLiteral? stringLiteral)
        {
            if (stringLiteral == null)
                throw new ArgumentNullException(nameof(stringLiteral), "StringLiteral cannot be null.");
            _setColor(ConsoleColor.DarkYellow);
            Console.Write(stringLiteral.Content);
        }*/
    }
}
