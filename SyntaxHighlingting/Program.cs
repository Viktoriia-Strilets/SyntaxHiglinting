using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntaxHighlingting;
using SyntaxHighlingting.Clients;
using SyntaxHighlingting.CodeElements;
using SyntaxHighlingting.Visitors;
using SyntaxHiglintingLibrary.Visitors;


namespace SyntaxHighlingtingProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var codeLines = "class Program // Print Hello, world!\n{\n    static void Main(string[] args)\n    {\n        Console.WriteLine(\"Hello, world!\");\n    }\n    /* Hi! */\n}\n";
            var components = new List<CodeElement>
        {
            new Comment(codeLines),
            new Keyword(codeLines),
            new StringLiteral(codeLines),
            new MyText(codeLines)

        };

            var commentVisitor = new CommentVisitor();
            var keywordVisitor = new KeywordVisitor();
            var stringLiteralVisitor = new StringLiteralVisitor();
            var textVisit = new TextVisitor();
            var codeElementVisitor = new CodeElementVisitor();

            Client.ClientCode(components, commentVisitor);
            Client.ClientCode(components, keywordVisitor);
            Client.ClientCode(components, stringLiteralVisitor);
            Client.ClientCode(components, textVisit);
            Client.ClientCode(components, codeElementVisitor);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}

