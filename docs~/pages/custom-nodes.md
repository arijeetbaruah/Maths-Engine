\page custom_nodes Creating Custom Nodes

MathsEngine is designed to be extensible.  
You can create your own mathematical operations by implementing custom **Math Nodes**.

All nodes derive from `BaseMathNode`.

---

# Creating a Custom Node

To create a new node:

1. Create a class that inherits from `BaseMathNode`
2. Define the node inputs
3. Implement the `Calculate()` function
4. Implement `ToEquation()` for debugging and visualization

---
# Example: Square Node

The following example creates a node that squares a value.

```
result = value * value
```

```csharp
using Baruah.MathsEngine.Core;
using UnityEngine;

public class SquareNode : BaseMathNode
{
    [SerializeField]
    private BaseMathNode value;

    public override float Calculate(object[] parameters)
    {
        float v = value.Calculate(parameters);
        return v * v;
    }

    public override string ToEquation()
    {
        return $"({value.ToEquation()}^2)";
    }
}
```
___
# Node Inputs

Nodes usually take other nodes as inputs.

Example:
```
Multiply
├─ Node A
└─ Node B
```

Implementation example:
```
[SerializeField]
private BaseMathNode inputA;

[SerializeField]
private BaseMathNode inputB;
```
___
Using the Custom Node

Once created, the node can be added to a MathFormula.

Example graph:
```
Square
└─ Constant(5)
```
Result:
```
5² = 25
```