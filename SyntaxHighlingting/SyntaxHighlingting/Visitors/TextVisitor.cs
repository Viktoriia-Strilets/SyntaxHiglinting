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
        
        public List<CodeElement> VisitCodeElement(CodeElement text)
        {
            if (text is MyText)
            {
                var elements = new List<CodeElement>();
                var regex = new Regex(@"(\s+|\w+|.)");

                foreach (Match match in regex.Matches(text.Content))
                {
                    var token = match.Value;

                    if (string.IsNullOrWhiteSpace(token))
                    {
                        elements.Add(new MyText(token));
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

