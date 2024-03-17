namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: A class contains many simple methods that delegate to all methods of another class. <para/>
/// Solution: Make the class a delegate inheritor, which makes the delegating methods unnecessary. <para/>
/// See also <a href="https://refactoring.guru/replace-delegation-with-inheritance">replace-delegation-with-inheritance</a>
/// </summary>
public class ReplaceDelegationWithInheritance : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Delegation with Inheritance";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"A class contains many simple methods that delegate to all methods of another class.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Make the class a delegate inheritor, which makes the delegating methods unnecessary.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Delegation is a more flexible approach than inheritance, " +
            $"since it allows changing how delegation is implemented and placing other classes there as well. " +
            $"Nonetheless, delegation stops being beneficial if you delegate actions " +
            $"to only one class and all of its public methods." +
            $"{Environment.NewLine}" +
            $"In such a case, if you replace delegation with inheritance, " +
            $"you cleanse the class of a large number of delegating methods and spare yourself from needing " +
            $"to create them for each new delegate class method.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"Reduces code length. All these delegating methods are no longer necessary.";
    }

    /// <inheritdoc/>
    public string WhenNotToUse()
    {
        return
            $"- Don’t use this technique if the class contains delegation to only a portion of " +
            $"the public methods of the delegate class. By doing so, you would violate the Liskov substitution principle." +
            $"{Environment.NewLine}" +
            $"- This technique can be used only if the class still does’t have parents.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Make the class a subclass of the delegate class." +
               $"{Environment.NewLine}" +
               $"2. Place the current object in a field containing a reference to the delegate object." +
               $"{Environment.NewLine}" +
               $"3. Delete the methods with simple delegation one by one. If their names were different, " +
               $"use Rename Method to give all the methods a single name." +
               $"{Environment.NewLine}" +
               $"4. Replace all references to the delegate field with references to the current object." +
               $"{Environment.NewLine}" +
               $"5. Remove the delegate field.";
    }
}