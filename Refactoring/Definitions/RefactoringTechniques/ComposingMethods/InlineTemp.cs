namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods;

/// <summary>
/// Problem: You have a temporary variable that’s assigned the result of a simple expression and nothing more. <para/>
/// Solution: Replace the references to the variable with the expression itself. <para/>
/// See also <a href="https://refactoring.guru/inline-temp">inline-temp</a>
/// </summary>
public class InlineTemp : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Inline Temp";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have a temporary variable that’s assigned the result of a simple expression and nothing more." +
               $"{Environment.NewLine}" +
               $"bool HasDiscount(Order order)\n{{\n  double basePrice = order.BasePrice();\n  return basePrice > 1000;\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Replace the references to the variable with the expression itself." +
               $"{Environment.NewLine}" +
               $"bool HasDiscount(Order order)\n{{\n  return order.BasePrice() > 1000;\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Inline local variables are almost always used as part of 'Replace Temp with Query' or to pave the way for 'Extract Method'.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"This refactoring technique offers almost no benefit in and of itself. However, " +
            $"if the variable is assigned the result of a method, you can marginally improve the readability of the program " +
            $"by getting rid of the unnecessary variable.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"Sometimes seemingly useless temps are used to cache the result of an expensive operation that’s reused several times. " +
            $"So before using this refactoring technique, make sure that simplicity won’t come at the cost of performance.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Find all places that use the variable. Instead of the variable, use the expression that had been assigned to it." +
            $"{Environment.NewLine}" +
            $"2. Delete the declaration of the variable and its assignment line.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"1. You have a simple expression that the result held in a variable and nothing more, please apply this " +
        $"refactoring to this useless variable then." +
        $"{Environment.NewLine}" +
        $"2. When a useless variable uses to cache an expensive operation result, you must not apply this refactoring.";
}