namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingConditionalExpressions;

/// <summary>
/// Problem: You have a group of nested conditionals and it’s hard to determine the normal flow of code execution. <para/>
/// Solution: Isolate all special checks and edge cases into separate clauses and place them before the main checks.
/// Ideally, you should have a “flat” list of conditionals, one after the other. <para/>
/// See also <a href="https://refactoring.guru/replace-nested-conditional-with-guard-clauses">replace-nested-conditional-with-guard-clauses</a>
/// </summary>
public class ReplaceNestedConditionalWithGuardClauses : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Nested Conditional with Guard Clauses";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"You have a group of nested conditionals and it’s hard to determine the normal flow of code execution." +
            $"{Environment.NewLine}" +
            $"public double GetPayAmount()\n{{\n  double result;\n  \n  if (isDead)\n  {{\n    result = DeadAmount();\n  }}\n  else \n  {{\n    if (isSeparated)\n    {{\n      result = SeparatedAmount();\n    }}\n    else \n    {{\n      if (isRetired)\n      {{\n        result = RetiredAmount();\n      }}\n      else\n      {{\n        result = NormalPayAmount();\n      }}\n    }}\n  }}\n  \n  return result;\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Isolate all special checks and edge cases into separate clauses and place them before the main checks. " +
            $"Ideally, you should have a “flat” list of conditionals, one after the other." +
            $"{Environment.NewLine}" +
            $"public double GetPayAmount() \n{{\n  if (isDead)\n  {{\n    return DeadAmount();\n  }}\n  if (isSeparated)\n  {{\n    return SeparatedAmount();\n  }}\n  if (isRetired)\n  {{\n    return RetiredAmount();\n  }}\n  return NormalPayAmount();\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Spotting the “conditional from hell” is fairly easy. The indentations of each level of nestedness " +
            $"form an arrow, pointing to the right in the direction of pain and woe:" +
            $"{Environment.NewLine}" +
            $"if () {{\n    if () {{\n        do {{\n            if () {{\n                if () {{\n                    if () {{\n                        ...\n                    }}\n                }}\n                ...\n            }}\n            ...\n        }}\n        while ();\n        ...\n    }}\n    else {{\n        ...\n    }}\n}}" +
            $"{Environment.NewLine}" +
            $"It’s difficult to figure out what each conditional does and how, " +
            $"since the “normal” flow of code execution isn’t immediately obvious. " +
            $"These conditionals indicate halter-skelter evolution, with each condition added " +
            $"as a stopgap measure without any thought paid to optimizing the overall structure." +
            $"{Environment.NewLine}" +
            $"To simplify the situation, isolate the special cases into separate conditions " +
            $"that immediately end execution and return a null value if the guard clauses are true." +
            $" In effect, your mission here is to make the structure flat.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"Try to rid the code of side effects—'Separate Query from Modifier' may be helpful for the purpose. " +
            $"This solution will be necessary for the reshuffling described below." +
            $"{Environment.NewLine}" +
            $"1. Isolate all guard clauses that lead to calling an exception or immediate return of a value from the method. " +
            $"Place these conditions at the beginning of the method." +
            $"{Environment.NewLine}" +
            $"2. After rearrangement is complete and all tests are successfully completed, " +
            $"see whether you can use 'Consolidate Conditional Expression' for guard clauses that lead " +
            $"to the same exceptions or returned values.";
    }
}