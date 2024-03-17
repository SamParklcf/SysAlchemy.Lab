namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: You have subclasses differing only in their (constant-returning) methods. <para/>
/// Solution: Replace the methods with fields in the parent class and delete the subclasses. <para/>
/// See also <a href="https://refactoring.guru/replace-subclass-with-fields">replace-subclass-with-fields</a>
/// </summary>
public class ReplaceSubclassWithFields : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Subclass with Fields";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have subclasses differing only in their (constant-returning) methods.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Replace the methods with fields in the parent class and delete the subclasses.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return $"Sometimes refactoring is just the ticket for avoiding type code." +
               $"{Environment.NewLine}" +
               $"In one such case, a hierarchy of subclasses may be different only in the values returned by particular methods. " +
               $"These methods aren’t even the result of computation, but are strictly set out " +
               $"in the methods themselves or in the fields returned by the methods. " +
               $"To simplify the class architecture, this hierarchy can be compressed into a single class " +
               $"containing one or several fields with the necessary values, based on the situation." +
               $"{Environment.NewLine}" +
               $"These changes may become necessary after moving a large amount of functionality " +
               $"from a class hierarchy to another place. The current hierarchy is no longer so valuable " +
               $"and its subclasses are now just dead weight.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"Simplifies system architecture. Creating subclasses is overkill if all you want to do is " +
            $"to return different values in different methods.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Apply Replace Constructor with Factory Method to the subclasses." +
               $"{Environment.NewLine}" +
               $"2. Replace subclass constructor calls with superclass factory method calls." +
               $"{Environment.NewLine}" +
               $"3. In the superclass, declare fields for storing the values of each of the subclass methods " +
               $"that return constant values." +
               $"{Environment.NewLine}" +
               $"4. Create a protected superclass constructor for initializing the new fields." +
               $"{Environment.NewLine}" +
               $"5. Create or modify the existing subclass constructors so that they call the new constructor " +
               $"of the parent class and pass the relevant values to it." +
               $"{Environment.NewLine}" +
               $"6. Implement each constant method in the parent class so that it returns the value " +
               $"of the corresponding field. Then remove the method from the subclass." +
               $"{Environment.NewLine}" +
               $"7. If the subclass constructor has additional functionality, " +
               $"use Inline Method to incorporate the constructor into the superclass factory method." +
               $"{Environment.NewLine}" +
               $"8. Delete the subclass.";
    }
}