namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: The value of a field should be set only when it’s created, and not change at any time after that. <para/>
/// Solution: So remove methods that set the field’s value. <para/>
/// See also <a href="https://refactoring.guru/remove-setting-method">remove-setting-method</a>
/// </summary>
public class RemoveSettingMethod : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Remove Setting Method";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"The value of a field should be set only when it’s created, and not change at any time after that.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"So remove methods that set the field’s value.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return $"You want to prevent any changes to the value of a field.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. The value of a field should be changeable only in the constructor. " +
            $"If the constructor does’t contain a parameter for setting the value, add one." +
            $"{Environment.NewLine}" +
            $"2. Find all setter calls." +
            $"{Environment.NewLine}" +
            $"- If a setter call is located right after a call for the constructor of the current class, " +
            $"move its argument to the constructor call and remove the setter." +
            $"{Environment.NewLine}" +
            $"- Replace setter calls in the constructor with direct access to the field." +
            $"{Environment.NewLine}" +
            $"3. Delete the setter.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}