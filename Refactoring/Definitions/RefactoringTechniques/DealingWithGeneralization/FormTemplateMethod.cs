namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: Your subclasses implement algorithms that contain similar steps in the same order. <para/>
/// Solution: Move the algorithm structure and identical steps to a superclass, and leave implementation of the different steps in the subclasses. <para/>
/// See also <a href="https://refactoring.guru/form-template-method">form-template-method</a>
/// </summary>
public class FormTemplateMethod : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Form Template Method";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Your subclasses implement algorithms that contain similar steps in the same order.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Move the algorithm structure and identical steps to a superclass, " +
            $"and leave implementation of the different steps in the subclasses.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Subclasses are developed in parallel, sometimes by different people, " +
            $"which leads to code duplication, errors, and difficulties in code maintenance, " +
            $"since each change must be made in all subclasses.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- Code duplication does’t always refer to cases of simple copy/paste. " +
            $"Often duplication occurs at a higher level, such as when you have a method for sorting numbers " +
            $"and a method for sorting object collections that are differentiated only by the comparison of elements. " +
            $"Creating a template method eliminates this duplication by merging the shared algorithm steps " +
            $"in a superclass and leaving just the differences in the subclasses." +
            $"{Environment.NewLine}" +
            $"- Forming a template method is an example of the Open/Closed Principle in action. " +
            $"When a new algorithm version appears, you need only to create a new subclass; " +
            $"no changes to existing code are required.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Split algorithms in the subclasses into their constituent parts described in separate methods. " +
            $"Extract Method can help with this." +
            $"{Environment.NewLine}" +
            $"2. The resulting methods that are identical for all subclasses can be moved to a superclass via Pull Up Method." +
            $"{Environment.NewLine}" +
            $"3. The non-similar methods can be given consistent names via Rename Method." +
            $"{Environment.NewLine}" +
            $"4. Move the signatures of non-similar methods to a superclass as abstract ones by using Pull Up Method. " +
            $"Leave their implementations in the subclasses." +
            $"{Environment.NewLine}" +
            $"5. And finally, pull up the main method of the algorithm to the superclass. " +
            $"Now it should work with the method steps described in the superclass, both real and abstract.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}