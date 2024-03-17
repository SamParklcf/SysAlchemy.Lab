namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: Your code uses a number that has a certain meaning to it. <para/>
/// Solution: Replace this number with a constant that has a human-readable name explaining the meaning of the number. <para/>
/// See also <a href="https://refactoring.guru/replace-magic-number-with-symbolic-constant">replace-magic-number-with-symbolic-constant</a>
/// </summary>
public class ReplaceMagicNumberWithSymbolicConstant : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Magic Number with Symbolic Constant";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Your code uses a number that has a certain meaning to it." +
               $"{Environment.NewLine}" +
               $"double PotentialEnergy(double mass, double height) \n{{\n  return mass * height * 9.81;\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Replace this number with a constant that has a human-readable name explaining the meaning of the number." +
            $"{Environment.NewLine}" +
            $"const double GRAVITATIONAL_CONSTANT = 9.81;\n\ndouble PotentialEnergy(double mass, double height) \n{{\n  return mass * height * GRAVITATIONAL_CONSTANT;\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"A magic number is a numeric value that’s encountered in the source but has no obvious meaning. " +
            $"This “anti-pattern” makes it harder to understand the program and refactor the code." +
            $"{Environment.NewLine}" +
            $"Yet more difficulties arise when you need to change this magic number. " +
            $"Find and replace won’t work for this: the same number may be used for different purposes in different places, " +
            $"meaning that you will have to verify every line of code that uses this number.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"- The symbolic constant can serve as live documentation of the meaning of its value." +
               $"{Environment.NewLine}" +
               $"- It’s much easier to change the value of a constant than to search for this number throughout " +
               $"the entire codebase, without the risk of accidentally changing the same number used elsewhere " +
               $"for a different purpose." +
               $"{Environment.NewLine}" +
               $"- Reduce duplicate use of a number or string in the code. This is especially important " +
               $"when the value is complicated and long (such as 3.14159 or 0xCAFEBABE).";
    }

    /// <inheritdoc/>
    public string GoodToKnow()
    {
        return $"Not all numbers are magical." +
               $"{Environment.NewLine}" +
               $"If the purpose of a number is obvious, there’s no need to replace it. A classic example is:" +
               $"{Environment.NewLine}" +
               $"for (i = 0; i < count; i++) {{ ... }}" +
               $"{Environment.NewLine}" +
               $"Alternatives" +
               $"{Environment.NewLine}" +
               $"1. Sometimes a magic number can be replaced with method calls. For example, " +
               $"if you have a magic number that signifies the number of elements in a collection, " +
               $"you don’t need to use it for checking the last element of the collection. " +
               $"Instead, use the standard method for getting the collection length." +
               $"{Environment.NewLine}" +
               $"2. Magic numbers are sometimes used as type code. Say that you have two types of users " +
               $"and you use a number field in a class to specify which is which: administrators are 1 " +
               $"and ordinary users are 2." +
               $"{Environment.NewLine}" +
               $"In this case, you should use one of the refactoring methods to avoid type code:" +
               $"{Environment.NewLine}" +
               $"- Replace Type Code with Class" +
               $"{Environment.NewLine}" +
               $"- Replace Type Code with Subclasses" +
               $"{Environment.NewLine}" +
               $"- Replace Type Code with State/Strategy";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Declare a constant and assign the value of the magic number to it." +
               $"{Environment.NewLine}" +
               $"2. Find all mentions of the magic number." +
               $"{Environment.NewLine}" +
               $"3. For each of the numbers that you find, double-check that the magic number " +
               $"in this particular case corresponds to the purpose of the constant. " +
               $"If yes, replace the number with your constant. This is an important step, " +
               $"since the same number can mean absolutely different things (and replaced with different constants, " +
               $"as the case may be).";
    }
}