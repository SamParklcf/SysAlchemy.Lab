namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: You have a subclass that uses only a portion of the methods of its superclass (or it’s not possible to inherit superclass data). <para/>
/// Solution: Create a field and put a superclass object in it, delegate methods to the superclass object, and get rid of inheritance. <para/>
/// See also <a href="https://refactoring.guru/replace-inheritance-with-delegation">replace-inheritance-with-delegation</a>
/// </summary>
public class ReplaceInheritanceWithDelegation : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Inheritance with Delegation";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"You have a subclass that uses only a portion of the methods of its superclass " +
            $"(or it’s not possible to inherit superclass data).";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Create a field and put a superclass object in it, delegate methods to the superclass object, " +
            $"and get rid of inheritance.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return $"Replacing inheritance with composition can substantially improve class design if:" +
               $"{Environment.NewLine}" +
               $"- Your subclass violates the Liskov substitution principle, i.e., " +
               $"if inheritance was implemented only to combine common code but not because the subclass is " +
               $"an extension of the superclass." +
               $"{Environment.NewLine}" +
               $"- The subclass uses only a portion of the methods of the superclass. In this case, " +
               $"it’s only a matter of time before someone calls a superclass method that he or she was’t supposed to call." +
               $"{Environment.NewLine}" +
               $"In essence, this refactoring technique splits both classes and makes the superclass " +
               $"the helper of the subclass, not its parent. Instead of inheriting all superclass methods, " +
               $"the subclass will have only the necessary methods for delegating to the methods of the superclass object.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"- A class does’t contain any unneeded methods inherited from the superclass." +
               $"{Environment.NewLine}" +
               $"- Various objects with various implementations can be put in the delegate field. " +
               $"In effect you get the Strategy design pattern.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return $"You have to write many simple delegating methods.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Create a field in the subclass for holding the superclass. During the initial stage, " +
            $"place the current object in it." +
            $"{Environment.NewLine}" +
            $"2. Change the subclass methods so that they use the superclass object instead of this." +
            $"{Environment.NewLine}" +
            $"3. For methods inherited from the superclass that are called in the client code, " +
            $"create simple delegating methods in the subclass." +
            $"{Environment.NewLine}" +
            $"4. Remove the inheritance declaration from the subclass." +
            $"{Environment.NewLine}" +
            $"5. Change the initialization code of the field in which the former superclass " +
            $"is stored by creating a new object.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}