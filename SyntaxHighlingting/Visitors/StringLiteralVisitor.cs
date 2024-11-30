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
        public CodeElement VisitCodeElement(CodeElement stringLiteral)
        {
            var regex = new Regex(@"(\s+|""[^""]*""|\w+|.)");

            foreach (Match match in regex.Matches(stringLiteral.Content))
            {
                var token = match.Value;

                if (token.StartsWith("\"") && token.EndsWith("\""))
                {
                    return new StringLiteral(token);
                }

            }
            return new MyText(stringLiteral.Content);
        }
    }
}
