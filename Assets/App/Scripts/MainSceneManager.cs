using ForceDirectedGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{

    #region Initialization

    /// <summary>
    /// Executes once on start.
    /// </summary>
    private void Start()
    {
        DisplayVersion();
        GenerateSample1();        
    }

    #endregion

    #region Fields/Properties

    /// <summary>
    /// The graph displaying the network.
    /// </summary>
    [SerializeField]
    [Tooltip("The graph displaying the network.")]
    private GraphManager Graph;

    /// <summary>
    /// Text UI element displaying the version of the project.
    /// </summary>
    [SerializeField]
    [Tooltip("Text UI element displaying the version of the project.")]
    private Text Version;

    #endregion

    #region Methods

    /// <summary>
    /// Displays current project's version.
    /// </summary>
    private void DisplayVersion()
    {
        Version.text = string.Format("Version: {0}",  Application.version);
    }

    /// <summary>
    /// Generates a network sample and displays it on the graph.
    /// </summary>
    private void GenerateSample1()
    {
        // Start a new network
        ForceDirectedGraph.DataStructure.Network network = new ForceDirectedGraph.DataStructure.Network();

        // Add nodes ---------------------------------------------------

        // Triangle
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 1", Color.red));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 2", Color.blue));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 3", Color.green));

        // Center
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 4", Color.white));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 5", Color.black));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 6", Color.black));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 7", Color.black));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 8", Color.black));

        // Star
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "", Color.grey));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "", Color.grey));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "", Color.grey));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "", Color.grey));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "", Color.grey));

        // Square
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "", Color.grey));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "", Color.grey));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "", Color.grey));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "", Color.grey));


        // Add links ---------------------------------------------------

        // Triangle
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[0].Id, network.Nodes[1].Id, 0.5f, Color.white)); // Item 1 -> Item 2
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[0].Id, network.Nodes[2].Id, 0.5f, Color.white)); // Item 1 -> Item 3
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[1].Id, network.Nodes[2].Id, 0.5f, Color.white)); // Item 2 -> Item 3

        // Center
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[3].Id, network.Nodes[4].Id, 0.7f, Color.white)); // Item 4 -> Item 5
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[3].Id, network.Nodes[5].Id, 0.2f, Color.white)); // Item 4 -> Item 6
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[3].Id, network.Nodes[6].Id, 0.2f, Color.white)); // Item 4 -> Item 7
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[3].Id, network.Nodes[7].Id, 0.2f, Color.white)); // Item 4 -> Item 8

        // Star
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[8].Id, network.Nodes[9].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[8].Id, network.Nodes[10].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[8].Id, network.Nodes[11].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[8].Id, network.Nodes[12].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[9].Id, network.Nodes[10].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[9].Id, network.Nodes[11].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[9].Id, network.Nodes[12].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[10].Id, network.Nodes[11].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[10].Id, network.Nodes[12].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[11].Id, network.Nodes[12].Id, 0.2f, Color.white));

        // Square
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[13].Id, network.Nodes[14].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[13].Id, network.Nodes[15].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[13].Id, network.Nodes[16].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[14].Id, network.Nodes[15].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[14].Id, network.Nodes[16].Id, 0.2f, Color.white));
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[15].Id, network.Nodes[16].Id, 0.2f, Color.white));

        // Display network
        Graph.Initialize(network);
    }

    #endregion

}
