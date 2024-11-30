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
        public MyText(string content) : base(content) { }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCodeElement(this);
        }
        public void VisitText(MyText? text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text), "Text cannot be null.");
            _setColor(ConsoleColor.White);
            Console.Write(text.Content);

        }
    }
}
