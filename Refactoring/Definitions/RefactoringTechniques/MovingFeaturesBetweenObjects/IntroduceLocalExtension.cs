namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.MovingFeaturesBetweenObjects;

/// <summary>
/// Problem: A utility class doesn’t contain some methods that you need. But you can’t add these methods to the class. <para/>
/// Solution: Create a new class containing the methods and make it either the child or wrapper of the utility class. <para/>
/// See also <a href="https://refactoring.guru/introduce-local-extension">introduce-local-extension</a>
/// </summary>
public class IntroduceLocalExtension : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Introduce Local Extension";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"A utility class does’t contain some methods that you need. But you can’t add these methods to the class.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Create a new class containing the methods and make it either the child or wrapper of the utility class.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"The class that you’re using does’t have the methods that you need. What’s worse, " +
            $"you can’t add these methods (because the classes are in a third-party library, for example). " +
            $"There are two ways out:" +
            $"{Environment.NewLine}" +
            $"- Create a subclass from the relevant class, " +
            $"containing the methods and inheriting everything else from the parent class. " +
            $"This way is easier but is sometimes blocked by the utility class itself (due to final)." +
            $"{Environment.NewLine}" +
            $"- Create a wrapper class that contains all the new methods and elsewhere will delegate " +
            $"to the related object from the utility class. This method is more work since " +
            $"you need not only code to maintain the relationship between the wrapper and utility object, " +
            $"but also a large number of simple delegating methods in order " +
            $"to emulate the public interface of the utility class.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"By moving additional methods to a separate extension class (wrapper or subclass), " +
            $"you avoid gumming up client classes with code that does’t fit. " +
            $"Program components are more coherent and are more reusable.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Create a new extension class:" +
               $"{Environment.NewLine}" +
               $"- Option A: Make it a child of the utility class." +
               $"{Environment.NewLine}" +
               $"- Option B: If you have decided to make a wrapper, create a field in it for storing " +
               $"the utility class object to which delegation will be made. When using this option, " +
               $"you will need to also create methods that repeat the public methods of the utility class " +
               $"and contain simple delegation to the methods of the utility object." +
               $"{Environment.NewLine}" +
               $"2. Create a constructor that uses the parameters of the constructor of the utility class." +
               $"{Environment.NewLine}" +
               $"3. Also create an alternative “converting” constructor that takes only the object of the original class " +
               $"in its parameters. This will help to substitute the extension for the objects of the original class." +
               $"{Environment.NewLine}" +
               $"4. Create new extended methods in the class. Move foreign methods from other classes " +
               $"to this class or else delete the foreign methods if their functionality is already present in the extension." +
               $"{Environment.NewLine}" +
               $"5. Replace use of the utility class with the new extension class in places where its functionality is needed.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}