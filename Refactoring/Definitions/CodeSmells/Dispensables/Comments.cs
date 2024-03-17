namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Dispensables;

/// <summary>
/// A method is filled with explanatory comments.
/// See also <a href="https://refactoring.guru/smells/comments">comments</a>
/// </summary>
public class Comments : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Comments";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"A method is filled with explanatory comments.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"Comments are usually created with the best of intentions, " +
            $"when the author realizes that his or her code isn’t intuitive or obvious. " +
            $"In such cases, comments are like a deodorant masking the smell of fishy code that could be improved." +
            $"{Environment.NewLine}" +
            $"The best comment is a good name for a method or class." +
            $"{Environment.NewLine}" +
            $"If you feel that a code fragment can’t be understood without comments, " +
            $"try to change the code structure in a way that makes comments unnecessary.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return
            $"- If a comment is intended to explain a complex expression, " +
            $"the expression should be split into understandable subexpressions using Extract Variable." +
            $"{Environment.NewLine}" +
            $"- If a comment explains a section of code, this section can be turned into a separate method via Extract Method. " +
            $"The name of the new method can be taken from the comment text itself, most likely." +
            $"{Environment.NewLine}" +
            $"- If a method has already been extracted, but comments are still necessary to explain what the method does, " +
            $"give the method a self-explanatory name. Use Rename Method for this." +
            $"{Environment.NewLine}" +
            $"- If you need to assert rules about a state that’s necessary for the system to work, " +
            $"use Introduce Assertion.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"Code becomes more intuitive and obvious.";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return $"Comments can sometimes be useful:" +
               $"{Environment.NewLine}" +
               $"- When explaining why something is being implemented in a particular way." +
               $"{Environment.NewLine}" +
               $"- When explaining complex algorithms (when all other methods for simplifying " +
               $"the algorithm have been tried and come up short).";
    }
}