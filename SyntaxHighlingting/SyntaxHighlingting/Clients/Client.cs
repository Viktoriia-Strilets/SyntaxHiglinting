using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntaxHighlingting.CodeElements;
using SyntaxHighlingting.Interfaces;



namespace SyntaxHighlingting.Clients
{

    public class Client
    {
        public static void ClientCode(List<CodeElement> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
    }
}
