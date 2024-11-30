namespace SyntaxHighlingting.CodeElements{

    public class StringLiteral : CodeElement
    {
        public StringLiteral(string content);

        public override void Accept(IVisitor visitor);
        
        public void VisitStringLiteral(StringLiteral? stringLiteral);
    }
}