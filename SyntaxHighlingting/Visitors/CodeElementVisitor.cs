using SyntaxHighlingting.CodeElements;
using SyntaxHighlingting.Interfaces;
using SyntaxHighlingting.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SyntaxHiglintingLibrary.Visitors
{
    public class CodeElementVisitor : IVisitor
    {
        public List<CodeElement> VisitCodeElement(CodeElement code)
        {

            var elements = new List<CodeElement>();
            var regex = new Regex(@"(\s+|//.*|/\*[\s\S]*?\*/|""[^""]*""|\w+|.)");


            foreach (Match match in regex.Matches(code.Content))
            {
                var token = match.Value;

                if (token.StartsWith("//") || (token.StartsWith("/*") && token.EndsWith("*/")))
                {
                    elements.Add(new Comment(token));
                    Console.Write(token);
                }

                else if (token.StartsWith("\"") && token.EndsWith("\""))
                {
                    elements.Add(new StringLiteral(token));
                    Console.Write(token);
                }

                else if (IsKeyword(token))
                {
                    elements.Add(new Keyword(token));
                    Console.Write(token);
                }
                else if (string.IsNullOrWhiteSpace(token))
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

        private bool IsKeyword(string word)
        {
            var keywords = new List<string> { "public", "private", "class", "void", "string", "int", "var", "new", "static" };
            return keywords.Contains(word);
        }
    }

}