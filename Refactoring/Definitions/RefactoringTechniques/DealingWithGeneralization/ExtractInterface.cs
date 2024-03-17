namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: Multiple clients are using the same part of a class interface. Another case: part of the interface in two classes is the same. <para/>
/// Solution: Move this identical portion to its own interface. <para/>
/// See also <a href="https://refactoring.guru/extract-interface">extract-interface</a>
/// </summary>
public class ExtractInterface : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Extract Interface";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"Multiple clients are using the same part of a class interface. " +
            $"Another case: part of the interface in two classes is the same.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Move this identical portion to its own interface.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"1. Interfaces are very apropos when classes play special roles in different situations. " +
            $"Use Extract Interface to explicitly indicate which role." +
            $"{Environment.NewLine}" +
            $"2. Another convenient case arises when you need to describe the operations " +
            $"that a class performs on its server. If it’s planned to eventually allow use of servers of multiple types, " +
            $"all servers must implement the interface.";
    }

    /// <inheritdoc/>
    public string GoodToKnow()
    {
        return $"There’s a certain resemblance between Extract Superclass and Extract Interface." +
               $"{Environment.NewLine}" +
               $"Extracting an interface allows isolating only common interfaces, not common code. In other words, " +
               $"if classes contain Duplicate Code, extracting the interface won’t help you to deduplicate." +
               $"{Environment.NewLine}" +
               $"All the same, this problem can be mitigated by applying Extract Class to move the behavior " +
               $"that contains the duplication to a separate component and delegating all the work to it. " +
               $"If the common behavior is large in size, you can always use Extract Superclass. " +
               $"This is even easier, of course, but remember that if you take this path you will get only one parent class.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create an empty interface." +
               $"{Environment.NewLine}" +
               $"2. Declare common operations in the interface." +
               $"{Environment.NewLine}" +
               $"3. Declare the necessary classes as implementing the interface." +
               $"{Environment.NewLine}" +
               $"4. Change type declarations in the client code to use the new interface.";
    }
}