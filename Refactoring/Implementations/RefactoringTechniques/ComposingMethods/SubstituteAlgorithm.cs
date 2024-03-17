using System.Diagnostics.CodeAnalysis;
using SysAlchemy.Lab.Refactoring.Definitions;

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.SubstituteAlgorithm"/>
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
public class SubstituteAlgorithm : IRefactoringImplementation
{
    public class BeforeRefactoring
    {
        // Nothing much to say, just when you need to a fresh start, do it. change the whole body to satisfy your needs.
        public string FoundPerson(string[] people)
        {
            foreach (var person in people)
            {
                if (person.Equals("Don"))
                {
                    return "Don";
                }

                if (person.Equals("John"))
                {
                    return "John";
                }

                if (person.Equals("Kent"))
                {
                    return "Kent";
                }
            }

            return string.Empty;
        }
    }

    public class AfterRefactoring
    {
        // Algorithm looks better now? I say yes.
        public string FoundPerson(string[] people)
        {
            var candidates = new List<string>() { "Don", "John", "Kent" };

            foreach (var person in people)
            {
                if (candidates.Contains(person))
                {
                    return person;
                }
            }

            return string.Empty;
        }
    }

    /// <inheritdoc/>
    public IRefactoringDefinitionInstruction GetDefinitionInstruction()
    {
        return new Definitions.RefactoringTechniques.ComposingMethods.SubstituteAlgorithm();
    }
}