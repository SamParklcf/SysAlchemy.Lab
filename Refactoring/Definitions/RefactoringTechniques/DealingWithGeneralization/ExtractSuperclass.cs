namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: You have two classes with common fields and methods. <para/>
/// Solution: Create a shared superclass for them and move all the identical fields and methods to it. <para/>
/// See also <a href="https://refactoring.guru/extract-superclass">extract-superclass</a>
/// </summary>
public class ExtractSuperclass : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Extract Superclass";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have two classes with common fields and methods.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Create a shared superclass for them and move all the identical fields and methods to it.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"One type of code duplication occurs when two classes perform similar tasks in the same way, " +
            $"or perform similar tasks in different ways. Objects offer a built-in mechanism " +
            $"for simplifying such situations via inheritance. But oftentimes this similarity remains unnoticed " +
            $"until classes are created, necessitating that an inheritance structure be created later.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"Code deduplication. Common fields and methods now “live” in one place only.";
    }

    /// <inheritdoc/>
    public string WhenNotToUse()
    {
        return $"You can not apply this technique to classes that already have a superclass.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create an abstract superclass." +
               $"{Environment.NewLine}" +
               $"2. Use Pull Up Field, Pull Up Method, and Pull Up Constructor Body to move the common functionality " +
               $"to a superclass. Start with the fields, since in addition to the common fields you will need " +
               $"to move the fields that are used in the common methods." +
               $"{Environment.NewLine}" +
               $"3. Look for places in the client code where use of subclasses can be replaced " +
               $"with your new class (such as in type declarations).";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}