using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJs.Generator.Generator
{
    public class RazorCSharpRenderFragmentStatement : RazorXmlElementNode
    {
        public RazorCSharpRenderFragmentStatement(string lhs, RazorXmlNode? parent) : base("text", parent)
        {
            this.LHS = lhs;
        }

        public string LHS { get; }

        public override string ToString()
        {
            return $"{LHS}{base.ToString()};";
        }

        public override string GenerateCode(int tabDepth, int parameterDepth, ComponentCodeGenerationContext context)
        {
            return @$"{GetCodeFormatTabs(tabDepth)}{LHS}(__frame{parameterDepth + 1}, __key{parameterDepth + 1}) =>
{GetCodeFormatTabs(tabDepth)}{{
{base.GenerateCode(tabDepth, parameterDepth + 1, context)}
{GetCodeFormatTabs(tabDepth)}}};";
        }
    }
}
