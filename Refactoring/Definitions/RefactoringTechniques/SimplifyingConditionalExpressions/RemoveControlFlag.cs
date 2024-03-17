namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingConditionalExpressions;

/// <summary>
/// Problem: You have a boolean variable that acts as a control flag for multiple boolean expressions. <para/>
/// Solution: Instead of the variable, use break, continue and return. <para/>
/// See also <a href="https://refactoring.guru/remove-control-flag">remove-control-flag</a>
/// </summary>
public class RemoveControlFlag : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Remove Control Flag";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have a boolean variable that acts as a control flag for multiple boolean expressions.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Instead of the variable, use break, continue and return.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Control flags date back to the days of yore, when “proper” programmers always had one entry point for their functions (the function declaration line) and one exit point (at the very end of the function)." +
            $"{Environment.NewLine}" +
            $"In modern programming languages this style tic is obsolete, since we have special operators for modifying the control flow in loops and other complex constructions:" +
            $"{Environment.NewLine}" +
            $"- break: stops loop" +
            $"{Environment.NewLine}" +
            $"- continue: stops execution of the current loop branch and goes to check the loop conditions in the next iteration" +
            $"{Environment.NewLine}" +
            $"- return: stops execution of the entire function and returns its result if given in the operator";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"Control flag code is often much more ponderous than code written with control flow operators.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Find the value assignment to the control flag that causes the exit from the loop or current iteration." +
            $"{Environment.NewLine}" +
            $"2. Replace it with break, if this is an exit from a loop; continue, if this is an exit from an iteration, or return, if you need to return this value from the function." +
            $"{Environment.NewLine}" +
            $"3. Remove the remaining code and checks associated with the control flag.";
    }
}