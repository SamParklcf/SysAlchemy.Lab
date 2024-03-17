## [Refactoring Techniques](https://refactoring.guru/refactoring/techniques)


### [Composing Methods](https://refactoring.guru/refactoring/techniques/composing-methods)
Much of refactoring is devoted to correctly composing methods. In most cases, excessively long methods are the root of all evil. The vagaries of code inside these methods conceal the execution logic and make the method extremely hard to understand—and even harder to change.

The refactoring techniques in this group streamline methods, remove code duplication, and pave the way for future improvements.

- [Extract Method](https://refactoring.guru/extract-method)
- [Inline Method](https://refactoring.guru/inline-method)
- [Extract Variable](https://refactoring.guru/extract-variable)
- [Inline Temp](https://refactoring.guru/inline-temp)
- [Replace Temp with Query](https://refactoring.guru/replace-temp-with-query)
- [Split Temporary Variable](https://refactoring.guru/split-temporary-variable)
- [Remove Assignments to Parameters](https://refactoring.guru/remove-assignments-to-parameters)
- [Replace Method with Method Object](https://refactoring.guru/replace-method-with-method-object)
- [Substitute Algorithm](https://refactoring.guru/substitute-algorithm)

### [Moving Features between Objects](https://refactoring.guru/refactoring/techniques/moving-features-between-objects)
Even if you have distributed functionality among different classes in a less-than-perfect way, there is still hope.

These refactoring techniques show how to safely move functionality between classes, create new classes, and hide implementation details from public access.

- [Move Method](https://refactoring.guru/move-method)
- [Move Field](https://refactoring.guru/move-field)
- [Extract Class](https://refactoring.guru/extract-class)
- [Inline Class](https://refactoring.guru/inline-class)
- [Hide Delegate](https://refactoring.guru/hide-delegate)
- [Remove Middle Man](https://refactoring.guru/remove-middle-man)
- [Introduce Foreign Method](https://refactoring.guru/introduce-foreign-method)
- [Introduce Local Extension](https://refactoring.guru/introduce-local-extension)

### [Organizing Data](https://refactoring.guru/refactoring/techniques/organizing-data)
These refactoring techniques help with data handling, replacing primitives with rich class functionality. Another important result is untangling of class associations, which makes classes more portable and reusable.

- [Change Value to Reference](https://refactoring.guru/change-value-to-reference)
- [Change Reference to Value](https://refactoring.guru/change-reference-to-value)
- [Duplicate Observed Data](https://refactoring.guru/duplicate-observed-data)
- [Self Encapsulate Field](https://refactoring.guru/self-encapsulate-field)
- [Replace Data Value with Object](https://refactoring.guru/replace-data-value-with-object)
- [Replace Array with Object](https://refactoring.guru/replace-array-with-object)
- [Change Unidirectional Association to Bidirectional](https://refactoring.guru/change-unidirectional-association-to-bidirectional)
- [Change Bidirectional Association to Unidirectional](https://refactoring.guru/change-bidirectional-association-to-unidirectional)
- [Encapsulate Field](https://refactoring.guru/encapsulate-field)
- [Encapsulate Collection](https://refactoring.guru/encapsulate-collection)
- [Replace Magic Number with Symbolic Constant](https://refactoring.guru/replace-magic-number-with-symbolic-constant)
- [Replace Type Code with Class](https://refactoring.guru/replace-type-code-with-class)
- [Replace Type Code with Subclasses](https://refactoring.guru/replace-type-code-with-subclasses)
- [Replace Type Code with State/Strategy](https://refactoring.guru/replace-type-code-with-state-strategy)
- [Replace Subclass with Fields](https://refactoring.guru/replace-subclass-with-fields)

### [Simplifying Conditional Expressions](https://refactoring.guru/refactoring/techniques/simplifying-conditional-expressions)
Conditionals tend to get more and more complicated in their logic over time, and there are yet more techniques to combat this as well.

- [Consolidate Conditional Expression](https://refactoring.guru/consolidate-conditional-expression)
- [Consolidate Duplicate Conditional Fragments](https://refactoring.guru/consolidate-duplicate-conditional-fragments)
- [Decompose Conditional](https://refactoring.guru/decompose-conditional)
- [Replace Conditional with Polymorphism](https://refactoring.guru/replace-conditional-with-polymorphism)
- [Remove Control Flag](https://refactoring.guru/remove-control-flag)
- [Replace Nested Conditional with Guard Clauses](https://refactoring.guru/replace-nested-conditional-with-guard-clauses)
- [Introduce Null Object](https://refactoring.guru/introduce-null-object)
- [Introduce Assertion](https://refactoring.guru/introduce-assertion)

### [Simplifying Method Calls](https://refactoring.guru/refactoring/techniques/simplifying-method-calls)
These techniques make method calls simpler and easier to understand. This, in turn, simplifies the interfaces for interaction between classes.

- [Add Parameter](https://refactoring.guru/add-parameter)
- [Remove Parameter](https://refactoring.guru/remove-parameter)
- [Rename Method](https://refactoring.guru/rename-method)
- [Separate Query from Modifier](https://refactoring.guru/separate-query-from-modifier)
- [Parameterize Method](https://refactoring.guru/parameterize-method)
- [Introduce Parameter Object](https://refactoring.guru/introduce-parameter-object)
- [Preserve Whole Object](https://refactoring.guru/preserve-whole-object)
- [Remove Setting Method](https://refactoring.guru/remove-setting-method)
- [Replace Parameter with Explicit Methods](https://refactoring.guru/replace-parameter-with-explicit-methods)
- [Replace Parameter with Method Call](https://refactoring.guru/replace-parameter-with-method-call)
- [Hide Method](https://refactoring.guru/hide-method)
- [Replace Constructor with Factory Method](https://refactoring.guru/replace-constructor-with-factory-method)
- [Replace Error Code with Exception](https://refactoring.guru/replace-error-code-with-exception)
- [Replace Exception with Test](https://refactoring.guru/replace-exception-with-test)

### [Dealing with Generalization](https://refactoring.guru/refactoring/techniques/dealing-with-generalization)
Abstraction has its own group of refactoring techniques, primarily associated with moving functionality along the class inheritance hierarchy, creating new classes and interfaces, and replacing inheritance with delegation and vice versa.

- [Pull Up Field](https://refactoring.guru/pull-up-field)
- [Pull Up Method](https://refactoring.guru/pull-up-method)
- [Pull Up Constructor Body](https://refactoring.guru/pull-up-constructor-body)
- [Push Down Field](https://refactoring.guru/push-down-field)
- [Push Down Method](https://refactoring.guru/push-down-method)
- [Extract Subclass](https://refactoring.guru/extract-subclass)
- [Extract Superclass](https://refactoring.guru/extract-superclass)
- [Extract Interface](https://refactoring.guru/extract-interface)
- [Collapse Hierarchy](https://refactoring.guru/collapse-hierarchy)
- [Form Template Method](https://refactoring.guru/form-template-method)
- [Replace Inheritance with Delegation](https://refactoring.guru/replace-inheritance-with-delegation)
- [Replace Delegation with Inheritance](https://refactoring.guru/replace-delegation-with-inheritance)