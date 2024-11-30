using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntaxHighlingting.Interfaces;

namespace SyntaxHighlingting.CodeElements
{

    public class Comment : CodeElement
    {
        public Comment(string content) : base(content) { }
        
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCodeElement(this);
        }
       public void VisitComment(Comment? comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment), "Comment cannot be null.");
            _setColor(ConsoleColor.Green);
            Console.Write(comment.Content);

        }
    }
}
