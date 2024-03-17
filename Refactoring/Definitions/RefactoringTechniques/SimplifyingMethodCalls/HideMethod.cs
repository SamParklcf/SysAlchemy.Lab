namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: A method isn’t used by other classes or is used only inside its own class hierarchy. <para/>
/// Solution: Make the method private or protected. <para/>
/// See also <a href="https://refactoring.guru/hide-method">hide-method</a>
/// </summary>
public class HideMethod : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Hide Method";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"A method isn’t used by other classes or is used only inside its own class hierarchy.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Make the method private or protected.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Quite often, the need to hide methods for getting and setting values is " +
            $"due to development of a richer interface that provides additional behavior, " +
            $"especially if you started with a class that added little beyond mere data encapsulation." +
            $"{Environment.NewLine}" +
            $"As new behavior is built into the class, you may find that public getter and setter methods " +
            $"are no longer necessary and can be hidden. If you make getter or setter methods private " +
            $"and apply direct access to variables, you can delete the method.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- Hiding methods makes it easier for your code to evolve. When you change a private method, " +
            $"you only need to worry about how to not break the current class since you know " +
            $"that the method can’t be used anywhere else." +
            $"{Environment.NewLine}" +
            $"- By making methods private, you underscore the importance of the public interface of the class " +
            $"and of the methods that remain public.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Regularly try to find methods that can be made private. Static code analysis " +
            $"and good unit test coverage can offer a big leg up." +
            $"{Environment.NewLine}" +
            $"2. Make each method as private as possible.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}