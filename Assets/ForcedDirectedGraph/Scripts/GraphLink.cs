using ForceDirectedGraph.DataStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForceDirectedGraph
{
    public class GraphLink : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Executes once on start.
        /// </summary>
        private void Awake()
        {
            LineRenderer = GetComponent<LineRenderer>();
        }

        /// <summary>
        /// Initializes the graph entity.
        /// </summary>
        /// <param name="link">The link being presented.</param>
        /// <param name="firstNode">The first graph node this entity is attached to.</param>
        /// <param name="secondNode">The second graph node this entity is attached to.</param>
        public void Initialize(Link link, GraphNode firstNode, GraphNode secondNode)
        {
            _Link = link;
            FirstNode = firstNode;
            SecondNode = secondNode;

            // Set color
            LineRenderer.startColor = link.Color;
            LineRenderer.endColor = link.Color;

            // Set width
            float width = link.Width == 0 ? 0 : link.Width * 0.08f + 0.02f; // [0.02 -> 0.1]
            LineRenderer.startWidth = width;
            LineRenderer.endWidth = width;
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// The link being presented.
        /// </summary>
        [SerializeField]
        [Tooltip("The link being presented.")]
        private Link _Link;

        /// <summary>
        /// The link being presented.
        /// </summary>
        public Link Link { get { return _Link; } }



        /// <summary>
        /// The first graph node this entity is attached to.
        /// </summary>
        [SerializeField]
        private GraphNode FirstNode;

        /// <summary>
        /// The second graph node this entity is attached to.
        /// </summary>
        [SerializeField]
        private GraphNode SecondNode;



        /// <summary>
        /// References the line renderer that displays the link.
        /// </summary>
        private LineRenderer LineRenderer;

        #endregion

        #region Methods

        /// <summary>
        /// Update the line to keep the two nodes connected.
        /// </summary>
        private void Update()
        {
            LineRenderer.useWorldSpace = true;
            LineRenderer.SetPosition(0, FirstNode.transform.position);
            LineRenderer.SetPosition(1, SecondNode.transform.position);
        }

        #endregion

    }
}
