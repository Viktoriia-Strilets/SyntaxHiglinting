namespace SyntaxHighlingting.CodeElements{

    public abstract class CodeElement: ICodeElement
    {
        public string Content { get; set; }
        protected readonly Action<ConsoleColor> _setColor;
        public CodeElement(string? content, Action<ConsoleColor>? setColor = null);
        public abstract void Accept(IVisitor visitor);
    }
}