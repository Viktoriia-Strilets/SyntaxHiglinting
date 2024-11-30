using SyntaxHighlingting.CodeElements;
using SyntaxHighlingting.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SyntaxHighlingting.Visitors
{
    public class TextVisitor : IVisitor
    {

        public CodeElement VisitCodeElement(CodeElement text)
        {
            var regex = new Regex(@"(\s+|\w+|.)");

            foreach (Match match in regex.Matches(text.Content))
            {
                var token = match.Value;

                if (string.IsNullOrWhiteSpace(token))
                {
                    return new MyText(token);
                }
                
            }
            return new MyText(text.Content);
        }
    
    }
}
