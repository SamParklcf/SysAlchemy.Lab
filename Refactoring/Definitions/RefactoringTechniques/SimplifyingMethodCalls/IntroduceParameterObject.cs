﻿namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: Your methods contain a repeating group of parameters. <para/>
/// Solution: Replace these parameters with an object. <para/>
/// See also <a href="https://refactoring.guru/introduce-parameter-object">introduce-parameter-object</a>
/// </summary>
public class IntroduceParameterObject : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Introduce Parameter Object";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Your methods contain a repeating group of parameters.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Replace these parameters with an object.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Identical groups of parameters are often encountered in multiple methods. " +
            $"This causes code duplication of both the parameters themselves and of related operations. " +
            $"By consolidating parameters in a single class, you can also move the methods for handling this data there as well, " +
            $"freeing the other methods from this code.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- More readable code. Instead of a hodgepodge of parameters, you see a single object with a comprehensible name." +
            $"{Environment.NewLine}" +
            $"- Identical groups of parameters scattered here and there create their own kind of code duplication: " +
            $"while identical code isn’t being called, identical groups of parameters and arguments are constantly encountered.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"If you move only data to a new class and don’t plan to move any behaviors or related operations there, " +
            $"this begins to smell of a Data Class.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a new class that will represent your group of parameters. Make the class immutable." +
               $"{Environment.NewLine}" +
               $"2. In the method that you want to refactor, use Add Parameter, " +
               $"which is where your parameter object will be passed. " +
               $"In all method calls, pass the object created from old method parameters to this parameter." +
               $"{Environment.NewLine}" +
               $"3. Now start deleting old parameters from the method one by one, " +
               $"replacing them in the code with fields of the parameter object. " +
               $"Test the program after each parameter replacement." +
               $"{Environment.NewLine}" +
               $"4. When done, see whether there’s any point in moving a part of the method " +
               $"(or sometimes even the whole method) to a parameter object class. If so, use Move Method or Extract Method.";
    }
}