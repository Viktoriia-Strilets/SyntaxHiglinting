namespace SyntaxHighlingting.CodeElements{

    public class Comment : CodeElement
    {
        public Comment(string content);

        public override void Accept(IVisitor visitor);
    
    }
}