namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques;

/// <summary>
/// Provides functionalities to help describing the <see cref="RefactoringTechniques"/>.<para/>
/// Refactoring is a systematic process of improving code without creating new functionality that can transform 
/// a mess into clean code and simple design.<para/>
/// Refactoring techniques describe actual refactoring steps. Most refactoring techniques have their 
/// pros and cons. Therefore, each refactoring should be properly motivated and applied with caution.<para/>
/// Performing refactoring step-by-step and running tests after each change are key elements of refactoring that make it 
/// predictable and safe.
/// </summary>
public interface IRefactoringTechniquesInstruction : IRefactoringDefinitionInstruction
{
    /// <summary>
    /// Describes the problem.
    /// </summary>
    /// <returns>Problem statement.</returns>
    string Problem();

    /// <summary>
    /// Describes the solution.
    /// </summary>
    /// <returns>Solution statement.</returns>
    string Solution();

    /// <summary>
    /// Describes why we need to refactor the problem.
    /// </summary>
    /// <returns>Reason to refactoring.</returns>
    string WhyRefactor();

    /// <summary>
    /// Describes the benefits of the refactoring.
    /// </summary>
    /// <returns>Benefits statement.</returns>
    string Benefits() => $"No comments.";

    /// <summary>
    /// Describes drawbacks that the refactoring may cause.
    /// </summary>
    /// <returns>Drawbacks statement.</returns>
    string Drawbacks() => "No drawbacks.";

    /// <summary>
    /// Describes situations that should not be used in.
    /// </summary>
    /// <returns>When not to use statement.</returns>
    string WhenNotToUse() => "No comments.";

    /// <summary>
    /// Describes good to know tips.
    /// </summary>
    /// <returns>Good to know statement.</returns>
    string GoodToKnow() => "No comments.";

    /// <summary>
    /// Describes how to refactor the problem.
    /// </summary>
    /// <returns>How-to statement.</returns>
    string HowToRefactor();

    /// <summary>
    /// Describes next steps you can do after refactoring.
    /// </summary>
    /// <returns>Next steps statement.</returns>
    string NextSteps() => "No comments.";
}