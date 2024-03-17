namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods;

/// <summary>
/// Problem: You place the result of an expression in a local variable for later use in your code. <para/>
/// Solution: Move the entire expression to a separate method and return the result from it. Query the method instead of using a variable. Incorporate the new method in other methods, if necessary.<para/>
/// See also <a href="https://refactoring.guru/replace-temp-with-query">replace-temp-with-query</a>
/// </summary>
public class ReplaceTempWithQuery : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Temp with Query";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You place the result of an expression in a local variable for later use in your code." +
               $"{Environment.NewLine}" +
               $"double CalculateTotal() \n{{\n  double basePrice = quantity * itemPrice;\n  \n  if (basePrice > 1000) \n  {{\n    return basePrice * 0.95;\n  }}\n  else \n  {{\n    return basePrice * 0.98;\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Move the entire expression to a separate method and return the result from it. " +
            $"Query the method instead of using a variable. Incorporate the new method in other methods, if necessary." +
            $"{Environment.NewLine}" +
            $"double CalculateTotal() \n{{\n  if (BasePrice() > 1000) \n  {{\n    return BasePrice() * 0.95;\n  }}\n  else \n  {{\n    return BasePrice() * 0.98;\n  }}\n}}\ndouble BasePrice() \n{{\n  return quantity * itemPrice;\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"This refactoring can lay the groundwork for applying 'Extract Method' for a portion of a very long method." +
            $"{Environment.NewLine}" +
            $"The same expression may sometimes be found in other methods as well, which is one reason to consider creating a common method.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- Code readability. It’s much easier to understand the purpose of the method getTax() than the line orderPrice() * 0.2." +
            $"{Environment.NewLine}" +
            $"- Slimmer code via deduplication, if the line being replaced is used in multiple methods.";
    }

    /// <inheritdoc/>
    public string GoodToKnow()
    {
        return
            $"Performance: This refactoring may prompt the question of whether this approach is liable to cause a performance hit. " +
            $"The honest answer is: yes, it is, since the resulting code may be burdened by querying a new method. " +
            $"But with today’s fast CPUs and excellent compilers, the burden will almost always be minimal. " +
            $"By contrast, readable code and the ability to reuse this method in other places in program code—thanks " +
            $"to this refactoring approach—are very noticeable benefits." +
            $"{Environment.NewLine}" +
            $"Nonetheless, if your temp variable is used to cache the result of a truly time-consuming expression, " +
            $"you may want to stop this refactoring after extracting the expression to a new method.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Make sure that a value is assigned to the variable once and only once within the method. " +
            $"If not, use 'Split Temporary Variable' to ensure that the variable will be used only to store the result of your expression." +
            $"{Environment.NewLine}" +
            $"2. Use 'Extract Method' to place the expression of interest in a new method. " +
            $"Make sure that this method only returns a value and does’t change the state of the object. " +
            $"If the method affects the visible state of the object, use 'Separate Query from Modifier'." +
            $"{Environment.NewLine}" +
            $"3. Replace the variable with a query to your new method.";
    }
}