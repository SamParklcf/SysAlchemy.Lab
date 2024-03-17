namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: You have a complex constructor that does something more than just setting parameter values in object fields. <para/>
/// Solution: Create a factory method and use it to replace constructor calls. <para/>
/// See also <a href="https://refactoring.guru/replace-constructor-with-factory-method">replace-constructor-with-factory-method</a>
/// </summary>
public class ReplaceConstructorWithFactoryMethod : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Constructor with Factory Method";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"You have a complex constructor that does something more than just setting parameter values in object fields." +
            $"{Environment.NewLine}" +
            $"public class Employee \n{{\n  public Employee(int type) \n  {{\n    this.type = type;\n  }}\n  // ...\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Create a factory method and use it to replace constructor calls." +
               $"{Environment.NewLine}" +
               $"public class Employee\n{{\n  public static Employee Create(int type)\n  {{\n    employee = new Employee(type);\n    // Do some heavy lifting.\n    return employee;\n  }}\n  // ...\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"The most obvious reason for using this refactoring technique is related to Replace Type Code with Subclasses." +
            $"{Environment.NewLine}" +
            $"You have code in which a object was previously created and the value of the coded type was passed to it. " +
            $"After use of the refactoring method, several subclasses have appeared and from them you need " +
            $"to create objects depending on the value of the coded type. " +
            $"Changing the original constructor to make it return subclass objects is impossible, " +
            $"so instead we create a static factory method that will return objects of the necessary classes, " +
            $"after which it replaces all calls to the original constructor." +
            $"{Environment.NewLine}" +
            $"Factory methods can be used in other situations as well, when constructors aren’t up to the task. " +
            $"They can be important when attempting to Change Value to Reference. " +
            $"They can also be used to set various creation modes that go beyond the number and types of parameters.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- A factory method does’t necessarily return an object of the class in which it was called. " +
            $"Often these could be its subclasses, selected based on the arguments given to the method." +
            $"{Environment.NewLine}" +
            $"- A factory method can have a better name that describes what and how it returns what it does, " +
            $"for example Troops::GetCrew(myTank)." +
            $"{Environment.NewLine}" +
            $"- A factory method can return an already created object, unlike a constructor, " +
            $"which always creates a new instance.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a factory method. Place a call to the current constructor in it." +
               $"{Environment.NewLine}" +
               $"2. Replace all constructor calls with calls to the factory method." +
               $"{Environment.NewLine}" +
               $"3. Declare the constructor private." +
               $"{Environment.NewLine}" +
               $"4. Investigate the constructor code and try to isolate the code not directly related " +
               $"to constructing an object of the current class, moving such code to the factory method.";
    }
}