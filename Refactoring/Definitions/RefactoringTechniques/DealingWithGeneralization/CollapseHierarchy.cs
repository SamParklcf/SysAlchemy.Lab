namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: You have a class hierarchy in which a subclass is practically the same as its superclass. <para/>
/// Solution: Merge the subclass and superclass. <para/>
/// See also <a href="https://refactoring.guru/collapse-hierarchy">collapse-hierarchy</a>
/// </summary>
public class CollapseHierarchy : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Collapse Hierarchy";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have a class hierarchy in which a subclass is practically the same as its superclass.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Merge the subclass and superclass.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Your program has grown over time and a subclass and superclass have become practically the same. " +
            $"A feature was removed from a subclass, a method was moved to the superclass... " +
            $"and now you have two look-alike classes.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- Program complexity is reduced. Fewer classes mean fewer things to keep straight in your head " +
            $"and fewer breakable moving parts to worry about during future code changes." +
            $"{Environment.NewLine}" +
            $"- Navigating through your code is easier when methods are defined in one class early. " +
            $"You don’t need to comb through the entire hierarchy to find a particular method.";
    }

    /// <inheritdoc/>
    public string WhenNotToUse()
    {
        return
            $"- Does the class hierarchy that you’re refactoring have more than one subclass? " +
            $"If so, after refactoring is complete, the remaining subclasses should become " +
            $"the inheritors of the class in which the hierarchy was collapsed." +
            $"{Environment.NewLine}" +
            $"- But keep in mind that this can lead to violations of the Liskov substitution principle. " +
            $"For example, if your program emulates city transport networks and you accidentally collapse " +
            $"the Transport superclass into the Car subclass, then the Plane class may become the inheritor of Car. " +
            $"Oops!";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Select which class is easier to remove: the superclass or its subclass." +
               $"{Environment.NewLine}" +
               $"2. Use Pull Up Field and Pull Up Method if you decide to get rid of the subclass. " +
               $"If you choose to eliminate the superclass, go for Push Down Field and Push Down Method." +
               $"{Environment.NewLine}" +
               $"3. Replace all uses of the class that you’re deleting with the class to which " +
               $"the fields and methods are to be migrated. Often this will be code for creating classes, " +
               $"variable and parameter typing, and documentation in code comments." +
               $"{Environment.NewLine}" +
               $"4. Delete the empty class.";
    }
}