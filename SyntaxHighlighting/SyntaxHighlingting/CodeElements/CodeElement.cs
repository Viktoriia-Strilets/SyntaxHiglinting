namespace SyntaxHighlingting.CodeElements{

    public abstract class CodeElement: ICodeElement
    {
        public string Content { get; set; }
        public ConsoleColor? CurrentColor { get; private set; }
        protected readonly Action<ConsoleColor> _setColor;
        public CodeElement(string? content, Action<ConsoleColor>? setColor = null);
        public abstract void Accept(IVisitor visitor);
    }
}