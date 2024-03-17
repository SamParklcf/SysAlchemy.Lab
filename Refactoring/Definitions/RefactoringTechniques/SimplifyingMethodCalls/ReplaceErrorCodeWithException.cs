namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: A method returns a special value that indicates an error? <para/>
/// Solution: Throw an exception instead. <para/>
/// See also <a href="https://refactoring.guru/replace-error-code-with-exception">replace-error-code-with-exception</a>
/// </summary>
public class ReplaceErrorCodeWithException : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Error Code with Exception";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"A method returns a special value that indicates an error?" +
               $"{Environment.NewLine}" +
               $"int Withdraw(int amount) \n{{\n  if (amount > _balance) \n  {{\n    return -1;\n  }}\n  else \n  {{\n    balance -= amount;\n    return 0;\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Throw an exception instead." +
               $"{Environment.NewLine}" +
               $"///<exception cref=\"BalanceException\">Thrown when amount > _balance</exception>\nvoid Withdraw(int amount)\n{{\n  if (amount > _balance) \n  {{\n    throw new BalanceException();\n  }}\n  balance -= amount;\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Returning error codes is an obsolete holdover from procedural programming. " +
            $"In modern programming, error handling is performed by special classes, which are named exceptions. " +
            $"If a problem occurs, you “throw” an error, which is then “caught” by one of the exception handlers. " +
            $"Special error-handling code, which is ignored in normal conditions, is activated to respond.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- Frees code from a large number of conditionals for checking various error codes. " +
            $"Exception handlers are a much more succinct way to differentiate normal execution paths from abnormal ones." +
            $"{Environment.NewLine}" +
            $"- Exception classes can implement their own methods, " +
            $"thus containing part of the error handling functionality (such as for sending error messages)." +
            $"{Environment.NewLine}" +
            $"- Unlike exceptions, error codes can’t be used in a constructor, since a constructor must return only a new object.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"An exception handler can turn into a goto-like crutch. Avoid this! Don’t use exceptions to manage code execution. " +
            $"Exceptions should be thrown only to inform of an error or critical situation.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"Try to perform these refactoring steps for only one error code at a time. " +
            $"This will make it easier to keep all the important information in your head and avoid errors." +
            $"{Environment.NewLine}" +
            $"1. Find all calls to a method that returns error codes and, instead of checking for an error code, " +
            $"wrap it in try/catch blocks." +
            $"{Environment.NewLine}" +
            $"2. Inside the method, instead of returning an error code, throw an exception." +
            $"{Environment.NewLine}" +
            $"3. Change the method signature so that it contains information about the exception being thrown (@throws section).";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}