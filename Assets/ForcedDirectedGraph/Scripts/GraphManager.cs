using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForceDirectedGraph
{
    public class GraphManager : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Initializes the graph.
        /// </summary>
        /// <param name="network">The netwok being displayed.</param>
        public void Initialize(DataStructure.Network network)
        {
            _Network = network;
            Display();
        }

        #endregion

        #region Fields/Properties

        [Header("Nodes")]

        /// <summary>
        /// References the parent holding all nodes.
        /// </summary>
        [SerializeField]
        [Tooltip("References the parent holding all nodes.")]
        private GameObject NodesParent;

        /// <summary>
        /// Template used for initiating nodes.
        /// </summary>
        [SerializeField]
        [Tooltip("Template used for initiating nodes.")]
        private GameObject NoteTemplate;

        /// <summary>
        /// List of all nodes displayed on the graph.
        /// </summary>
        private Dictionary<Guid, GraphNode> GraphNodes;



        [Header("Links")]

        /// <summary>
        /// References the parent holding all links.
        /// </summary>
        [SerializeField]
        [Tooltip("References the parent holding all links.")]
        private GameObject LinksParent;

        /// <summary>
        /// Template used for initiating links.
        /// </summary>
        [SerializeField]
        [Tooltip("Template used for initiating links.")]
        private GameObject LinkTemplate;



        [Header("Data")]

        /// <summary>
        /// The netwok being displayed.
        /// </summary>
        [SerializeField]
        [Tooltip("The netwok being displayed.")]
        private DataStructure.Network _Network;

        /// <summary>
        /// The netwok being displayed.
        /// </summary>
        public DataStructure.Network Network { get { return _Network; } }

        #endregion

        #region Display Methods

        /// <summary>
        /// Displays the network.
        /// </summary>
        private void Display()
        {
            // Clear everything
            Clear();

            // Display nodes
            DisplayNodes();

            // Display links
            DisplayLinks();
        }

        /// <summary>
        /// Deletes all nodes and links in the graph.
        /// </summary>
        private void Clear()
        {
            // Clear nodes
            GraphNodes = new Dictionary<Guid, GraphNode>();
            foreach (Transform entity in NodesParent.transform)
                GameObject.Destroy(entity.gameObject);

            // Clear paths
            foreach (Transform path in LinksParent.transform)
                GameObject.Destroy(path.gameObject);
        }

        /// <summary>
        /// Displays nodes on the graph.
        /// </summary>
        private void DisplayNodes()
        {
            // For each position, create an entity
            foreach (var node in Network?.Nodes)
            {
                // Create a new entity instance
                GameObject graphNode = Instantiate(NoteTemplate, NodesParent.transform);
                graphNode.transform.position = Vector3.zero;
                graphNode.transform.localRotation = Quaternion.Euler(Vector3.zero);

                // Extract the script
                GraphNode script = graphNode.GetComponent<GraphNode>();

                // Initialize data
                script.Initialize(node);

                // Add to list
                GraphNodes?.Add(node.Id, script);
            }
        }

        /// <summary>
        /// Displays links on the graph.
        /// </summary>
        private void DisplayLinks()
        {
            // For each position, create an entity
            foreach (var link in Network?.Links)
            {
                // Find graph nodes
                if (!GraphNodes.ContainsKey(link.FirstNodeId)
                    || !GraphNodes.ContainsKey(link.SecondNodeId))
                    continue;
                GraphNode firstNode = GraphNodes?[link.FirstNodeId];
                GraphNode secondNode = GraphNodes?[link.SecondNodeId];

                // Create a new entity instance
                GameObject graphLink = Instantiate(LinkTemplate, LinksParent.transform);
                graphLink.transform.position = Vector3.zero;
                graphLink.transform.localRotation = Quaternion.Euler(Vector3.zero);

                // Extract the script
                GraphLink script = graphLink.GetComponent<GraphLink>();

                // Initialize data
                script.Initialize(link, firstNode, secondNode);
            }
        }

        #endregion

    }
}
