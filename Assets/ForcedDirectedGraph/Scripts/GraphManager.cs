using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ForceDirectedGraph
{
    public class GraphManager : MonoBehaviour
    {

        #region Constants

#if !UNITY_EDITOR && UNITY_WEBGL

        /// <summary>
        /// The repulsion force between any two nodes.
        /// </summary>
        private const float REPULSION_FORCE = 600f;

        /// <summary>
        /// The maximum distance for applying repulsion forces.
        /// </summary>
        private const float REPULSION_DISTANCE = 1.5f;

        /// <summary>
        /// The attraction force between any two nodes.
        /// </summary>
        private const float ATTRACTION_FORCE = 600f;

#else

        /// <summary>
        /// The repulsion force between any two nodes.
        /// </summary>
        private const float REPULSION_FORCE = 60f;

        /// <summary>
        /// The maximum distance for applying repulsion forces.
        /// </summary>
        private const float REPULSION_DISTANCE = 1.5f;

        /// <summary>
        /// The attraction force between any two nodes.
        /// </summary>
        private const float ATTRACTION_FORCE = 60f;

#endif

        #endregion

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

        /// <summary>
        /// List of all links displayed on the graph.
        /// </summary>
        private List<GraphLink> GraphLinks;



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

            // Shuffle the nodes
            ShuffleNodes();
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
            GraphLinks = new List<GraphLink>();
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

                // Add to list
                GraphLinks.Add(script);
            }
        }

        /// <summary>
        /// Shuffles the nodes randomly.
        /// </summary>
        private void ShuffleNodes()
        {
            System.Random random = new System.Random();
            foreach (var node in GraphNodes.Values)
                node.ApplyForces(new List<Vector2>() { new Vector2(random.Next(-10, 10) / 10f, random.Next(-10, 10) / 10f) }, true);
        }

        #endregion

        #region Force Methods

        /// <summary>
        /// Continuously apply forces to nodes.
        /// </summary>
        private void Update()
        {
            ApplyForces();
        }

        /// <summary>
        /// Computes and applies forces to nodes.
        /// </summary>
        private void ApplyForces()
        {
            // Stores all the forces to be applied to each node
            Dictionary<GraphNode, List<Vector2>> nodeForces = new Dictionary<GraphNode, List<Vector2>>();
            foreach (var node1 in GraphNodes.Values)
                nodeForces.Add(node1, new List<Vector2>());

            // Compute repulsion forces
            foreach (var node1 in GraphNodes.Values)
                foreach (var node2 in GraphNodes.Values)
                    if (node1 != node2)
                        nodeForces[node1].Add(ComputeRepulsiveForce(node1, node2));

            // Compute attraction forces
            foreach (var link in GraphLinks)
            {
                var force = ComputeAttractionForce(link);
                nodeForces[link.FirstNode].Add(-force);
                nodeForces[link.SecondNode].Add(force);
            }

            // Apply forces
            foreach (var node in nodeForces.Keys)
                node.ApplyForces(nodeForces[node]);
        }

        /// <summary>
        /// Computes the distance between two nodes.
        /// </summary>
        private float ComputeDistance(GraphNode node1, GraphNode node2)
        {
            return (float)
                Math.Sqrt
                (
                    Math.Pow(node1.transform.position.x - node2.transform.position.x, 2)
                    +
                    Math.Pow(node1.transform.position.y - node2.transform.position.y, 2)
                );
        }

        /// <summary>
        /// Computes the repulsive force against a node.
        /// </summary>
        private Vector2 ComputeRepulsiveForce(GraphNode node, GraphNode repulsiveNode)
        {
            // Compute distance
            float distance = ComputeDistance(node, repulsiveNode);
            if (distance > REPULSION_DISTANCE)
                return Vector3.zero;

            // Compute force direction
            Vector2 forceDirection = (node.transform.position - repulsiveNode.transform.position).normalized;

            // Compute distance force
            float distanceForce = (REPULSION_DISTANCE - distance) / REPULSION_DISTANCE;

            // Compute repulsive force
            return forceDirection * distanceForce * REPULSION_FORCE;
        }

        /// <summary>
        /// Computes the attraction force between two nodes.
        /// </summary>
        private Vector2 ComputeAttractionForce(GraphLink link)
        {
            // Compute force direction
            Vector2 forceDirection = (link.FirstNode.transform.position - link.SecondNode.transform.position).normalized;

            // Compute repulsive force
            return forceDirection * link.Link.Width * ATTRACTION_FORCE;
        }

        #endregion

    }
}
