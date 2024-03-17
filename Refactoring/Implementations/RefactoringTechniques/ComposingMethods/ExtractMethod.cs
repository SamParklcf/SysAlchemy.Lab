using System.Diagnostics.CodeAnalysis;

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.ExtractMethod"/>
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class ExtractMethod
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

    private void PrintOwing_BeforeRefactoring(string name)
    {
        PrintBanner();

        // Print details.
        Console.WriteLine("name: " + name);
        Console.WriteLine("amount: " + GetOutstanding());
    }

    // In 'Print details' section of the 'PrintOwing' method, we can extract the codes into a new method:
    private void PrintDetails(string name)
    {
        Console.WriteLine("name: " + name);
        Console.WriteLine("amount: " + GetOutstanding());
    }

    // After refactoring:
    private void PrintOwing_AfterRefactoring(string name)
    {
        PrintBanner();
        PrintDetails(name);
    }
}