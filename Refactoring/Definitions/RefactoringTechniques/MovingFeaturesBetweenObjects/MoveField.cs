namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.MovingFeaturesBetweenObjects;

/// <summary>
/// Problem: A field is used more in another class than in its own class. <para/>
/// Solution: Create a field in a new class and redirect all users of the old field to it. <para/>
/// See also <a href="https://refactoring.guru/move-field">move-field</a>
/// </summary>
public class MoveField : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Move Field";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"A field is used more in another class than in its own class.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Create a field in a new class and redirect all users of the old field to it.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Often fields are moved as part of the 'Extract Class' technique. Deciding which class to leave the field in can be tough. " +
            $"Here is our rule of thumb: put a field in the same place as the methods that use it " +
            $"(or else where most of these methods are)." +
            $"{Environment.NewLine}" +
            $"This rule will help in other cases when a field is simply located in the wrong place.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. If the field is public, refactoring will be much easier if you make the field private and " +
            $"provide public access methods (for this, you can use 'Encapsulate Field')." +
            $"{Environment.NewLine}" +
            $"2. Create the same field with access methods in the recipient class." +
            $"{Environment.NewLine}" +
            $"3. Decide how you will refer to the recipient class. You may already have a field or method that " +
            $"returns the appropriate object; if not, you will need to write a new method or field to store " +
            $"the object of the recipient class." +
            $"{Environment.NewLine}" +
            $"4. Replace all references to the old field with appropriate calls to methods in the recipient class. " +
            $"If the field isn’t private, take care of this in the superclass and subclasses." +
            $"{Environment.NewLine}" +
            $"5. Delete the field in the original class.";
    }
}