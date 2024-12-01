public class CodeElementVisitor : IVisitor
{
    public List<CodeElement> VisitCodeElement(CodeElement code);
    private bool IsKeyword(string word);

}