namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: You use direct access to private fields inside a class. <para/>
/// Solution: Create a getter and setter for the field, and use only them for accessing the field. <para/>
/// See also <a href="https://refactoring.guru/self-encapsulate-field">self-encapsulate-field</a>
/// </summary>
public class SelfEncapsulateField : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Self Encapsulate Field";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You use direct access to private fields inside a class." +
               $"{Environment.NewLine}" +
               $"class Range \n{{\n  private int low, high;\n  \n  bool Includes(int arg) \n  {{\n    return arg >= low && arg <= high;\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Create a getter and setter for the field, and use only them for accessing the field." +
               $"{Environment.NewLine}" +
               $"class Range \n{{\n  private int low, high;\n  \n  int Low {{\n    get {{ return low; }}\n  }}\n  int High {{\n    get {{ return high; }}\n  }}\n  \n  bool Includes(int arg) \n  {{\n    return arg >= Low && arg <= High;\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Sometimes directly accessing a private field inside a class just isn’t flexible enough. " +
            $"You want to be able to initiate a field value when the first query is made or perform certain operations " +
            $"on new values of the field when they’re assigned, or maybe do all this in various ways in subclasses.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"1. Indirect access to fields is when a field is acted on via access methods (getters and setters). " +
            $"This approach is much more flexible than direct access to fields." +
            $"{Environment.NewLine}" +
            $"- First, you can perform complex operations when data in the field is set or received. " +
            $"Lazy initialization and validation of field values are easily implemented inside field getters and setters." +
            $"{Environment.NewLine}" +
            $"- Second and more crucially, you can redefine getters and setters in subclasses." +
            $"{Environment.NewLine}" +
            $"2. You have the option of not implementing a setter for a field at all. " +
            $"The field value will be specified only in the constructor, " +
            $"thus making the field unchangeable throughout the entire object lifespan.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"When direct access to fields is used, code looks simpler and more presentable, " +
            $"although flexibility is diminished.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a getter (and optional setter) for the field. They should be either protected or public." +
               $"{Environment.NewLine}" +
               $"2. Find all direct invocations of the field and replace them with getter and setter calls.";
    }
}