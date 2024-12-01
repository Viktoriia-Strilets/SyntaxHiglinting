using SyntaxHighlingting.CodeElements;
using SyntaxHighlingting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SyntaxHighlingting.Visitors
{
    public class KeywordVisitor : IVisitor
    {
        public List<CodeElement> VisitCodeElement(CodeElement keyword)
        {
            if (keyword is Keyword)
            {
                var elements = new List<CodeElement>();
                var regex = new Regex(@"(\s+|\w+|.)");

                foreach (Match match in regex.Matches(keyword.Content))
                {
                    var token = match.Value;
                    if (IsKeyword(token))
                    {
                        elements.Add(new Keyword(token));
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
        private bool IsKeyword(string word)
        {
            var keywords = new List<string> { "public", "private", "class", "void", "string", "int", "var", "new", "static" };
            return keywords.Contains(word);
        }
    }
}



