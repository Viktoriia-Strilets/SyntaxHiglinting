using System;
using System.Collections.Generic;
using Xunit;
using SyntaxHighlingting;
using static System.Net.Mime.MediaTypeNames;
using SyntaxHighlingting.CodeElements;
using SyntaxHighlingting.Visitors;
using SyntaxHighlingting.Interfaces;

namespace SyntaxHighlingting.Test
{

    public class ClientTests
    {
        [Fact]
        public void ClientCode_ShouldCallAcceptMethodOnEachElement()
        {
            // Arrange
            var components = new List<CodeElement>
        {
            new Comment("// This is a comment"),
            new Keyword("public"),
            new StringLiteral("\"Hello, World!\""),
            new MyText("Test")
        };

            // var visitor = new HighlightingVisitor();
            var vCom = new CommentVisitor();
            
            // Act & Assert
            foreach (var component in components)
            {
                // Ensure the Accept method is called for each component
                var elementWasAccepted = false;

                // Mock the Accept method
                component.Accept(new MockVisitor(() => elementWasAccepted = true));

                Assert.True(elementWasAccepted);
            }
        }
    }

    // Mock class for the visitor
    public class MockVisitor : IVisitor
    {
        private readonly Action _onVisit;

        public MockVisitor(Action onVisit)
        {
            _onVisit = onVisit;
        }
        public CodeElement VisitCodeElement(CodeElement codeElement)
        {  
            _onVisit();
            return codeElement;
              
        }
            /* public void VisitComment(Comment comment)
             {
                 _onVisit();
             }

             public void VisitKeyword(Keyword keyword)
             {
                 _onVisit();
             }

             public void VisitStringLiteral(StringLiteral stringLiteral)
             {
                 _onVisit();
             }

             public void VisitText(MyText text)
             {
                 _onVisit();
             }*/
        }
}