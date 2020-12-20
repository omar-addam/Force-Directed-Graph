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

        }

        #endregion

    }
}
