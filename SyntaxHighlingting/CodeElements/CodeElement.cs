using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntaxHighlingting.Interfaces;

namespace SyntaxHighlingting.CodeElements
{

    public abstract class CodeElement
    {
        public string Content { get; set; }
        
        public abstract void Accept(IVisitor visitor);

        protected readonly Action<ConsoleColor> _setColor;

        public CodeElement(string? content, Action<ConsoleColor>? setColor = null)
        {
            Content = content ?? string.Empty;
            _setColor = setColor ?? (color => Console.ForegroundColor = color);
        }
    }
}