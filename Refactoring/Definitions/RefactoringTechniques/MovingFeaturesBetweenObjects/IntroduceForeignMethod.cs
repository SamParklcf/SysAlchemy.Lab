namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.MovingFeaturesBetweenObjects;

/// <summary>
/// Problem: A utility class does’t contain the method that you need and you can’t add the method to the class. <para/>
/// Solution: Add the method to a client class and pass an object of the utility class to it as an argument. <para/>
/// See also <a href="https://refactoring.guru/introduce-foreign-method">introduce-foreign-method</a>
/// </summary>
public class IntroduceForeignMethod : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Introduce Foreign Method";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"A utility class does’t contain the method that you need and you can’t add the method to the class." +
               $"{Environment.NewLine}" +
               $"class Report \n{{\n  // ...\n  void SendReport() \n  {{\n    DateTime nextDay = previousEnd.AddDays(1);\n    // ...\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Add the method to a client class and pass an object of the utility class to it as an argument." +
               $"{Environment.NewLine}" +
               $"class Report \n{{\n  // ...\n  void SendReport() \n  {{\n    DateTime nextDay = NextDay(previousEnd);\n    // ...\n  }}\n  private static DateTime NextDay(DateTime date) \n  {{\n    return date.AddDays(1);\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"You have code that uses the data and methods of a certain class. " +
            $"You realize that the code will look and work much better inside a new method in the class. " +
            $"But you can’t add the method to the class because, for example, the class is located in a third-party library." +
            $"{Environment.NewLine}" +
            $"This refactoring has a big payoff when the code that you want to move to the method is " +
            $"repeated several times in different places in your program." +
            $"{Environment.NewLine}" +
            $"Since you’re passing an object of the utility class to the parameters of the new method, " +
            $"you have access to all of its fields. Inside the method, you can do practically everything that you want, " +
            $"as if the method were part of the utility class.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"Removes code duplication. If your code is repeated in several places, " +
            $"you can replace these code fragments with a method call. This is better than duplication " +
            $"even considering that the foreign method is located in a suboptimal place.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"The reasons for having the method of a utility class in a client class won’t always be clear " +
            $"to the person maintaining the code after you. If the method can be used in other classes, " +
            $"you could benefit by creating a wrapper for the utility class and placing the method there. " +
            $"This is also beneficial when there are several such utility methods. " +
            $"'Introduce Local Extension' can help with this.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a new method in the client class." +
               $"{Environment.NewLine}" +
               $"2. In this method, create a parameter to which the object of the utility class will be passed. " +
               $"If this object can be obtained from the client class, you don’t have to create such a parameter." +
               $"{Environment.NewLine}" +
               $"3. Extract the relevant code fragments to this method and replace them with method calls." +
               $"{Environment.NewLine}" +
               $"4. Be sure to leave the Foreign method tag in the comments for the method along with the advice " +
               $"to place this method in a utility class if such becomes possible later. " +
               $"This will make it easier to understand why this method is located in this particular class " +
               $"for those who’ll be maintaining the software in the future.";
    }
}