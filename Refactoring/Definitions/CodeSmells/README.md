## [Code Smells](https://refactoring.guru/refactoring/smells)

- What? How can code "smell"??
- Well it doesn't have a nose... but it definitely can stink!


### [Bloaters](https://refactoring.guru/refactoring/smells/bloaters)
Bloaters are code, methods and classes that have increased to such gargantuan proportions that they are hard to work with. Usually these smells do not crop up right away, rather they accumulate over time as the program evolves (and especially when nobody makes an effort to eradicate them).

- [Long Method](https://refactoring.guru/smells/long-method)
- [Large Class](https://refactoring.guru/smells/large-class)
- [Primitive Obsession](https://refactoring.guru/smells/primitive-obsession)
- [Long Parameter List](https://refactoring.guru/smells/long-parameter-list)
- [Data Clumps](https://refactoring.guru/smells/data-clumps)

### [Object-Orientation Abusers](https://refactoring.guru/refactoring/smells/oo-abusers)
All these smells are incomplete or incorrect application of object-oriented programming principles.

- [Alternative Classes with Different Interfaces](https://refactoring.guru/smells/alternative-classes-with-different-interfaces)
- [Refused Bequest](https://refactoring.guru/smells/refused-bequest)
- [Switch Statements](https://refactoring.guru/smells/switch-statements)
- [Temporary Field](https://refactoring.guru/smells/temporary-field)

### [Change Preventers](https://refactoring.guru/refactoring/smells/change-preventers)
These smells mean that if you need to change something in one place in your code, you have to make many changes in other places too. Program development becomes much more complicated and expensive as a result.

- [Divergent Change](https://refactoring.guru/smells/divergent-change)
- [Parallel Inheritance Hierarchies](https://refactoring.guru/smells/parallel-inheritance-hierarchies)
- [Shotgun Surgery](https://refactoring.guru/smells/shotgun-surgery)

### [Dispensables](https://refactoring.guru/refactoring/smells/dispensables)
A dispensable is something pointless and unneeded whose absence would make the code cleaner, more efficient and easier to understand.

- [Comments](https://refactoring.guru/smells/comments)
- [Duplicate Code](https://refactoring.guru/smells/duplicate-code)
- [Data Class](https://refactoring.guru/smells/data-class)
- [Dead Code](https://refactoring.guru/smells/dead-code)
- [Lazy Class](https://refactoring.guru/smells/lazy-class)
- [Speculative Generality](https://refactoring.guru/smells/speculative-generality)

### [Couplers](https://refactoring.guru/refactoring/smells/couplers)
All the smells in this group contribute to excessive coupling between classes or show what happens if coupling is replaced by excessive delegation.

- [Feature Envy](https://refactoring.guru/smells/feature-envy)
- [Inappropriate Intimacy](https://refactoring.guru/smells/inappropriate-intimacy)
- [Incomplete Library Class](https://refactoring.guru/smells/incomplete-library-class)
- [Message Chains](https://refactoring.guru/smells/message-chains)
- [Middle Man](https://refactoring.guru/smells/middle-man)