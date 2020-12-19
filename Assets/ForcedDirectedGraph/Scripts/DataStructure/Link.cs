using System;
using UnityEngine;

namespace ForceDirectedGraph.DataStructure
{
    [Serializable]
    public class Link
    {

        #region Constructors

        /// <summary>
        /// Minimal constructor.
        /// </summary>
        /// <param name="firstNodeId">The first node connected to the edge of the link.</param>
        /// <param name="secondNodeId">The second node connected to the edge of the link.</param>
        public Link(Guid firstNodeId, Guid secondNodeId)
            : this(firstNodeId, secondNodeId, 0.5f, Color.white)
        {
        }

        /// <summary>
        /// Default constructor.
        /// <param name="firstNodeId">The first node connected to the edge of the link.</param>
        /// <param name="secondNodeId">The second node connected to the edge of the link.</param>
        /// <param name="width">Normalized width of the link [0-1].</param>
        /// <param name="color">The color used when representing the link.</param>
        /// </summary>
        public Link(Guid firstNodeId, Guid secondNodeId, float width, Color color)
        {
            _FirstNodeId = firstNodeId;
            _SecondNodeId = secondNodeId;
            _Width = width;
            _Color = color;
        }

        /// <summary>
        /// Clone constructor.
        /// </summary>
        /// <param name="link">Instance to clone.</param>
        public Link(Link link)
            : this(link.FirstNodeId, link.SecondNodeId, link.Width, link.Color)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// The first node connected to the edge of the link.
        /// </summary>
        [SerializeField]
        [Tooltip("The first node connected to the edge of the link.")]
        private Guid _FirstNodeId;

        /// <summary>
        /// The first node connected to the edge of the link.
        /// </summary>
        public Guid FirstNodeId { get { return _FirstNodeId; } }



        /// <summary>
        /// The second node connected to the edge of the link.
        /// </summary>
        [SerializeField]
        [Tooltip("The second node connected to the edge of the link.")]
        private Guid _SecondNodeId;

        /// <summary>
        /// The second node connected to the edge of the link.
        /// </summary>
        public Guid SecondNodeId { get { return _SecondNodeId; } }



        /// <summary>
        /// Normalized width of the link [0-1].
        /// </summary>
        [SerializeField]
        [Tooltip("Normalized width of the link [0-1].")]
        private float _Width;

        /// <summary>
        /// Normalized width of the link [0-1].
        /// </summary>
        public float Width { get { return _Width; } }



        /// <summary>
        /// The color used when representing the link.
        /// </summary>
        [SerializeField]
        [Tooltip("The color used when representing the link.")]
        private Color _Color;

        /// <summary>
        /// The color used when representing the link.
        /// </summary>
        public Color Color { get { return _Color; } }

        #endregion

    }
}
