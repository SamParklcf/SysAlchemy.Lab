namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.MovingFeaturesBetweenObjects;

/// <summary>
/// Problem: The client gets object B from a field or method of object А. Then the client calls a method of object B. <para/>
/// Solution: Create a new method in class A that delegates the call to object B. Now the client doesn’t know about, or depend on, class B. <para/>
/// See also <a href="https://refactoring.guru/hide-delegate">hide-delegate</a>
/// </summary>
public class HideDelegate : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Hide Delegate";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"The client gets object B from a field or method of object А. Then the client calls a method of object B.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Create a new method in class A that delegates the call to object B. Now the client does’t know about, or depend on, class B.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return $"To start with, let’s look at terminology:" +
               $"{Environment.NewLine}" +
               $"- Server is the object to which the client has direct access." +
               $"{Environment.NewLine}" +
               $"- Delegate is the end object that contains the functionality needed by the client." +
               $"{Environment.NewLine}" +
               $"A call chain appears when a client requests an object from another object, " +
               $"then the second object requests another one, and so on. These sequences of calls involve the client " +
               $"in navigation along the class structure. Any changes in these interrelationships will require changes on the client side.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"Hides delegation from the client. The less that the client code needs to know " +
            $"about the details of relationships between objects, the easier it’s to make changes to your program.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"If you need to create an excessive number of delegating methods, " +
            $"server-class risks becoming an unneeded go-between, leading to an excess of 'Middle Man'.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. For each method of the delegate-class called by the client, create a method in the server-class that delegates the call to the delegate-class." +
            $"{Environment.NewLine}" +
            $"2. Change the client code so that it calls the methods of the server-class." +
            $"{Environment.NewLine}" +
            $"3. If your changes free the client from needing the delegate-class, " +
            $"you can remove the access method to the delegate-class from the server-class " +
            $"(the method that was originally used to get the delegate-class).";
    }
}