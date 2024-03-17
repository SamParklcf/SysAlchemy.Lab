namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingConditionalExpressions;

/// <summary>
/// Problem: Since some methods return null instead of real objects, you have many checks for null in your code. <para/>
/// Solution: Instead of null, return a null object that exhibits the default behavior. <para/>
/// See also <a href="https://refactoring.guru/introduce-null-object">introduce-null-object</a>
/// </summary>
public class IntroduceNullObject : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Introduce Null Object";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"Since some methods return null instead of real objects, you have many checks for null in your code." +
               $"{Environment.NewLine}" +
               $"if (customer == null) \n{{\n  plan = BillingPlan.Basic();\n}}\nelse \n{{\n  plan = customer.GetPlan();\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Instead of null, return a null object that exhibits the default behavior." +
               $"{Environment.NewLine}" +
               $"public sealed class NullCustomer: Customer \n{{\n  public override bool IsNull \n  {{\n    get {{ return true; }}\n  }}\n  \n  public override Plan GetPlan() \n  {{\n    return new NullPlan();\n  }}\n  // Some other NULL functionality.\n}}\n\n// Replace null values with Null-object.\ncustomer = order.customer ?? new NullCustomer();\n\n// Use Null-object as if it's normal subclass.\nplan = customer.GetPlan();";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return $"Dozens of checks for null make your code longer and uglier.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return $"The price of getting rid of conditionals is creating yet another new class.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. From the class in question, create a subclass that will perform the role of null object." +
               $"{Environment.NewLine}" +
               $"2. In both classes, create the method isNull(), which will return true for a null object " +
               $"and false for a real class." +
               $"{Environment.NewLine}" +
               $"3. Find all places where the code may return null instead of a real object. " +
               $"Change the code so that it returns a null object." +
               $"{Environment.NewLine}" +
               $"4. Find all places where the variables of the real class are compared with null. " +
               $"Replace these checks with a call for isNull()." +
               $"{Environment.NewLine}" +
               $"5. If methods of the original class are run in these conditionals when a value does’t equal null, " +
               $"redefine these methods in the null class and insert the code from the else part of the condition there. " +
               $"Then you can delete the entire conditional and differing behavior will be implemented via polymorphism." +
               $"{Environment.NewLine}" +
               $"If things aren’t so simple and the methods can’t be redefined, " +
               $"see if you can simply extract the operators that were supposed to be performed " +
               $"in the case of a null value to new methods of the null object. " +
               $"Call these methods instead of the old code in else as the operations by default.";
    }
}