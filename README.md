# Maths Engine

**Maths Engine** is a Unity plugin that allows designers to **visually configure mathematical formulas** using ScriptableObjects, Prefabs, and config assets instead of hardcoded code.

It transforms math into **data**.

Designers build formulas visually.  
Programmers evaluate them at runtime.

This enables:

-   Data-driven balancing
    
-   Designer-owned logic
    
-   Rapid iteration
    
-   No recompiles
    
-   No code churn
    
-   Safer tuning
    
-   Modular gameplay systems
    
-   Reusable formulas
    
-   Clean separation of logic and data

## Table of Contents
- [How to use](#how-to-use)
- [Install](#install)
  - [via npm](#via-npm)
  - [via OpenUPM](#via-openupm)
  - [via Git URL](#via-git-url)
  - [Tests](#tests)
- [Configuration](#configuration)

<!-- toc -->

## How to use

### Designer Flow

1.  Create a **Formula Asset** (ScriptableObject / Prefab-based config)
    
2.  Add math nodes (Add, Multiply, Clamp, Curve, etc)
    
3.  Connect nodes visually
    
4.  Bind variables (ATK, DEF, Level, HP, etc)
    
5.  Preview output
    
6.  Save the formula asset
    

### Runtime Flow

```C#
float  result  =  formula.Evaluate(context);
```

Math becomes a **graph**, not a line of code.

## Install

### via npm

Open `Packages/manifest.json` with your favorite text editor. Add a [scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html) and following line to dependencies block:
```json
{
  "scopedRegistries": [
    {
      "name": "npmjs",
      "url": "https://registry.npmjs.org/",
      "scopes": [
        "com.arijeet"
      ]
    }
  ],
  "dependencies": {
    "com.arijeet.mathsengine": "1.0.0"
  }
}
```
Package should now appear in package manager.

### via Git URL

Open `Packages/manifest.json` with your favorite text editor. Add following line to the dependencies block:
```json
{
  "dependencies": {
    "https://github.com/arijeetbaruah/Maths-Engine.git?path=/Packages/com.arijeet.mathsengine/MathsEngine"
  }
}
```

### Tests

The package can optionally be set as *testable*.
In practice this means that tests in the package will be visible in the [Unity Test Runner](https://docs.unity3d.com/2017.4/Documentation/Manual/testing-editortestsrunner.html).

Open `Packages/manifest.json` with your favorite text editor. Add following line **after** the dependencies block:
```json
{
  "dependencies": {
  },
  "testables": [ "com.arijeet.mathsengine" ]
}
```

## Configuration
### Formula System

Maths Engine uses **data-defined formulas**:

-   Formulas are assets
    
-   Nodes are operators
    
-   Connections define execution flow
    
-   Variables are bound at runtime
    
-   Evaluation is deterministic
    
-   Serialization-safe
    
-   Runtime-validated
    

### Variable Binding

Variables are resolved from a **runtime context**:
```C#
formula.Evaluate(context);
```

Context can include:

-   Character stats
    
-   Game state
    
-   Config values
    
-   Progression data
    
-   Environment values
    
-   AI data
    
-   Economy values

## License

MIT License

Copyright © 2026 Arijeet Baruah
