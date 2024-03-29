﻿namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Dispensables;

/// <summary>
/// A data class refers to a class that contains only fields and crude methods for accessing them (getters and setters).
/// These are simply containers for data used by other classes.
/// These classes don’t contain any additional functionality
/// and can’t independently operate on the data that they own.
/// See also <a href="https://refactoring.guru/smells/data-class">data-class</a>
/// </summary>
public class DataClass : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Data Class";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return
            $"A data class refers to a class that contains only fields and crude methods " +
            $"for accessing them (getters and setters). These are simply containers for data used by other classes." +
            $" These classes don’t contain any additional functionality and can’t independently operate " +
            $"on the data that they own.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"It’s a normal thing when a newly created class contains only a few public fields " +
            $"(and maybe even a handful of getters/setters). But the true power of objects is that " +
            $"they can contain behavior types or operations on their data.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return
            $"- If a class contains public fields, use Encapsulate Field to hide them from direct access " +
            $"and require that access be performed via getters and setters only." +
            $"{Environment.NewLine}" +
            $"- Use Encapsulate Collection for data stored in collections (such as arrays)." +
            $"{Environment.NewLine}" +
            $"- Review the client code that uses the class. In it, you may find functionality " +
            $"that would be better located in the data class itself. If this is the case, " +
            $"use Move Method and Extract Method to migrate this functionality to the data class." +
            $"{Environment.NewLine}" +
            $"- After the class has been filled with well thought-out methods, " +
            $"you may want to get rid of old methods for data access that give overly broad access to the class data. " +
            $"For this, Remove Setting Method and Hide Method may be helpful.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return
            $"- Improves understanding and organization of code. " +
            $"Operations on particular data are now gathered in a single place, " +
            $"instead of haphazardly throughout the code." +
            $"{Environment.NewLine}" +
            $"- Helps you to spot duplication of client code.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}