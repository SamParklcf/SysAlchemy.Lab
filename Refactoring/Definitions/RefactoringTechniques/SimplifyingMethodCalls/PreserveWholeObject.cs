﻿namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: You get several values from an object and then pass them as parameters to a method. <para/>
/// Solution: Instead, try passing the whole object. <para/>
/// See also <a href="https://refactoring.guru/preserve-whole-object">preserve-whole-object</a>
/// </summary>
public class PreserveWholeObject : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Preserve Whole Object";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You get several values from an object and then pass them as parameters to a method." +
               $"{Environment.NewLine}" +
               $"int low = daysTempRange.GetLow();\nint high = daysTempRange.GetHigh();\nbool withinPlan = plan.WithinRange(low, high);";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Instead, try passing the whole object." +
               $"{Environment.NewLine}" +
               $"bool withinPlan = plan.WithinRange(daysTempRange);";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"The problem is that each time before your method is called, the methods of the future parameter object " +
            $"must be called. If these methods or the quantity of data obtained for the method are changed, " +
            $"you will need to carefully find a dozen such places in the program and implement these changes in each of them." +
            $"{Environment.NewLine}" +
            $"After you apply this refactoring technique, the code for getting all necessary data " +
            $"will be stored in one place—the method itself.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"- Instead of a hodgepodge of parameters, you see a single object with a comprehensible name." +
               $"{Environment.NewLine}" +
               $"- If the method needs more data from an object, you won’t need to rewrite all the places " +
               $"where the method is used—merely inside the method itself.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"Sometimes this transformation causes a method to become less flexible: " +
            $"previously the method could get data from many different sources but now, " +
            $"because of refactoring, we’re limiting its use to only objects with a particular interface.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a parameter in the method for the object from which you can get the necessary values." +
               $"{Environment.NewLine}" +
               $"2. Now start removing the old parameters from the method one by one, " +
               $"replacing them with calls to the relevant methods of the parameter object. " +
               $"Test the program after each replacement of a parameter." +
               $"{Environment.NewLine}" +
               $"3. Delete the getter code from the parameter object that had preceded the method call.";
    }
}