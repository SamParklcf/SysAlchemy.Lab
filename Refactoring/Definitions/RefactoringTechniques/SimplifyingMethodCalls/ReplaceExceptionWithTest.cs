namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: You throw an exception in a place where a simple test would do the job? <para/>
/// Solution: Replace the exception with a condition test. <para/>
/// See also <a href="https://refactoring.guru/replace-exception-with-test">replace-exception-with-test</a>
/// </summary>
public class ReplaceExceptionWithTest : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Exception with Test";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You throw an exception in a place where a simple test would do the job?" +
               $"{Environment.NewLine}" +
               $"double GetValueForPeriod(int periodNumber) \n{{\n  try \n  {{\n    return values[periodNumber];\n  }} \n  catch (IndexOutOfRangeException e) \n  {{\n    return 0;\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Replace the exception with a condition test." +
               $"{Environment.NewLine}" +
               $"double GetValueForPeriod(int periodNumber) \n{{\n  if (periodNumber >= values.Length) \n  {{\n    return 0;\n  }}\n  return values[periodNumber];\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Exceptions should be used to handle irregular behavior related to an unexpected error. " +
            $"They shouldn’t serve as a replacement for testing. " +
            $"If an exception can be avoided by simply verifying a condition before running, then do so. " +
            $"Exceptions should be reserved for real errors." +
            $"{Environment.NewLine}" +
            $"For instance, you entered a minefield and triggered a mine there, resulting in an exception; " +
            $"the exception was successfully handled and you were lifted through the air to safety beyond the mine field. " +
            $"But you could have avoided this all by simply reading the warning sign in front of the minefield to begin with.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"A simple conditional can sometimes be more obvious than exception handling code.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a conditional for an edge case and move it before the try/catch block." +
               $"{Environment.NewLine}" +
               $"2. Move code from the catch section inside this conditional." +
               $"{Environment.NewLine}" +
               $"3. In the catch section, place the code for throwing a usual unnamed exception and run all the tests." +
               $"{Environment.NewLine}" +
               $"4. If no exceptions were thrown during the tests, get rid of the try/catch operator.";
    }
}