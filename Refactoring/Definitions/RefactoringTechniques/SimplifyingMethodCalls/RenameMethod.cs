namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: The name of a method doesn’t explain what the method does. <para/>
/// Solution: Rename the method. <para/>
/// See also <a href="https://refactoring.guru/rename-method">rename-method</a>
/// </summary>
public class RenameMethod : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Rename Method";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"The name of a method does’t explain what the method does.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Rename the method.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Perhaps a method was poorly named from the very beginning—for example, " +
            $"someone created the method in a rush and did’t give proper care to naming it well." +
            $"{Environment.NewLine}" +
            $"Or perhaps the method was well named at first but as its functionality grew, " +
            $"the method name stopped being a good descriptor.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"Code readability. Try to give the new method a name that reflects what it does. " +
            $"Something like createOrder(), renderCustomerInfo(), etc.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. See whether the method is defined in a superclass or subclass. " +
            $"If so, you must repeat all steps in these classes too." +
            $"{Environment.NewLine}" +
            $"2. The next method is important for maintaining the functionality of the program during the refactoring process. " +
            $"Create a new method with a new name. Copy the code of the old method to it." +
            $" Delete all the code in the old method and, instead of it, insert a call for the new method." +
            $"{Environment.NewLine}" +
            $"3. Find all references to the old method and replace them with references to the new one." +
            $"{Environment.NewLine}" +
            $"4. Delete the old method. If the old method is part of a public interface, " +
            $"don’t perform this step. Instead, mark the old method as deprecated.";
    }
}