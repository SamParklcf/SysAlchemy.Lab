namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingConditionalExpressions;

/// <summary>
/// Problem: You have multiple conditionals that lead to the same result or action. <para/>
/// Solution: Consolidate all these conditionals in a single expression. <para/>
/// See also <a href=""></a>
/// </summary>
public class ConsolidateConditionalExpression : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Consolidate Conditional Expression";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have multiple conditionals that lead to the same result or action." +
               $"{Environment.NewLine}" +
               $"double DisabilityAmount() \n{{\n  if (seniority < 2) \n  {{\n    return 0;\n  }}\n  if (monthsDisabled > 12) \n  {{\n    return 0;\n  }}\n  if (isPartTime) \n  {{\n    return 0;\n  }}\n  // Compute the disability amount.\n  // ...\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Consolidate all these conditionals in a single expression." +
               $"{Environment.NewLine}" +
               $"double DisabilityAmount()\n{{\n  if (IsNotEligibleForDisability())\n  {{\n    return 0;\n  }}\n  // Compute the disability amount.\n  // ...\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Your code contains many alternating operators that perform identical actions. " +
            $"It isn’t clear why the operators are split up." +
            $"{Environment.NewLine}" +
            $"The main purpose of consolidation is to extract the conditional to a separate method for greater clarity.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- Eliminates duplicate control flow code. Combining multiple conditionals " +
            $"that have the same “destination” helps to show that you’re doing only one complicated " +
            $"check leading to one action." +
            $"{Environment.NewLine}" +
            $"- By consolidating all operators, you can now isolate this complex expression " +
            $"in a new method with a name that explains the conditional’s purpose.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"Before refactoring, make sure that the conditionals don’t have any “side effects” or otherwise modify something, " +
            $"instead of simply returning values. Side effects may be hiding in the code executed inside the operator itself, " +
            $"such as when something is added to a variable based on the results of a conditional." +
            $"{Environment.NewLine}" +
            $"1. Consolidate the conditionals in a single expression by using and and or. " +
            $"As a general rule when consolidating:" +
            $"{Environment.NewLine}" +
            $"- Nested conditionals are joined using and." +
            $"{Environment.NewLine}" +
            $"- Consecutive conditionals are joined with or." +
            $"{Environment.NewLine}" +
            $"2. Perform 'Extract Method' on the operator conditions and give the method a name that reflects the expression’s purpose.";
    }
}