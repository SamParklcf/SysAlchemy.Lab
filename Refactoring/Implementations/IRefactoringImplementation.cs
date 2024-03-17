using SysAlchemy.Lab.Refactoring.Definitions;

namespace SysAlchemy.Lab.Refactoring.Implementations;

/// <summary>
/// Provides functionalities help describing the refactoring techniques.
/// </summary>
public interface IRefactoringImplementation
{
    /// <summary>
    /// Gets definitions of the refactoring technique.
    /// </summary>
    /// <returns></returns>
    IRefactoringDefinitionInstruction GetDefinitionInstruction();
}