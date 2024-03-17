namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: A method is split into parts, each of which is run depending on the value of a parameter. <para/>
/// Solution: Extract the individual parts of the method into their own methods and call them instead of the original method. <para/>
/// See also <a href="https://refactoring.guru/replace-parameter-with-explicit-methods">replace-parameter-with-explicit-methods</a>
/// </summary>
public class ReplaceParameterWithExplicitMethods : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Parameter with Explicit Methods";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"A method is split into parts, each of which is run depending on the value of a parameter." +
               $"{Environment.NewLine}" +
               $"void SetValue(string name, int value) \n{{\n  if (name.Equals(\"height\")) \n  {{\n    height = value;\n    return;\n  }}\n  if (name.Equals(\"width\")) \n  {{\n    width = value;\n    return;\n  }}\n  Assert.Fail();\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Extract the individual parts of the method into their own methods and call them instead of the original method." +
            $"{Environment.NewLine}" +
            $"void SetHeight(int arg) \n{{\n  height = arg;\n}}\nvoid SetWidth(int arg) \n{{\n  width = arg;\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"A method containing parameter-dependent variants has grown massive. " +
            $"Non-trivial code is run in each branch and new variants are added very rarely.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"Improves code readability. It’s much easier to understand " +
            $"the purpose of startEngine() than setValue(\"engineEnabled\", true).";
    }

    /// <inheritdoc/>
    public string WhenNotToUse()
    {
        return
            $"Don’t replace a parameter with explicit methods if a method is rarely changed " +
            $"and new variants aren’t added inside it.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. For each variant of the method, create a separate method. " +
            $"Run these methods based on the value of a parameter in the main method." +
            $"{Environment.NewLine}" +
            $"2. Find all places where the original method is called. In these places, " +
            $"place a call for one of the new parameter-dependent variants." +
            $"{Environment.NewLine}" +
            $"3. When no calls to the original method remain, delete it.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}