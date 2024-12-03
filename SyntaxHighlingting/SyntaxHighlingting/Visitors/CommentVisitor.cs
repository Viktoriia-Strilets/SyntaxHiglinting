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
        public List<CodeElement> VisitCodeElement(CodeElement comment)
        {
            if (comment is Comment)
            {
                var elements = new List<CodeElement>();
                var regex = new Regex(@"(\s+|//.*|/\*[\s\S]*?\*/|\w+|.)");

                foreach (Match match in regex.Matches(comment.Content))
                {
                    var token = match.Value;

                    if (token.StartsWith("//") || (token.StartsWith("/*") && token.EndsWith("*/")))
                    {
                        elements.Add(new Comment(token));
                        Console.Write(token);
                    }
                    else
                    {                        
                        elements.Add(new MyText(token));
                        Console.Write(token);
                    }

                }
            
                return elements;
            }
            return null;
        }
    }
}

