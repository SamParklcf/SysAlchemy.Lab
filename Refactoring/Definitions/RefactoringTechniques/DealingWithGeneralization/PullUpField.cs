namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: Two classes have the same field. <para/>
/// Solution: Remove the field from subclasses and move it to the superclass. <para/>
/// See also <a href="https://refactoring.guru/pull-up-field">pull-up-field</a>
/// </summary>
public class PullUpField : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Pull Up Field";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Two classes have the same field.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Remove the field from subclasses and move it to the superclass.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Subclasses grew and developed separately, causing identical (or nearly identical) fields and methods to appear.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"- Eliminates duplication of fields in subclasses." +
               $"{Environment.NewLine}" +
               $"- Eases subsequent relocation of duplicate methods, if they exist, from subclasses to a superclass.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Make sure that the fields are used for the same needs in subclasses." +
               $"{Environment.NewLine}" +
               $"2. If the fields have different names, give them the same name and replace all references to the fields in existing code." +
               $"{Environment.NewLine}" +
               $"3. Create a field with the same name in the superclass. Note that if the fields were private, " +
               $"the superclass field should be protected." +
               $"{Environment.NewLine}" +
               $"4. Remove the fields from the subclasses." +
               $"{Environment.NewLine}" +
               $"5. You may want to consider using Self Encapsulate Field for the new field, in order to hide it behind access methods.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}