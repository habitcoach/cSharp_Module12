using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CSharp;

class Program
{
    static void Main(string[] args)
    {
        // Create a CodeCompileUnit
        CodeCompileUnit compileUnit = new CodeCompileUnit();

        // Create a namespace
        CodeNamespace ns = new CodeNamespace("MyNamespace");

        // Create a class
        CodeTypeDeclaration classType = new CodeTypeDeclaration("MyClass");
        classType.IsClass = true;

        // Create a method
        CodeMemberMethod method = new CodeMemberMethod();
        method.Name = "MyMethod";
        method.Attributes = MemberAttributes.Public | MemberAttributes.Static;
        method.ReturnType = new CodeTypeReference(typeof(void));
        method.Statements.Add(new CodeSnippetStatement("Console.WriteLine(\"Hello, world!\");"));
       
        // Create another method for adding two integers
        CodeMemberMethod addMethod = new CodeMemberMethod();
        addMethod.Name = "AddTwoIntegers";
        addMethod.Attributes = MemberAttributes.Public | MemberAttributes.Static;
        addMethod.ReturnType = new CodeTypeReference(typeof(int));
        addMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "a"));
        addMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "b"));
        addMethod.Statements.Add(new CodeMethodReturnStatement(new CodeBinaryOperatorExpression(
            new CodeArgumentReferenceExpression("a"),
            CodeBinaryOperatorType.Add,
            new CodeArgumentReferenceExpression("b"))));

        // Add methods to class
        classType.Members.Add(method);
        classType.Members.Add(addMethod);

        // Add class to namespace
        ns.Types.Add(classType);

        // Add namespace to compile unit
        compileUnit.Namespaces.Add(ns);

        // Create code provider
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

        // Generate C# code
        using (System.IO.StringWriter writer = new System.IO.StringWriter())
        {
            CodeGeneratorOptions options = new CodeGeneratorOptions();//This object allows you to specify various options that control the behavior of the code generator.
            provider.GenerateCodeFromCompileUnit(compileUnit, writer, options);
            string generatedCode = writer.ToString();
            Console.WriteLine(generatedCode);


        }
    }
}
