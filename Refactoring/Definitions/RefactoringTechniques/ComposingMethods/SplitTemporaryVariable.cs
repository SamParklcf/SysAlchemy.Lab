﻿namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods;

/// <summary>
/// Problem: You have a local variable that’s used to store various intermediate values inside a method (except for cycle variables). <para/>
/// Solution: Use different variables for different values. Each variable should be responsible for only one particular thing. <para/>
/// See also <a href="https://refactoring.guru/split-temporary-variable">split-temporary-variable</a>
/// </summary>
public class SplitTemporaryVariable : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Split Temporary Variable";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"You have a local variable that’s used to store various intermediate values inside a method (except for cycle variables)." +
            $"{Environment.NewLine}" +
            $"double temp = 2 * (height + width);\nConsole.WriteLine(temp);\ntemp = height * width;\nConsole.WriteLine(temp);";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Use different variables for different values. Each variable should be responsible for only one particular thing." +
            $"{Environment.NewLine}" +
            $"readonly double perimeter = 2 * (height + width);\nConsole.WriteLine(perimeter);\nreadonly double area = height * width;\nConsole.WriteLine(area);";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"If you’re skimping on the number of variables inside a function and reusing them for various unrelated purposes, " +
            $"you’re sure to encounter problems as soon as you need to make changes to the code containing the variables. " +
            $"You will have to recheck each case of variable use to make sure that the correct values are used.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- Each component of the program code should be responsible for one and one thing only. " +
            $"This makes it much easier to maintain the code, since you can easily replace " +
            $"any particular thing without fear of unintended effects." +
            $"{Environment.NewLine}" +
            $"- Code becomes more readable. If a variable was created long ago in a rush, " +
            $"it probably has a name that does’t explain anything: k, a2, value, etc. But you can fix this situation " +
            $"by naming the new variables in an understandable, self-explanatory way. Such names might resemble " +
            $"customerTaxValue, cityUnemploymentRate, clientSalutationString and the like." +
            $"{Environment.NewLine}" +
            $"- This refactoring technique is useful if you anticipate using 'Extract Method' later.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Find the first place in the code where the variable is given a value. Here you should rename " +
            $"the variable with a name that corresponds to the value being assigned." +
            $"{Environment.NewLine}" +
            $"2. Use the new name instead of the old one in places where this value of the variable is used." +
            $"{Environment.NewLine}" +
            $"3. Repeat as needed for places where the variable is assigned a different value.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"1. Each component of the program code should be responsible for one and one thing only. " +
        $"this makes it much easier to maintain the code" +
        $"{Environment.NewLine}" +
        $"2. Code becomes more readable.";
}