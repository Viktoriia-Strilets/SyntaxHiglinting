using SyntaxHighlingting.Clients;
using SyntaxHighlingting.CodeElements;
using SyntaxHighlingting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SyntaxHighlingtingTest
{
    public class ClientTests
    {
        [Fact]
        public void VisitCodeElement_ShouldBeCalledWithCorrectElement()
        {
            // Arrange
            var mockVisitor = new MockVisitor();
            var commentElement = new Comment("// Example comment");

            // Act
            var result = mockVisitor.VisitCodeElement(commentElement);

            // Assert
            Assert.True(mockVisitor.VisitCalled, "VisitCodeElement was not called.");
            Assert.NotNull(mockVisitor.LastVisitedElement);
            Assert.Equal(commentElement, mockVisitor.LastVisitedElement);
            Assert.Single(result);
            Assert.Equal(commentElement, result[0]);
        }

        [Fact]
        public void ClientCode_ShouldCallVisitorForAllElements()
        {
            // Arrange
            var mockVisitor = new MockVisitor();
            var elements = new List<CodeElement>
    {
        new Comment("// Comment"),
        new Keyword("public"),
        new StringLiteral("\"String Literal\""),
        new MyText("Some text")
    };

            // Act
            Client.ClientCode(elements, mockVisitor);

            // Assert
            Assert.True(mockVisitor.VisitCalled, "Visitor was not called.");
        }
        public class MockVisitor : IVisitor
        {
            public bool VisitCalled { get; private set; } = false;
            public CodeElement LastVisitedElement { get; private set; } = null;

            public List<CodeElement> VisitCodeElement(CodeElement codeElement)
            {
                VisitCalled = true;
                LastVisitedElement = codeElement;
                return new List<CodeElement> { codeElement };
            }
        }
    }
}

    

    


