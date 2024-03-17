namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.DealingWithGeneralization;

/// <summary>
/// Problem: Your subclasses have constructors with code that’s mostly identical. <para/>
/// Solution: Create a superclass constructor and move the code that’s the same in the subclasses to it.
/// Call the superclass constructor in the subclass constructors. <para/>
/// See also <a href="https://refactoring.guru/pull-up-constructor-body">pull-up-constructor-body</a>
/// </summary>
public class PullUpConstructorBody : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Pull Up Constructor Body";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Your subclasses have constructors with code that’s mostly identical." +
               $"{Environment.NewLine}" +
               $"public class Manager: Employee \n{{\n  public Manager(string name, string id, int grade) \n  {{\n    this.name = name;\n    this.id = id;\n    this.grade = grade;\n  }}\n  // ...\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Create a superclass constructor and move the code that’s the same in the subclasses to it. " +
            $"Call the superclass constructor in the subclass constructors." +
            $"{Environment.NewLine}" +
            $"public class Manager: Employee \n{{\n  public Manager(string name, string id, int grade): base(name, id)\n  {{\n    this.grade = grade;\n  }}\n  // ...\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return $"How is this refactoring technique different from Pull Up Method?" +
               $"{Environment.NewLine}" +
               $"1. In Java, subclasses can’t inherit a constructor, " +
               $"so you can’t simply apply Pull Up Method to the subclass constructor and delete it " +
               $"after removing all the constructor code to the superclass. In addition to creating a constructor " +
               $"in the superclass it’s necessary to have constructors in the subclasses " +
               $"with simple delegation to the superclass constructor." +
               $"{Environment.NewLine}" +
               $"2. In C++ and Java (if you did’t explicitly call the superclass constructor) " +
               $"the superclass constructor is automatically called prior to the subclass constructor, " +
               $"which makes it necessary to move the common code only from the beginning of the subclass constructors " +
               $"(since you won’t be able to call the superclass constructor from an arbitrary place in a subclass constructor)." +
               $"{Environment.NewLine}" +
               $"3. In most programming languages, a subclass constructor can have its own list of parameters " +
               $"different from the parameters of the superclass. Therefore you should create a superclass constructor " +
               $"only with the parameters that it truly needs.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a constructor in a superclass." +
               $"{Environment.NewLine}" +
               $"2. Extract the common code from the beginning of the constructor of each subclass " +
               $"to the superclass constructor. Before doing so, try to move as much common code as possible " +
               $"to the beginning of the constructor." +
               $"{Environment.NewLine}" +
               $"3. Place the call for the superclass constructor in the first line in the subclass constructors.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}