namespace SyntaxHighlingting.CodeElements{
    public class Keyword : CodeElement
    {
        public Keyword(string content);

        public override void Accept(IVisitor visitor);

    }
}