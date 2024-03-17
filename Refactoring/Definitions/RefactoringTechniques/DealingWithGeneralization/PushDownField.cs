namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: Is a field used only in a few subclasses? <para/>
/// Solution: Move the field to these subclasses. <para/>
/// See also <a href="https://refactoring.guru/push-down-field">push-down-field</a>
/// </summary>
public class PushDownField : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Push Down Field";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Is a field used only in a few subclasses?";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Move the field to these subclasses.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Although it was planned to use a field universally for all classes, " +
            $"in reality the field is used only in some subclasses. " +
            $"This situation can occur when planned features fail to pan out, for example." +
            $"{Environment.NewLine}" +
            $"This can also occur due to extraction (or removal) of part of the functionality of class hierarchies.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"- Improves internal class coherency. A field is located where it’s actually used." +
               $"{Environment.NewLine}" +
               $"- When moving to several subclasses simultaneously, you can develop the fields independently of each other." +
               $" This does create code duplication, yes, so push down fields only " +
               $"when you really do intend to use the fields in different ways.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Declare a field in all the necessary subclasses." +
               $"{Environment.NewLine}" +
               $"2. Remove the field from the superclass.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}