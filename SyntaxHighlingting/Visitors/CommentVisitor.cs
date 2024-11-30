using SyntaxHighlingting.CodeElements;
using SyntaxHighlingting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SyntaxHighlingting.Visitors
{
    public class CommentVisitor : IVisitor
    {
        public CodeElement VisitCodeElement(CodeElement comment)
        {
            var regex = new Regex(@"(\s+|//.*|/\*[\s\S]*?\*/|\w+|.)");

            foreach (Match match in regex.Matches(comment.Content))
            {
                var token = match.Value;

                if (token.StartsWith("//") || (token.StartsWith("/*") && token.EndsWith("*/")))
                {
                    return new Comment(token);
                }

            }
            return new MyText(comment.Content);
        }
    }
}
