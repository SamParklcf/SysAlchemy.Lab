namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: Your subclasses have methods that perform similar work. <para/>
/// Solution:  <para/>
/// See also <a href="https://refactoring.guru/pull-up-method">pull-up-method</a>
/// </summary>
public class PullUpMethod : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Pull Up Method";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Your subclasses have methods that perform similar work.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Make the methods identical and then move them to the relevant superclass.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Subclasses grew and developed independently of one another, " +
            $"causing identical (or nearly identical) fields and methods.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- Gets rid of duplicate code. If you need to make changes to a method, " +
            $"it’s better to do so in a single place than have to search for all duplicates of the method in subclasses." +
            $"{Environment.NewLine}" +
            $"- This refactoring technique can also be used if, for some reason, " +
            $"a subclass redefines a superclass method but performs what’s essentially the same work.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Investigate similar methods in superclasses. If they aren’t identical, format them to match each other." +
            $"{Environment.NewLine}" +
            $"2. If methods use a different set of parameters, " +
            $"put the parameters in the form that you want to see in the superclass." +
            $"{Environment.NewLine}" +
            $"3. Copy the method to the superclass. Here you may find that the method code uses fields and methods " +
            $"that exist only in subclasses and therefore aren’t available in the superclass. To solve this, you can:" +
            $"{Environment.NewLine}" +
            $"- For fields: use either Pull Up Field or Self-Encapsulate Field to create getters and setters in subclasses; " +
            $"then declare these getters abstractly in the superclass." +
            $"{Environment.NewLine}" +
            $"- For methods: use either Pull Up Method or declare abstract methods for them in the superclass " +
            $"(note that your class will become abstract if it was’t previously)." +
            $"{Environment.NewLine}" +
            $"4. Remove the methods from the subclasses." +
            $"{Environment.NewLine}" +
            $"5. Check the locations in which the method is called. " +
            $"In some places you may be able to replace use of a subclass with the superclass.";
    }
}