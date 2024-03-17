using SysAlchemy.Lab.Refactoring.Definitions;

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.SplitTemporaryVariable"/>
/// </summary>
public class SplitTemporaryVariable: IRefactoringImplementation
{
    public class BeforeRefactoring
    {
        public void Calculate(double height, double width)
        {
            // It seems that the 'temp' variable hold temporary different calculations.
            // Do you forget that: Each component of the program code should be responsible for one and one thing only.
            // Consider you facing a problem, and you have a complex scenario, what you should do? debugging every 
            // single line to find the wrong calculation? no man, common!!!
            var temp = 2 * (height + width);
            Console.WriteLine(temp);
            temp = height * width;
            Console.WriteLine(temp);
        }
    }
    
    public class AfterRefactoring
    {
        public void Calculate(double height, double width)
        {
            // It's better now. we can find that we have two different calculations.
            // ALSO, more readable.
            var perimeter = 2 * (height + width);
            Console.WriteLine(perimeter);
            var area = height * width;
            Console.WriteLine(area);
        }
    }
    
    /// <inheritdoc/>
    public IRefactoringDefinitionInstruction GetDefinitionInstruction()
    {
        return new Definitions.RefactoringTechniques.ComposingMethods.SplitTemporaryVariable();
    }
}