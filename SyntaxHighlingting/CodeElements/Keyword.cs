using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntaxHighlingting.Interfaces;

namespace SyntaxHighlingting.CodeElements
{

    public class Keyword : CodeElement
    {
        public Keyword(string content) : base(content) { }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCodeElement(this);
        }

        public void VisitKeyword(Keyword? keyword)
        {
            if (keyword == null)
                throw new ArgumentNullException(nameof(keyword), "Keyword cannot be null.");
            _setColor(ConsoleColor.Blue);
            Console.Write(keyword.Content);
        }
    }
}
