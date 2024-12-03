public class KeywordVisitor : IVisitor
{
    public CodeElement VisitCodeElement(CodeElement comment);
     private bool IsKeyword(string word);
}