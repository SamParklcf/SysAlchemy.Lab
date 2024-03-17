using SysAlchemy.Lab.Refactoring.Definitions;

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.RemoveAssignmentsToParameters"/>
/// </summary>
public class RemoveAssignmentsToParameters: IRefactoringImplementation
{
    public class BeforeRefactoring
    {
        public int Discount(int inputVal, int quantity) 
        {
            // Are you messing with me? changing the input parameter value?
            // What will you do if you want the primitive value of 'inputVal' somewhere later in the code?
            // Where is the single responsibility?
            // And readability? I need to guess that the 'inputValue' is the result? do not LIKE such this guessing.
            if (quantity > 50) 
            {
                inputVal -= 2;
            }
            // ...

            return inputVal;
        }
    }
    
    public class AfterRefactoring
    {
        public int Discount(int inputVal, int quantity) 
        {
            // Oh, welcome readability!
            // Welcome single responsibility!
            // Welcome easier tracking!
            var result = inputVal;
  
            if (quantity > 50) 
            {
                result -= 2;
            }
            // ...

            return result;
        }
    }
    
    /// <inheritdoc/>
    public IRefactoringDefinitionInstruction GetDefinitionInstruction()
    {
        return new Definitions.RefactoringTechniques.ComposingMethods.RemoveAssignmentsToParameters();
    }
}