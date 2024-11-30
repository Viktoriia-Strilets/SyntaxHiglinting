namespace SyntaxHighlingting.CodeElements{

    public class MyText : CodeElement
    {
        public MyText(string content);

        public override void Accept(IVisitor visitor);
        
        public void VisitText(MyText? text);
    }
}