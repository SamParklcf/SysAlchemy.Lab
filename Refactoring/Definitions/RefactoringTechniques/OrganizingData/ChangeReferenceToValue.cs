namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: You have a reference object that’s too small and infrequently changed to justify managing its life cycle. <para/>
/// Solution: Turn it into a value object. <para/>
/// See also <a href="https://refactoring.guru/change-reference-to-value">change-reference-to-value</a>
/// </summary>
public class ChangeReferenceToValue : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Change Reference to Value";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"You have a reference object that’s too small and infrequently changed to justify managing its life cycle.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Turn it into a value object.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Inspiration to switch from a reference to a value may come from the inconvenience of working with the reference. " +
            $"References require management on your part:" +
            $"{Environment.NewLine}" +
            $"- They always require requesting the necessary object from storage." +
            $"{Environment.NewLine}" +
            $"- References in memory may be inconvenient to work with." +
            $"{Environment.NewLine}" +
            $"- Working with references is particularly difficult, compared to values, on distributed and parallel systems." +
            $"{Environment.NewLine}" +
            $"Values are especially useful if you would rather have unchangeable objects than objects " +
            $"whose state may change during their lifetime.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- One important property of objects is that they should be unchangeable. " +
            $"The same result should be received for each query that returns an object value. If this is true," +
            $" no problems arise if there are many objects representing the same thing." +
            $"{Environment.NewLine}" +
            $"- Values are much easier to implement.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"If a value is changeable, make sure if any object changes that the values in all the other objects " +
            $"representing the same entity are updated. This is so burdensome that it’s easier to create a reference for this purpose.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            "1. Make the object unchangeable. The object shouldn’t have any setters or other methods " +
            "that change its state and data (Remove Setting Method may help here). " +
            "The only place where data should be assigned to the fields of a value object is a constructor." +
            $"{Environment.NewLine}" +
            $"2. Create a comparison method to be able to compare two values." +
            $"{Environment.NewLine}" +
            $"3. Check whether you can delete the factory method and make the object constructor public.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}