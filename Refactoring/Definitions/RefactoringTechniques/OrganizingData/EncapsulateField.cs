namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: You have a public field. <para/>
/// Solution: Make the field private and create access methods for it. <para/>
/// See also <a href="https://refactoring.guru/encapsulate-field">encapsulate-field</a>
/// </summary>
public class EncapsulateField : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Encapsulate Field";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have a public field." +
               $"{Environment.NewLine}" +
               $"class Person \n{{\n  public string name;\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Make the field private and create access methods for it." +
               $"{Environment.NewLine}" +
               $"class Person \n{{\n  private string name;\n\n  public string Name\n  {{\n    get {{ return name; }}\n    set {{ name = value; }}\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"One of the pillars of object-oriented programming is Encapsulation, the ability to conceal object data. " +
            $"Otherwise, all objects would be public and other objects could get and modify the data of your object " +
            $"without any checks and balances! Data is separated from the behaviors associated with this data, " +
            $"modularity of program sections is compromised, and maintenance becomes complicated.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- If the data and behavior of a component are closely interrelated and are in the same place in the code, " +
            $"it’s much easier for you to maintain and develop this component." +
            $"{Environment.NewLine}" +
            $"- You can also perform complicated operations related to access to object fields.";
    }

    /// <inheritdoc/>
    public string WhenNotToUse()
    {
        return $"In some cases, encapsulation is ill-advised due to performance considerations. " +
               $"These cases are rare but when they happen, this circumstance is very important." +
               $"{Environment.NewLine}" +
               $"Say that you have a graphical editor that contains objects possessing x- and y-coordinates. " +
               $"These fields are unlikely to change in the future. What’s more, " +
               $"the program involves a great many different objects in which these fields are present. " +
               $"So accessing the coordinate fields directly saves significant CPU cycles " +
               $"that would otherwise be taken up by calling access methods." +
               $"{Environment.NewLine}" +
               $"As an example of this unusual case, there’s the Point class in Java. All fields of this class are public.";
    }
    
    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a getter and setter for the field." +
               $"{Environment.NewLine}" +
               $"2. Find all invocations of the field. Replace receipt of the field value with the getter, " +
               $"and replace setting of new field values with the setter." +
               $"{Environment.NewLine}" +
               $"3. After all field invocations have been replaced, make the field private.";
    }

    /// <inheritdoc/>
    public string NextSteps()
    {
        return
            $"Encapsulate Field is only the first step in bringing data and the behaviors involving this data closer together. " +
            $"After you create simple methods for access fields, you should recheck the places where these methods are called. " +
            $"It’s quite possible that the code in these areas would look more appropriate in the access methods.";
    }
}