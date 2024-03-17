namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Bloaters;

/// <summary>
/// Sometimes different parts of the code contain identical groups of variables (such as parameters for connecting to a database). These clumps should be turned into their own classes.
/// See also <a href="https://refactoring.guru/smells/data-clumps">data-clumps</a>
/// </summary>
public class DataClumps : ICodeSmellsInstruction
{
    /// <inheritdoc />
    public string Name()
    {
        return $"Data Clumps";
    }

    /// <inheritdoc />
    public string SignsAndSymptoms()
    {
        return
            $"Sometimes different parts of the code contain identical groups of variables " +
            $"(such as parameters for connecting to a database). These clumps should be turned into their own classes.";
    }

    /// <inheritdoc />
    public string ReasonsForTheProblem()
    {
        return $"Often these data groups are due to poor program structure or \"copy-pasta programming”." +
               $"{Environment.NewLine}" +
               $"If you want to make sure whether or not some data is a data clump, " +
               $"just delete one of the data values and see whether the other values still make sense. " +
               $"If this isn’t the case, this is a good sign that this group of variables should be combined into an object.";
    }

    /// <inheritdoc />
    public string Treatment()
    {
        return
            $"- If repeating data comprises the fields of a class, use Extract Class to move the fields to their own class." +
            $"{Environment.NewLine}" +
            $"- If the same data clumps are passed in the parameters of methods, " +
            $"use Introduce Parameter Object to set them off as a class." +
            $"{Environment.NewLine}" +
            $"- If some of the data is passed to other methods, think about passing " +
            $"the entire data object to the method instead of just individual fields. " +
            $"Preserve Whole Object will help with this." +
            $"{Environment.NewLine}" +
            $"- Look at the code used by these fields. It may be a good idea to move this code to a data class.";
    }

    /// <inheritdoc />
    public string Payoff()
    {
        return
            $"- Improves understanding and organization of code. Operations on particular data are now gathered " +
            $"in a single place, instead of haphazardly throughout the code." +
            $"{Environment.NewLine}" +
            $"- Reduces code size.";
    }

    /// <inheritdoc />
    public string WhenToIgnore()
    {
        return
            $"Passing an entire object in the parameters of a method, instead of passing just " +
            $"its values (primitive types), may create an undesirable dependency between the two classes.";
    }
}