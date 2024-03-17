namespace SysAlchemy.Lab.Refactoring.Definitions;

/// <summary>
/// Provides functionalities to help describe the refactoring definitions.
/// </summary>
public interface IRefactoringDefinitionInstruction
{
    /// <summary>
    /// Describes the name of the technique.
    /// </summary>
    /// <returns>Refactoring technique name.</returns>
    string Name();
}