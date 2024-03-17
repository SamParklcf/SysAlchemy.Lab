using System.Diagnostics.CodeAnalysis;
using SysAlchemy.Lab.Refactoring.Definitions;

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.ExtractMethod"/>
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class ExtractMethod : IRefactoringImplementation
{
    public class BeforeRefactoring
    {
        private void PrintBanner()
        {
            // ...    
        }

        private string GetOutstanding()
        {
            // ...

            return string.Empty;
        }

        public void PrintOwing(string name)
        {
            PrintBanner();// Already, we know that this line is going to print the banner. (Readability!)

            // Need refactoring: These details can be extracted into a new method.
            Console.WriteLine("name: " + name);
            Console.WriteLine("amount: " + GetOutstanding());
        }
    }

    public class AfterRefactoring
    {
        private void PrintBanner()
        {
            // ...    
        }

        private string GetOutstanding()
        {
            // ...

            return string.Empty;
        }

        private void PrintDetails(string name)
        {
            // By extracting these lines into a separated method, now we can find out that these lines are going to 
            // print details of the owing!!! (more readability)
            
            // Another benefit is that if we want to print details in another sections, we can just simply use
            // this method. (how easy!)
            
            // And another benefit can be that: this printing details are isolated, so we can be sure 100%,
            // that if we have any problems in the printed details (printing functionalities),
            // we can just see this method and find the problem/s.
            Console.WriteLine("name: " + name);
            Console.WriteLine("amount: " + GetOutstanding());
        }
        
        public void PrintOwing(string name)
        {
            PrintBanner();
            PrintDetails(name);
        }
    }

    /// <inheritdoc/>
    public IRefactoringDefinitionInstruction GetDefinitionInstruction()
    {
        return new Definitions.RefactoringTechniques.ComposingMethods.ExtractMethod();
    }
}