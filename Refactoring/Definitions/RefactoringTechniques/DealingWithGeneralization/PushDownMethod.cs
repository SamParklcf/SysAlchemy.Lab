namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: Is behavior implemented in a superclass used by only one (or a few) subclasses? <para/>
/// Solution: Move this behavior to the subclasses. <para/>
/// See also <a href="https://refactoring.guru/push-down-method">push-down-method</a>
/// </summary>
public class PushDownMethod : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Push Down Method";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Is behavior implemented in a superclass used by only one (or a few) subclasses?";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Move this behavior to the subclasses.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"At first a certain method was meant to be universal for all classes but in reality is used in only one subclass. " +
            $"This situation can occur when planned features fail to materialize." +
            $"{Environment.NewLine}" +
            $"Such situations can also occur after partial extraction (or removal) of functionality from a class hierarchy, " +
            $"leaving a method that’s used in only one subclass." +
            $"{Environment.NewLine}" +
            $"If you see that a method is needed by more than one subclass, but not all of them, " +
            $"it may be useful to create an intermediate subclass and move the method to it. " +
            $"This allows avoiding the code duplication that would result from pushing a method down to all subclasses.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"Improves class coherence. A method is located where you expect to see it.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Declare the method in a subclass and copy its code from the superclass." +
               $"{Environment.NewLine}" +
               $"2. Remove the method from the superclass." +
               $"{Environment.NewLine}" +
               $"3. Find all places where the method is used and verify that it’s called from the necessary subclass.";
    }
}