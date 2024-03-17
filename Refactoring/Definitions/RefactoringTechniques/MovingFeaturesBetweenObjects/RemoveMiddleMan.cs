namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.MovingFeaturesBetweenObjects;

/// <summary>
/// Problem: A class has too many methods that simply delegate to other objects. <para/>
/// Solution:  <para/>
/// See also <a href="https://refactoring.guru/remove-middle-man">remove-middle-man</a>
/// </summary>
public class RemoveMiddleMan : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Remove Middle Man";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"A class has too many methods that simply delegate to other objects.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Delete these methods and force the client to call the end methods directly.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return $"To describe this technique, we’ll use the terms from Hide Delegate, which are:" +
               $"{Environment.NewLine}" +
               $"- Server is the object to which the client has direct access." +
               $"{Environment.NewLine}" +
               $"- Delegate is the end object that contains the functionality needed by the client." +
               $"{Environment.NewLine}" +
               $"There are two types of problems:" +
               $"{Environment.NewLine}" +
               $"1. The server-class does’t do anything itself and simply creates needless complexity. " +
               $"In this case, give thought to whether this class is needed at all." +
               $"{Environment.NewLine}" +
               $"2. Every time a new feature is added to the delegate, " +
               $"you need to create a delegating method for it in the server-class. If a lot of changes are made, " +
               $"this will be rather tiresome.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a getter for accessing the delegate-class object from the server-class object." +
               $"{Environment.NewLine}" +
               $"2. Replace calls to delegating methods in the server-class with direct calls for methods in the delegate-class.";
    }
}