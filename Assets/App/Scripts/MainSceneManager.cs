using ForceDirectedGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{

    #region Fields/Properties

    /// <summary>
    /// The graph displaying the network.
    /// </summary>
    [SerializeField]
    [Tooltip("The graph displaying the network.")]
    private GraphManager Graph;

    #endregion

    #region Methods

    /// <summary>
    /// Generates a network sample and displays it on the graph.
    /// </summary>
    private void GenerateSample1()
    {
        // Start a new network
        ForceDirectedGraph.DataStructure.Network network = new ForceDirectedGraph.DataStructure.Network();

        // Add nodes
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 1", Color.red));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 2", Color.blue));
        network.Nodes.Add(new ForceDirectedGraph.DataStructure.Node(Guid.NewGuid(), "Item 3", Color.green));

        // Add links
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[0].Id, network.Nodes[1].Id, 0.5f, Color.white)); // Item 1 -> Item 2
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[0].Id, network.Nodes[2].Id, 0.5f, Color.white)); // Item 1 -> Item 3
        network.Links.Add(new ForceDirectedGraph.DataStructure.Link(network.Nodes[1].Id, network.Nodes[2].Id, 0.5f, Color.white)); // Item 2 -> Item 3

        // Display network
        Graph.Initialize(network);
    }

    #endregion

}
