namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingConditionalExpressions;

/// <summary>
/// Problem: You have a conditional that performs various actions depending on object type or properties. <para/>
/// Solution: Create subclasses matching the branches of the conditional.
/// In them, create a shared method and move code from the corresponding branch of the conditional to it.
/// Then replace the conditional with the relevant method call.
/// The result is that the proper implementation will be attained via polymorphism depending on the object class. <para/>
/// See also <a href="https://refactoring.guru/replace-conditional-with-polymorphism">replace-conditional-with-polymorphism</a>
/// </summary>
public class ReplaceConditionalWithPolymorphism : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Conditional with Polymorphism";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have a conditional that performs various actions depending on object type or properties." +
               $"{Environment.NewLine}" +
               $"public class Bird \n{{\n  // ...\n  public double GetSpeed() \n  {{\n    switch (type) \n    {{\n      case EUROPEAN:\n        return GetBaseSpeed();\n      case AFRICAN:\n        return GetBaseSpeed() - GetLoadFactor() * numberOfCoconuts;\n      case NORWEGIAN_BLUE:\n        return isNailed ? 0 : GetBaseSpeed(voltage);\n      default:\n        throw new Exception(\"Should be unreachable\");\n    }}\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Create subclasses matching the branches of the conditional. In them, create a shared method and move code from the corresponding branch of the conditional to it. Then replace the conditional with the relevant method call. The result is that the proper implementation will be attained via polymorphism depending on the object class." +
            $"{Environment.NewLine}" +
            $"public abstract class Bird \n{{\n  // ...\n  public abstract double GetSpeed();\n}}\n\nclass European: Bird \n{{\n  public override double GetSpeed() \n  {{\n    return GetBaseSpeed();\n  }}\n}}\nclass African: Bird \n{{\n  public override double GetSpeed() \n  {{\n    return GetBaseSpeed() - GetLoadFactor() * numberOfCoconuts;\n  }}\n}}\nclass NorwegianBlue: Bird\n{{\n  public override double GetSpeed() \n  {{\n    return isNailed ? 0 : GetBaseSpeed(voltage);\n  }}\n}}\n\n// Somewhere in client code\nspeed = bird.GetSpeed();";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"This refactoring technique can help if your code contains operators performing various tasks that vary based on:" +
            $"{Environment.NewLine}" +
            $"- Class of the object or interface that it implements" +
            $"{Environment.NewLine}" +
            $"- Value of an object’s field" +
            $"{Environment.NewLine}" +
            $"- Result of calling one of an object’s methods" +
            $"{Environment.NewLine}" +
            $"If a new object property or type appears, you will need to search for and add code in all similar conditionals. Thus the benefit of this technique is multiplied if there are multiple conditionals scattered throughout all of an object’s methods.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- This technique adheres to the Tell-Don’t-Ask principle: instead of asking an object about its state and then performing actions based on this, it’s much easier to simply tell the object what it needs to do and let it decide for itself how to do that." +
            $"{Environment.NewLine}" +
            $"- Removes duplicate code. You get rid of many almost identical conditionals." +
            $"{Environment.NewLine}" +
            $"- If you need to add a new execution variant, all you need to do is add a new subclass without touching the existing code (Open/Closed Principle).";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"Preparing to Refactor" +
               $"{Environment.NewLine}" +
               $"For this refactoring technique, you should have a ready hierarchy of classes that will contain alternative behaviors. If you don’t have a hierarchy like this, create one. Other techniques will help to make this happen:" +
               $"{Environment.NewLine}" +
               $"- 'Replace Type Code with Subclasses'. Subclasses will be created for all values of a particular object property. This approach is simple but less flexible since you can’t create subclasses for the other properties of the object." +
               $"{Environment.NewLine}" +
               $"- 'Replace Type Code with State/Strategy'. A class will be dedicated for a particular object property and subclasses will be created from it for each value of the property. The current class will contain references to the objects of this type and delegate execution to them." +
               $"{Environment.NewLine}" +
               $"The following steps assume that you have already created the hierarchy." +
               $"{Environment.NewLine}" +
               $"Refactoring Steps" +
               $"{Environment.NewLine}" +
               $"1. If the conditional is in a method that performs other actions as well, perform 'Extract Method'." +
               $"{Environment.NewLine}" +
               $"2. For each hierarchy subclass, redefine the method that contains the conditional and copy the code of the corresponding conditional branch to that location." +
               $"{Environment.NewLine}" +
               $"3. Delete this branch from the conditional." +
               $"{Environment.NewLine}" +
               $"4. Repeat replacement until the conditional is empty. Then delete the conditional and declare the method abstract.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}