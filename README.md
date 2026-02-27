\# Maths Engine



\*\*Maths Engine\*\* is a Unity plugin that allows designers to \*\*visually configure mathematical formulas\*\* using ScriptableObjects, Prefabs, and config assets instead of hardcoded code.



It transforms math into \*\*data\*\*.



Designers build formulas visually.  

Programmers evaluate them at runtime.



This enables:



\-   Data-driven balancing

&nbsp;   

\-   Designer-owned logic

&nbsp;   

\-   Rapid iteration

&nbsp;   

\-   No recompiles

&nbsp;   

\-   No code churn

&nbsp;   

\-   Safer tuning

&nbsp;   

\-   Modular gameplay systems

&nbsp;   

\-   Reusable formulas

&nbsp;   

\-   Clean separation of logic and data



\- \[How to use](#how-to-use)

\- \[Install](#install)

&nbsp; - \[via npm](#via-npm)

&nbsp; - \[via OpenUPM](#via-openupm)

&nbsp; - \[via Git URL](#via-git-url)

&nbsp; - \[Tests](#tests)

\- \[Configuration](#configuration)



<!-- toc -->



\## How to use



\### Designer Flow



1\.  Create a \*\*Formula Asset\*\* (ScriptableObject / Prefab-based config)

&nbsp;   

2\.  Add math nodes (Add, Multiply, Clamp, Curve, etc)

&nbsp;   

3\.  Connect nodes visually

&nbsp;   

4\.  Bind variables (ATK, DEF, Level, HP, etc)

&nbsp;   

5\.  Preview output

&nbsp;   

6\.  Save the formula asset

&nbsp;   



\### Runtime Flow



```C#

float  result  =  formula.Evaluate(context);

```



Math becomes a \*\*graph\*\*, not a line of code.



\## Install



\### via npm



Open `Packages/manifest.json` with your favorite text editor. Add a \[scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html) and following line to dependencies block:

```json

{

&nbsp; "scopedRegistries": \[

&nbsp;   {

&nbsp;     "name": "npmjs",

&nbsp;     "url": "https://registry.npmjs.org/",

&nbsp;     "scopes": \[

&nbsp;       "com.arijeet"

&nbsp;     ]

&nbsp;   }

&nbsp; ],

&nbsp; "dependencies": {

&nbsp;   "com.arijeet.mathsengine": "1.0.0"

&nbsp; }

}

```

Package should now appear in package manager.



\### via Git URL



Open `Packages/manifest.json` with your favorite text editor. Add following line to the dependencies block:

```json

{

&nbsp; "dependencies": {

&nbsp;   "https://github.com/arijeetbaruah/Maths-Engine.git?path=/Packages/com.arijeet.mathsengine/MathsEngine"

&nbsp; }

}

```



\### Tests



The package can optionally be set as \*testable\*.

In practice this means that tests in the package will be visible in the \[Unity Test Runner](https://docs.unity3d.com/2017.4/Documentation/Manual/testing-editortestsrunner.html).



Open `Packages/manifest.json` with your favorite text editor. Add following line \*\*after\*\* the dependencies block:

```json

{

&nbsp; "dependencies": {

&nbsp; },

&nbsp; "testables": \[ "com.arijeet.mathsengine" ]

}

```



\## Configuration

\### Formula System



Maths Engine uses \*\*data-defined formulas\*\*:



\-   Formulas are assets

&nbsp;   

\-   Nodes are operators

&nbsp;   

\-   Connections define execution flow

&nbsp;   

\-   Variables are bound at runtime

&nbsp;   

\-   Evaluation is deterministic

&nbsp;   

\-   Serialization-safe

&nbsp;   

\-   Runtime-validated

&nbsp;   



\### Variable Binding



Variables are resolved from a \*\*runtime context\*\*:

```C#

formula.Evaluate(context);

```



Context can include:



\-   Character stats

&nbsp;   

\-   Game state

&nbsp;   

\-   Config values

&nbsp;   

\-   Progression data

&nbsp;   

\-   Environment values

&nbsp;   

\-   AI data

&nbsp;   

\-   Economy values



\## License



MIT License



Copyright © 2026 Arijeet Baruah

