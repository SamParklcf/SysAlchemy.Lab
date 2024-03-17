namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods;

/// <summary>
/// Problem: When a method body is more obvious than the method itself, use this technique. <para/>
/// Solution: Replace calls to the method with the method’s content and delete the method itself. <para/>
/// See also <a href="https://refactoring.guru/inline-method">inline-method</a>
/// </summary>
public class InlineMethod : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Inline Method";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"When a method body is more obvious than the method itself, use this technique." +
               $"{Environment.NewLine}" +
               $"class PizzaDelivery \n{{\n  // ...\n  int GetRating() \n  {{\n    return MoreThanFiveLateDeliveries() ? 2 : 1;\n  }}\n  bool MoreThanFiveLateDeliveries() \n  {{\n    return numberOfLateDeliveries > 5;\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Replace calls to the method with the method’s content and delete the method itself." +
               $"{Environment.NewLine}" +
               $"class PizzaDelivery \n{{\n  // ...\n  int GetRating() \n  {{\n    return numberOfLateDeliveries > 5 ? 2 : 1;\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"A method simply delegates to another method. In itself, this delegation is no problem. " +
            $"But when there are many such methods, they become a confusing tangle that’s hard to sort through." +
            $"{Environment.NewLine}" +
            $"Often methods aren’t too short originally, but become that way as changes are made to the program. " +
            $"So don’t be shy about getting rid of methods that have outlived their use.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"By minimizing the number of unneeded methods, you make the code more straightforward.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Make sure that the method isn’t redefined in subclasses. If the method is redefined, refrain from this technique." +
            $"{Environment.NewLine}" +
            $"2. Find all calls to the method. Replace these calls with the content of the method." +
            $"{Environment.NewLine}" +
            $"3. Delete the method.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"1. When there are many methods that are simply delegates to another methods, " +
        $"they become a confusing tangle that’s hard to sort through." +
        $"{Environment.NewLine}" +
        $"2. By minimizing the number of unneeded methods, you make the code more straightforward." +
        $"{Environment.NewLine}" +
        $"3. Be aware of that: the method isn’t redefined in subclasses. " +
        $"If the method is redefined, refrain from this technique.";
}