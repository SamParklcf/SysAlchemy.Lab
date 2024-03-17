namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.MovingFeaturesBetweenObjects;

/// <summary>
/// Problem: A class does almost nothing and isn’t responsible for anything, and no additional responsibilities are planned for it. <para/>
/// Solution: Move all features from the class to another one. <para/>
/// See also <a href="https://refactoring.guru/inline-class">inline-class</a>
/// </summary>
public class InlineClass : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Inline Class";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"A class does almost nothing and isn’t responsible for anything, and no additional responsibilities are planned for it.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Move all features from the class to another one.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Often this technique is needed after the features of one class are “transplanted” to other classes, " +
            $"leaving that class with little to do.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return $"Eliminating needless classes frees up operating memory on the computer—and bandwidth in your head.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. In the recipient class, create the public fields and methods present in the donor class. " +
            $"Methods should refer to the equivalent methods of the donor class." +
            $"{Environment.NewLine}" +
            $"2. Replace all references to the donor class with references to the fields and methods of the recipient class." +
            $"{Environment.NewLine}" +
            $"3. Now test the program and make sure that no errors have been added. " +
            $"If tests show that everything is working A-OK, start using 'Move Method' and 'Move Field' " +
            $"to completely transplant all functionality to the recipient class from the original one. " +
            $"Continue doing so until the original class is completely empty." +
            $"{Environment.NewLine}" +
            $"4. Delete the original class.";
    }
}