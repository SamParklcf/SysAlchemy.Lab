namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.ObjectOrientedAbusers;

/// <summary>
/// You have a complex switch operator or sequence of if statements.
/// See also <a href="https://refactoring.guru/smells/switch-statements">switch-statements</a>
/// </summary>
public class SwitchStatements : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Switch Statements";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"You have a complex switch operator or sequence of if statements.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"Relatively rare use of switch and case operators is one of the hallmarks of object-oriented code. " +
            $"Often code for a single switch can be scattered in different places in the program. " +
            $"When a new condition is added, you have to find all the switch code and modify it." +
            $"{Environment.NewLine}" +
            $"As a rule of thumb, when you see switch you should think of polymorphism.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return $"- To isolate switch and put it in the right class, you may need Extract Method and then Move Method." +
               $"{Environment.NewLine}" +
               $"- If a switch is based on type code, such as when the program’s runtime mode is switched, " +
               $"use Replace Type Code with Subclasses or Replace Type Code with State/Strategy." +
               $"{Environment.NewLine}" +
               $"- After specifying the inheritance structure, use Replace Conditional with Polymorphism." +
               $"{Environment.NewLine}" +
               $"- If there aren’t too many conditions in the operator and they all call same method " +
               $"with different parameters, polymorphism will be superfluous. If this case, " +
               $"you can break that method into multiple smaller methods with Replace Parameter " +
               $"with Explicit Methods and change the switch accordingly." +
               $"{Environment.NewLine}" +
               $"- If one of the conditional options is null, use Introduce Null Object.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"Improved code organization.";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return $"- When a switch operator performs simple actions, there’s no reason to make code changes." +
               $"{Environment.NewLine}" +
               $"- Often switch operators are used by factory design patterns " +
               $"(Factory Method or Abstract Factory) to select a created class.";
    }
}