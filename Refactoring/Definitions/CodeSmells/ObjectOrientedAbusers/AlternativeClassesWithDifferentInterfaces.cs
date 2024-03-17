namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.ObjectOrientedAbusers;

/// <summary>
/// Two classes perform identical functions but have different method names.
/// See also <a href="https://refactoring.guru/smells/alternative-classes-with-different-interfaces">alternative-classes-with-different-interfaces</a>
/// </summary>
public class AlternativeClassesWithDifferentInterfaces: ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Alternative Classes with Different Interfaces";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"Two classes perform identical functions but have different method names.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"The programmer who created one of the classes probably did’t know that " +
            $"a functionally equivalent class already existed.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return $"Try to put the interface of classes in terms of a common denominator:" +
               $"{Environment.NewLine}" +
               $"- Rename Methods to make them identical in all alternative classes." +
               $"{Environment.NewLine}" +
               $"- Move Method, Add Parameter and Parameterize Method to make the signature " +
               $"and implementation of methods the same." +
               $"{Environment.NewLine}" +
               $"- If only part of the functionality of the classes is duplicated, " +
               $"try using Extract Superclass. In this case, the existing classes will become subclasses." +
               $"{Environment.NewLine}" +
               $"- After you have determined which treatment method to use and implemented it, " +
               $"you may be able to delete one of the classes.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- You get rid of unnecessary duplicated code, making the resulting code less bulky." +
               $"{Environment.NewLine}" +
               $"- Code becomes more readable and understandable " +
               $"(you no longer have to guess the reason for creation of a second class performing " +
               $"the exact same functions as the first one).";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return
            $"Sometimes merging classes is impossible or so difficult as to be pointless. " +
            $"One example is when the alternative classes are in different libraries " +
            $"that each have their own version of the class.";
    }
}