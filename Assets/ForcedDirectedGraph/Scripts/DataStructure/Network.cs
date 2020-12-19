using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ForceDirectedGraph.DataStructure
{
    public class Network
    {

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Network()
            : this(new List<Node>(), new List<Link>())
        {
        }

        /// <summary>
        /// Default constructor.
        /// <param name="nodes">List of all nodes in the network.</param>
        /// <param name="links">List of all links connecting the nodes.</param>
        /// </summary>
        public Network(List<Node> nodes, List<Link> links)
        {
            _Nodes = nodes;
            _Links = links;
        }

        /// <summary>
        /// Clone constructor.
        /// </summary>
        /// <param name="network">Instance to clone.</param>
        public Network(Network network)
            : this()
        {
            // Clone the nodes
            foreach (var node in network.Nodes)
                _Nodes.Add(new Node(node));

            // Clone the links
            foreach (var link in network.Links)
                _Links.Add(new Link(link));
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of all nodes in the network.
        /// </summary>
        [SerializeField]
        [Tooltip("List of all nodes in the network.")]
        private List<Node> _Nodes;

        /// <summary>
        /// List of all nodes in the network.
        /// </summary>
        public List<Node> Nodes { get { return _Nodes; } }



        /// <summary>
        /// List of all links connecting the nodes.
        /// </summary>
        [SerializeField]
        [Tooltip("List of all links connecting the nodes.")]
        private List<Link> _Links;

        /// <summary>
        /// List of all links connecting the nodes.
        /// </summary>
        public List<Link> Links { get { return _Links; } }

        #endregion

        #region Methods

        /// <summary>
        /// Displays the number of nodes and links.
        /// </summary>
        public override string ToString()
        {
            return string.Format("#Nodes: {0} | #Links: {1}", _Nodes?.Count, _Links?.Count);
        }

        #endregion

    }
}
