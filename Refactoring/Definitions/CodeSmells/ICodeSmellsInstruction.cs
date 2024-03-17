namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells;

/// <summary>
/// Provides functionalities to help describing the <see cref="CodeSmells"/>.<para/>
/// </summary>
public interface ICodeSmellsInstruction : IRefactoringDefinitionInstruction
{
    /// <summary>
    /// Describes signs and symptoms.
    /// </summary>
    /// <returns>Signs and symptoms statement.</returns>
    string SignsAndSymptoms();

    /// <summary>
    /// Describes reasons for the problem.
    /// </summary>
    /// <returns>Reasons for the problem statement.</returns>
    string ReasonsForTheProblem();

    /// <summary>
    /// Describes .
    /// </summary>
    /// <returns> statement.</returns>
    string Treatment();

    /// <summary>
    /// Describes payoff.
    /// </summary>
    /// <returns>Payoff statement.</returns>
    string Payoff();

    /// <summary>
    /// Describes when to ignore.
    /// </summary>
    /// <returns>When to ignore statement.</returns>
    string WhenToIgnore() => "No comments.";

    /// <summary>
    /// Describes performance impact of the technique.
    /// </summary>
    /// <returns>Performance statement.</returns>
    string Performance() => "No comments.";
}