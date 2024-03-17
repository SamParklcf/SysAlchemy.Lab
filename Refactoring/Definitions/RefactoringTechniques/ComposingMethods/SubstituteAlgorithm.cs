namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods;

/// <summary>
/// Problem: So you want to replace an existing algorithm with a new one? <para/>
/// Solution: Replace the body of the method that implements the algorithm with a new algorithm. <para/>
/// See also <a href="https://refactoring.guru/substitute-algorithm">substitute-algorithm</a>
/// </summary>
public class SubstituteAlgorithm : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Substitute Algorithm";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"So you want to replace an existing algorithm with a new one?" +
               $"{Environment.NewLine}" +
               $"string FoundPerson(string[] people)\n{{\n  for (int i = 0; i < people.Length; i++) \n  {{\n    if (people[i].Equals(\"Don\"))\n    {{\n      return \"Don\";\n    }}\n    if (people[i].Equals(\"John\"))\n    {{\n      return \"John\";\n    }}\n    if (people[i].Equals(\"Kent\"))\n    {{\n      return \"Kent\";\n    }}\n  }}\n  return String.Empty;\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Replace the body of the method that implements the algorithm with a new algorithm." +
               $"{Environment.NewLine}" +
               $"string FoundPerson(string[] people)\n{{\n  List<string> candidates = new List<string>() {{\"Don\", \"John\", \"Kent\"}};\n  \n  for (int i = 0; i < people.Length; i++) \n  {{\n    if (candidates.Contains(people[i])) \n    {{\n      return people[i];\n    }}\n  }}\n  \n  return String.Empty;\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return $"- Gradual refactoring isn’t the only method for improving a program. " +
               $"Sometimes a method is so cluttered with issues that it’s easier to tear down the method and start fresh. " +
               $"And perhaps you have found an algorithm that’s much simpler and more efficient. If this is the case, " +
               $"you should simply replace the old algorithm with the new one." +
               $"{Environment.NewLine}" +
               $"- As time goes on, your algorithm may be incorporated into a well-known library or framework and " +
               $"you want to get rid of your independent implementation, in order to simplify maintenance." +
               $"{Environment.NewLine}" +
               $"- The requirements for your program may change so heavily that your existing algorithm can’t be salvaged for the task.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Make sure that you have simplified the existing algorithm as much as possible. " +
               $"Move unimportant code to other methods using 'Extract Method'. The fewer moving parts in your algorithm, " +
               $"the easier it’s to replace." +
               $"{Environment.NewLine}" +
               $"2. Create your new algorithm in a new method. Replace the old algorithm with the new one and start testing the program." +
               $"{Environment.NewLine}" +
               $"3. If the results don’t match, return to the old implementation and compare the results. " +
               $"Identify the causes of the discrepancy. While the cause is often an error in the old algorithm, " +
               $"it’s more likely due to something not working in the new one." +
               $"{Environment.NewLine}" +
               $"4. When all tests are successfully completed, delete the old algorithm for good!";
    }
}