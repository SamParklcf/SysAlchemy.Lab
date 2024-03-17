namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingConditionalExpressions;

/// <summary>
/// Problem: Identical code can be found in all branches of a conditional. <para/>
/// Solution: Move the code outside of the conditional. <para/>
/// See also <a href="https://refactoring.guru/consolidate-duplicate-conditional-fragments">consolidate-duplicate-conditional-fragments</a>
/// </summary>
public class ConsolidateDuplicateConditionalFragments : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Consolidate Duplicate Conditional Fragments";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Identical code can be found in all branches of a conditional." +
               $"{Environment.NewLine}" +
               $"if (IsSpecialDeal()) \n{{\n  total = price * 0.95;\n  Send();\n}}\nelse \n{{\n  total = price * 0.98;\n  Send();\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Move the code outside of the conditional." +
               $"{Environment.NewLine}" +
               $"if (IsSpecialDeal())\n{{\n  total = price * 0.95;\n}}\nelse\n{{\n  total = price * 0.98;\n}}\nSend();";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Duplicate code is found inside all branches of a conditional, often as the result of evolution " +
            $"of the code within the conditional branches. Team development can be a contributing factor to this.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"Code deduplication.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. If the duplicated code is at the beginning of the conditional branches, " +
            $"move the code to a place before the conditional." +
            $"{Environment.NewLine}" +
            $"2. If the code is executed at the end of the branches, place it after the conditional." +
            $"{Environment.NewLine}" +
            $"3. If the duplicate code is randomly situated inside the branches, " +
            $"first try to move the code to the beginning or end of the branch, " +
            $"depending on whether it changes the result of the subsequent code." +
            $"{Environment.NewLine}" +
            $"4. If appropriate and the duplicate code is longer than one line, try using 'Extract Method'.";
    }
}