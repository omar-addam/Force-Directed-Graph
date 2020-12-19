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
            LineRenderer = GetComponent<LineRenderer>();

            // Set color
            LineRenderer.startColor = link.Color;
            LineRenderer.endColor = link.Color;
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
        private GraphNode FirstNode;

        /// <summary>
        /// The second graph node this entity is attached to.
        /// </summary>
        private GraphNode SecondNode;



        /// <summary>
        /// References the line renderer that displays the link.
        /// </summary>
        private LineRenderer LineRenderer;

        #endregion

    }
}
