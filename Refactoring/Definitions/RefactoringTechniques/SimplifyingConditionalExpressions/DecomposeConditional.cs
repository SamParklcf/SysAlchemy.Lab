namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingConditionalExpressions;

/// <summary>
/// Problem: You have a complex conditional (if-then/else or switch). <para/>
/// Solution: Decompose the complicated parts of the conditional into separate methods: the condition, then and else. <para/>
/// See also <a href="https://refactoring.guru/decompose-conditional">decompose-conditional</a>
/// </summary>
public class DecomposeConditional : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Decompose Conditional";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have a complex conditional (if-then/else or switch)." +
               $"{Environment.NewLine}" +
               $"if (date < SUMMER_START || date > SUMMER_END) \n{{\n  charge = quantity * winterRate + winterServiceCharge;\n}}\nelse \n{{\n  charge = quantity * summerRate;\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Decompose the complicated parts of the conditional into separate methods: the condition, then and else." +
            $"{Environment.NewLine}" +
            $"if (isSummer(date))\n{{\n  charge = SummerCharge(quantity);\n}}\nelse \n{{\n  charge = WinterCharge(quantity);\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"The longer a piece of code is, the harder it’s to understand. Things become even more hard to understand when the code is filled with conditions:" +
            $"{Environment.NewLine}" +
            $"- While you’re busy figuring out what the code in the then block does, you forget what the relevant condition was." +
            $"{Environment.NewLine}" +
            $"- While you’re busy parsing else, you forget what the code in then does.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- By extracting conditional code to clearly named methods, you make life easier for the person who’ll be maintaining the code later (such as you, two months from now!)." +
            $"{Environment.NewLine}" +
            $"- This refactoring technique is also applicable for short expressions in conditions. The string isSalaryDay() is much prettier and more descriptive than code for comparing dates.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Extract the conditional to a separate method via 'Extract Method'." +
               $"{Environment.NewLine}" +
               $"2. Repeat the process for the then and else blocks.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}