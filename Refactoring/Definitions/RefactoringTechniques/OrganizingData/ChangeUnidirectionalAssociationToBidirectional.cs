namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: You have two classes that each need to use the features of the other, but the association between them is only unidirectional. <para/>
/// Solution: Add the missing association to the class that needs it. <para/>
/// See also <a href="https://refactoring.guru/change-unidirectional-association-to-bidirectional">change-unidirectional-association-to-bidirectional</a>
/// </summary>
public class ChangeUnidirectionalAssociationToBidirectional : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Change Unidirectional Association to Bidirectional";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"You have two classes that each need to use the features of the other, but the association between them is only unidirectional.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Add the missing association to the class that needs it.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Originally the classes had a unidirectional association. But with time, " +
            $"client code needed access to both sides of the association.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"If a class needs a reverse association, you can simply calculate it. " +
            $"But if these calculations are complex, it’s better to keep the reverse association.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return $"- Bidirectional associations are much harder to implement and maintain than unidirectional ones." +
               $"{Environment.NewLine}" +
               $"Bidirectional associations make classes interdependent. With a unidirectional association, " +
               $"one of them can be used independently of the other.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Add a field for holding the reverse association." +
               $"{Environment.NewLine}" +
               $"2. Decide which class will be “dominant”. This class will contain the methods that " +
               $"create or update the association as elements are added or changed, " +
               $"establishing the association in its class and calling the utility methods for " +
               $"establishing the association in the associated object." +
               $"{Environment.NewLine}" +
               $"3. Create a utility method for establishing the association in the “non-dominant” class. " +
               $"The method should use what it’s given in parameters to complete the field. " +
               $"Give the method an obvious name so that it isn’t used later for any other purposes." +
               $"{Environment.NewLine}" +
               $"4. If old methods for controlling the unidirectional association were in the “dominant” class, " +
               $"complement them with calls to utility methods from the associated object." +
               $"{Environment.NewLine}" +
               $"5. If the old methods for controlling the association were in the “non-dominant” class," +
               $" create the methods in the “dominant” class, call them, and delegate execution to them.";
    }
}