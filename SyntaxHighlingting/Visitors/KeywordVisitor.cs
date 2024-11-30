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
    public class KeywordVisitor : IVisitor
    {
        public CodeElement VisitCodeElement(CodeElement keyword)
        {

            if (IsKeyword(keyword.Content))
            {
                return new Keyword(keyword.Content);
            }
            return new MyText(keyword.Content);
        }

        private bool IsKeyword(string word)
        {
            var keywords = new List<string> { "public", "private", "class", "void", "string", "int", "var", "new", "static" };
            return keywords.Contains(word);
        }
     

    }
}

