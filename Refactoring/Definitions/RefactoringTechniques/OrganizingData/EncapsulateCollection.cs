﻿namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: A class contains a collection field and a simple getter and setter for working with the collection. <para/>
/// Solution: Make the getter-returned value read-only and create methods for adding/deleting elements of the collection. <para/>
/// See also <a href="https://refactoring.guru/encapsulate-collection">encapsulate-collection</a>
/// </summary>
public class EncapsulateCollection : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Encapsulate Collection";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"A class contains a collection field and a simple getter and setter for working with the collection.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Make the getter-returned value read-only and create methods for adding/deleting elements of the collection.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"A class contains a field that contains a collection of objects. This collection could be an array, " +
            $"list, set or vector. A normal getter and setter have been created for working with the collection." +
            $"{Environment.NewLine}" +
            $"But the collections should be used by a protocol that’s a bit different from the one used by other data types. " +
            $"The getter method shouldn’t return the collection object itself, " +
            $"since this would let clients change collection contents without the knowledge of the owner class. " +
            $"In addition, this would show too much of the internal structures of the object data to clients. " +
            $"The method for getting collection elements should return a value that does’t allow changing " +
            $"the collection or disclose excessive data about its structure." +
            $"{Environment.NewLine}" +
            $"In addition, there shouldn’t be a method that assigns a value to the collection. " +
            $"Instead, there should be operations for adding and deleting elements. " +
            $"Thanks to this, the owner object gains control over addition and deletion of collection elements." +
            $"{Environment.NewLine}" +
            $"Such a protocol properly encapsulates a collection, which ultimately reduces " +
            $"the degree of association between the owner class and the client code.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- The collection field is encapsulated inside a class. When the getter is called, " +
            $"it returns a copy of the collection, which prevents accidental changing or overwriting of " +
            $"the collection elements without the knowledge of the class that contains the collection." +
            $"{Environment.NewLine}" +
            $"- If collection elements are contained inside a primitive type, such as an array, " +
            $"you create more convenient methods for working with the collection." +
            $"{Environment.NewLine}" +
            $"- If collection elements are contained inside a non-primitive container (standard collection class), " +
            $"by encapsulating the collection you can restrict access to unwanted standard methods of " +
            $"the collection (such as by restricting addition of new elements).";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Create methods for adding and deleting collection elements. They must accept collection elements in their parameters." +
            $"{Environment.NewLine}" +
            $"2. Assign an empty collection to the field as the initial value if this isn’t done in the class constructor." +
            $"{Environment.NewLine}" +
            $"3. Find the calls of the collection field setter. Change the setter so that it uses operations " +
            $"for adding and deleting elements, or make these operations call client code." +
            $"{Environment.NewLine}" +
            $"Note that setters can be used only to replace all collection elements with other ones. " +
            $"Therefore it may be advisable to change the setter name '(Rename Method)' to replace." +
            $"{Environment.NewLine}" +
            $"4. Find all calls of the collection getter after which the collection is changed. " +
            $"Change the code so that it uses your new methods for adding and deleting elements from the collection." +
            $"{Environment.NewLine}" +
            $"5. Change the getter so that it returns a read-only representation of the collection." +
            $"{Environment.NewLine}" +
            $"6. Inspect the client code that uses the collection for code that would look better inside of " +
            $"the collection class itself.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}