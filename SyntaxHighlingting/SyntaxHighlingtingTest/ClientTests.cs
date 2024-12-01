using SyntaxHighlingting.CodeElements;
using SyntaxHiglintingLibrary.Visitors;
using Xunit;
using System.Collections.Generic;
using SyntaxHighlingting.Interfaces;
using SyntaxHighlingting.Visitors;

namespace SyntaxHighlingtingTest
{
    public class CodeElementVisitorTests
    {

        [Fact]
        public void VisitKeyword_GetHighlightKeywords()
        {
            // Arrange
            var code = "public class Test { static void Main() { string text = \"Hello\"; } }";
            var keyword = new Keyword(code);
            var visitor = new KeywordVisitor();

            // Act
            var result = visitor.VisitCodeElement(keyword);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, e => e is Keyword);
        }

        [Fact]
        public void VisitComment_GetHighlightComments()
        {
            // Arrange
            var code = "// This is a comment";
            var comment = new Comment(code);
            var visitor = new CommentVisitor();

            // Act
            var result = visitor.VisitCodeElement(comment);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result, e => e is Comment);
        }

        [Fact]
        public void VisitStringLiteral_GetHighlightStringLiterals()
        {
            // Arrange
            var code = "\"Hello, World!\"";
            var stringLiteral = new StringLiteral(code);
            var visitor = new StringLiteralVisitor();

            // Act
            var result = visitor.VisitCodeElement(stringLiteral);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, e => e is StringLiteral);
        }

        [Fact]
        public void VisitText_GetHandleWhitespace()
        {
            // Arrange
            var code = "    "; 
            var text = new MyText(code);
            var visitor = new TextVisitor();

            // Act
            var result = visitor.VisitCodeElement(text);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result, e => e is MyText && string.IsNullOrWhiteSpace(e.Content));
        }

        [Fact]
        public void VisitCodeElement_ShouldHandleMixedContent()
        {
            // Arrange
            var code = "public class Test // Comment\n{\n\"Hello\";\n}";
            var elements = new List<CodeElement>
            {
                new Comment(code),
                new Keyword(code),
                new StringLiteral(code),
                new MyText(code)
            };

            var visitor = new CodeElementVisitor();

            // Act
            var results = new List<CodeElement>();
            foreach (var element in elements)
            {
                results.AddRange(visitor.VisitCodeElement(element));
            }

            // Assert
            Assert.NotEmpty(results);
            Assert.Contains(results, e => e is Comment);
            Assert.Contains(results, e => e is Keyword);
            Assert.Contains(results, e => e is StringLiteral);
            Assert.Contains(results, e => e is MyText);
        }
        [Fact]
        public void VisitKeyword_ShouldSetColorBlue()
        {
            // Arrange
            var code = "public";
            var keyword = new Keyword(code);
            var visitor = new KeywordVisitor();

            // Act
            visitor.VisitCodeElement(keyword);

            // Assert
            Assert.Equal(ConsoleColor.Blue, keyword.CurrentColor);
        }

        [Fact]
        public void VisitComment_GetSetColorGreen()
        {
            // Arrange
            var code = "// This is a comment";
            var comment = new Comment(code);
            var visitor = new CommentVisitor();


            // Act
            visitor.VisitCodeElement(comment);

            // Assert
            Assert.Equal(ConsoleColor.Green, comment.CurrentColor);
        }

        [Fact]
        public void VisitStringLiteral_GetSetColorDarkYellow()
        {
            // Arrange
            var code = "\"Hello, World!\"";
            var stringLiteral = new StringLiteral(code);
            var visitor = new StringLiteralVisitor();

            // Act
            visitor.VisitCodeElement(stringLiteral);

            // Assert
            Assert.Equal(ConsoleColor.DarkYellow, stringLiteral.CurrentColor);
        }

        [Fact]
        public void VisitText_ShouldSetColorWhite()
        {
            // Arrange
            var code = "Some random text";
            var text = new MyText(code);
            var visitor = new TextVisitor();

            // Act
            visitor.VisitCodeElement(text);

            // Assert
            Assert.Equal(ConsoleColor.White, text.CurrentColor);
        }
    }

}

