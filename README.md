# Force-Directed-Graph

This project provides the implementation of force directed graph visualization. This visualization is commonly used to display social networks in a pleasing and easy-to-understand way [- wikipedia](https://en.wikipedia.org/wiki/Force-directed_graph_drawing). 

` IMPORTANT: The code is not optimized for handling large number of nodes. Instead, it takes advantage of Unity3d physics engine to create the visualization. `

# Demo

![Simulation](docs/Simulation.gif)

We created a demo that visualizes the force directed graph of a simple sample network.
A complete demo can be found on [https://omaddam.github.io/Force-Directed-Graph/](https://omaddam.github.io/Force-Directed-Graph/).

# Getting Started

These instructions will get you a copy of the project on your local machine for development and testing purposes.

### Prerequisites

The things you need to install before you proceed with development:

1) [Unity3d (2020.2.0f1)](https://unity3d.com/get-unity/download/archive) [required].

### Installing

A step by step guide to get you started with development.

#### Download, clone, and setup the repository

```git
git clone https://github.com/omaddam/Force-Directed-Graph.git
```

#### Initialize git flow

```git
git flow init
```

# How to use this visualization in my project?

1) Add Graph.prefab into your scene and reference it in your script. `The prefab can be found under Assets/ForceDirectedGraph/Prefabs.`

![Simulation](docs/Step1.png)

# Standards

### General Standards

* Line ending: CRLF
* Case styles: Camel, Pascal, and Snake case
  * Arguments, paramters, and local variables: camel case (e.g. iterationOrder)
  * Global variables: pascal case (e.g. SeedItems)
  * Constants and static variables: snake case (ALL CAPS) (e.g. ALGORITHM_NAME)
* Methods naming convention:
  * Pascal case (e.g. GenerateSample)
  * Verbs

### Commenting Standards

* `///` Summaries: Full-usage of English grammar and punctuation. (e.g. Add periods to the end of your summaries, as if you were writing a phrase or sentence.)
*  `//` In-line comments: quick, point-form. Grammar and punctuation not needed

### Assets / App

* Contains all scripts and resources used in the demo.
* Scripts are created under Assets/App/Scripts folder.

### Assets / Others

* All components should be included under Assets/\<Name> folder. (e.g. Assets/ForceDirectedGraph)
* Each component should be isolated and under **NO CIRCUMSTANCES** referencing or using another component's scripts.
* Components are **NOT** allowed to reference or call application/demo scripts.