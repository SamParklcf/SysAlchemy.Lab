namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingConditionalExpressions;

/// <summary>
/// Problem: For a portion of code to work correctly, certain conditions or values must be true. <para/>
/// Solution: Replace these assumptions with specific assertion checks. <para/>
/// See also <a href="https://refactoring.guru/introduce-assertion">introduce-assertion</a>
/// </summary>
public class IntroduceAssertion : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Introduce Assertion";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"For a portion of code to work correctly, certain conditions or values must be true." +
               $"{Environment.NewLine}" +
               $"double GetExpenseLimit() \n{{\n  // Should have either expense limit or\n  // a primary project.\n  return (expenseLimit != NULL_EXPENSE) ?\n    expenseLimit :\n    primaryProject.GetMemberExpenseLimit();\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Replace these assumptions with specific assertion checks." +
               $"{Environment.NewLine}" +
               $"double GetExpenseLimit() \n{{\n  Assert.IsTrue(expenseLimit != NULL_EXPENSE || primaryProject != null);\n\n  return (expenseLimit != NULL_EXPENSE) ?\n    expenseLimit:\n    primaryProject.GetMemberExpenseLimit();\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Say that a portion of code assumes something about, for example, " +
            $"the current condition of an object or value of a parameter or local variable. " +
            $"Usually this assumption will always hold true except in the event of an error." +
            $"{Environment.NewLine}" +
            $"Make these assumptions obvious by adding corresponding assertions. " +
            $"As with type hinting in method parameters, these assertions can act as live documentation for your code." +
            $"{Environment.NewLine}" +
            $"As a guideline to see where your code needs assertions, " +
            $"check for comments that describe the conditions under which a particular method will work.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"If an assumption isn’t true and the code therefore gives the wrong result, " +
            $"it’s better to stop execution before this causes fatal consequences and data corruption. " +
            $"This also means that you neglected to write a necessary test when devising ways to perform testing of the program.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"- Sometimes an exception is more appropriate than a simple assertion. " +
            $"You can select the necessary class of the exception and let the remaining code handle it correctly." +
            $"{Environment.NewLine}" +
            $"- When is an exception better than a simple assertion? " +
            $"If the exception can be caused by actions of the user or system and you can handle the exception. " +
            $"On the other hand, ordinary unnamed and unhandled exceptions are basically equivalent " +
            $"to simple assertions—you don’t handle them and they’re caused exclusively " +
            $"as the result of a program bug that never should have occurred.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"When you see that a condition is assumed, add an assertion for this condition in order to make sure." +
               $"{Environment.NewLine}" +
               $"Adding the assertion shouldn’t change the program’s behavior." +
               $"{Environment.NewLine}" +
               $"Don’t overdo it with use of assertions for everything in your code. " +
               $"Check for only the conditions that are necessary for correct functioning of the code. " +
               $"If your code is working normally even when a particular assertion is false, " +
               $"you can safely remove the assertion.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}