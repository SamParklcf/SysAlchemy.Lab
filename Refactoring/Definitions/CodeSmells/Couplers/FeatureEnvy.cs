namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Couplers;

/// <summary>
/// A method accesses the data of another object more than its own data.
/// See also <a href="https://refactoring.guru/smells/feature-envy">feature-envy</a>
/// </summary>
public class FeatureEnvy : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Feature Envy";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"A method accesses the data of another object more than its own data.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"This smell may occur after fields are moved to a data class. " +
            $"If this is the case, you may want to move the operations on data to this class as well.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return
            $"As a basic rule, if things change at the same time, you should keep them in the same place. " +
            $"Usually data and functions that use this data are changed together (although exceptions are possible)." +
            $"{Environment.NewLine}" +
            $"- If a method clearly should be moved to another place, use Move Method." +
            $"{Environment.NewLine}" +
            $"- If only part of a method accesses the data of another object, " +
            $"use Extract Method to move the part in question." +
            $"{Environment.NewLine}" +
            $"- If a method uses functions from several other classes, " +
            $"first determine which class contains most of the data used. " +
            $"Then place the method in this class along with the other data. " +
            $"Alternatively, use Extract Method to split the method into several parts that can be placed " +
            $"in different places in different classes.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- Less code duplication (if the data handling code is put in a central place)." +
               $"{Environment.NewLine}" +
               $"- Better code organization (methods for handling data are next to the actual data).";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return
            $"Sometimes behavior is purposefully kept separate from the class that holds the data. " +
            $"The usual advantage of this is the ability to dynamically change the behavior " +
            $"(see Strategy, Visitor and other patterns).";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}