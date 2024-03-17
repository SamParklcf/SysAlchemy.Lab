namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Bloaters;

/// <summary>
/// A class contains many fields/methods/lines of code.
/// See also <a href="https://refactoring.guru/smells/large-class">large-class</a>
/// </summary>
public class LargeClass : ICodeSmellsInstruction
{
    /// <inheritdoc />
    public string Name()
    {
        return $"Large Class";
    }

    /// <inheritdoc />
    public string SignsAndSymptoms()
    {
        return $"A class contains many fields/methods/lines of code.";
    }

    /// <inheritdoc />
    public string ReasonsForTheProblem()
    {
        return $"Classes usually start small. But over time, they get bloated as the program grows." +
               $"{Environment.NewLine}" +
               $"As is the case with long methods as well, programmers usually find it mentally less taxing " +
               $"to place a new feature in an existing class than to create a new class for the feature.";
    }

    /// <inheritdoc />
    public string Treatment()
    {
        return $"When a class is wearing too many (functional) hats, think about splitting it up:" +
               $"{Environment.NewLine}" +
               $"- Extract Class helps if part of the behavior of the large class can be spun off into a separate component." +
               $"{Environment.NewLine}" +
               $"- Extract Subclass helps if part of the behavior of the large class can be implemented " +
               $"in different ways or is used in rare cases." +
               $"{Environment.NewLine}" +
               $"- Extract Interface helps if it’s necessary to have a list of the operations and behaviors " +
               $"that the client can use." +
               $"{Environment.NewLine}" +
               $"- If a large class is responsible for the graphical interface, you may try to move some of " +
               $"its data and behavior to a separate domain object. In doing so, it may be necessary " +
               $"to store copies of some data in two places and keep the data consistent. " +
               $"Duplicate Observed Data offers a way to do this.";
    }

    /// <inheritdoc />
    public string Payoff()
    {
        return
            $"- Refactoring of these classes spares developers from needing to remember " +
            $"a large number of attributes for a class." +
            $"{Environment.NewLine}" +
            $"- In many cases, splitting large classes into parts avoids duplication of code and functionality.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}