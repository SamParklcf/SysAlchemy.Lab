namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods;

/// <summary>
/// Problem: Some value is assigned to a parameter inside method’s body. <para/>
/// Solution: Use a local variable instead of a parameter. <para/>
/// See also <a href="https://refactoring.guru/remove-assignments-to-parameters">remove-assignments-to-parameters</a>
/// </summary>
public class RemoveAssignmentsToParameters : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Remove Assignments to Parameters";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Some value is assigned to a parameter inside method’s body." +
               $"{Environment.NewLine}" +
               $"int Discount(int inputVal, int quantity) \n{{\n  if (quantity > 50) \n  {{\n    inputVal -= 2;\n  }}\n  // ...\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Use a local variable instead of a parameter." +
               $"{Environment.NewLine}" +
               $"int Discount(int inputVal, int quantity) \n{{\n  int result = inputVal;\n  \n  if (quantity > 50) \n  {{\n    result -= 2;\n  }}\n  // ...\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"The reasons for this refactoring are the same as for 'Split Temporary Variable', " +
            $"but in this case we’re dealing with a parameter, not a local variable." +
            $"{Environment.NewLine}" +
            $"First, if a parameter is passed via reference, then after the parameter value is changed inside the method, " +
            $"this value is passed to the argument that requested calling this method. " +
            $"Very often, this occurs accidentally and leads to unfortunate effects. " +
            $"Even if parameters are usually passed by value (and not by reference) in your programming language, " +
            $"this coding quirk may alienate those who are unaccustomed to it." +
            $"{Environment.NewLine}" +
            $"Second, multiple assignments of different values to a single parameter make it difficult for you to know " +
            $"what data should be contained in the parameter at any particular point in time. " +
            $"The problem worsens if your parameter and its contents are documented but the actual value is capable of differing " +
            $"from what’s expected inside the method.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- Each element of the program should be responsible for only one thing. " +
            $"This makes code maintenance much easier going forward, since you can safely replace code without any side effects." +
            $"{Environment.NewLine}" +
            $"- This refactoring helps to extract 'repetitive code to separate methods'.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a local variable and assign the initial value of your parameter." +
               $"{Environment.NewLine}" +
               $"2. In all method code that follows this line, replace the parameter with your new local variable.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"1. Each component of the program code should be responsible for one and one thing only. " +
        $"this makes it much easier to maintain the code" +
        $"{Environment.NewLine}" +
        $"2. Code becomes more readable.";
}