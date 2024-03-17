namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods;

/// <summary>
/// Problem: You have a long method in which the local variables are so intertwined that you can’t apply Extract Method. <para/>
/// Solution: Transform the method into a separate class so that the local variables become fields of the class. Then you can split the method into several methods within the same class. <para/>
/// See also <a href="https://refactoring.guru/replace-method-with-method-object">replace-method-with-method-object</a>
/// </summary>
public class ReplaceMethodWithMethodObject : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Method with Method Object";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"You have a long method in which the local variables are so intertwined that you can’t apply Extract Method." +
            $"{Environment.NewLine}" +
            $"public class Order \n{{\n  // ...\n  public double Price() \n  {{\n    double primaryBasePrice;\n    double secondaryBasePrice;\n    double tertiaryBasePrice;\n    // Perform long computation.\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Transform the method into a separate class so that the local variables become fields of the class. " +
               $"Then you can split the method into several methods within the same class." +
               $"{Environment.NewLine}" +
               $"public class Order \n{{\n  // ...\n  public double Price() \n  {{\n    return new PriceCalculator(this).Compute();\n  }}\n}}\n\npublic class PriceCalculator \n{{\n  private double primaryBasePrice;\n  private double secondaryBasePrice;\n  private double tertiaryBasePrice;\n  \n  public PriceCalculator(Order order) \n  {{\n    // Copy relevant information from the\n    // order object.\n  }}\n  \n  public double Compute() \n  {{\n    // Perform long computation.\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"A method is too long and you can’t separate it due to tangled masses of local variables that are hard to isolate from each other." +
            $"{Environment.NewLine}" +
            $"The first step is to isolate the entire method into a separate class and turn its local variables into fields of the class." +
            $"{Environment.NewLine}" +
            $"Firstly, this allows isolating the problem at the class level. Secondly, " +
            $"it paves the way for splitting a large and unwieldy method into smaller ones that would’t fit with the purpose of the original class anyway.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"Isolating a long method in its own class allows stopping a method from ballooning in size. " +
               $"This also allows splitting it into sub-methods within the class, without polluting the original class with utility methods.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return $"Another class is added, increasing the overall complexity of the program.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a new class. Name it based on the purpose of the method that you’re refactoring." +
               $"{Environment.NewLine}" +
               $"2. In the new class, create a private field for storing a reference to an instance of the class " +
               $"in which the method was previously located. It could be used to get some required data " +
               $"from the original class if needed." +
               $"{Environment.NewLine}" +
               $"3. Create a separate private field for each local variable of the method." +
               $"{Environment.NewLine}" +
               $"4. Create a constructor that accepts as parameters the values of all local variables of the method and also initializes the corresponding private fields." +
               $"{Environment.NewLine}" +
               $"5. Declare the main method and copy the code of the original method to it, replacing the local variables with private fields." +
               $"{Environment.NewLine}" +
               $"6. Replace the body of the original method in the original class by creating a method object and calling its main method.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"1. Isolating a long method in its own class allows stopping a method from ballooning in size." +
        $"This also allows splitting it into submethods within the class, " +
        $"without polluting the original class with utility methods.";
}