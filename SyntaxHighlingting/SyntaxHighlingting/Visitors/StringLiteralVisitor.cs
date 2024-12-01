using SyntaxHighlingting.CodeElements;
using SyntaxHighlingting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyntaxHighlingting.Visitors
{
    public class StringLiteralVisitor : IVisitor
    {
        public List<CodeElement> VisitCodeElement(CodeElement stringLiteral)
        {
            if (stringLiteral is StringLiteral)
            {
                var elements = new List<CodeElement>();
                var regex = new Regex(@"(\s+|""[^""]*""|\w+|.)");

                foreach (Match match in regex.Matches(stringLiteral.Content))
                {
                    var token = match.Value;

                    if (token.StartsWith("\"") && token.EndsWith("\""))
                    {
                        elements.Add(new StringLiteral(token));
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

