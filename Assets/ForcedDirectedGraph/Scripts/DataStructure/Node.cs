using System;
using UnityEngine;

namespace ForceDirectedGraph.DataStructure
{
    [Serializable]
    public class Node
    {

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Node()
            : this("-")
        {
        }

        /// <summary>
        /// Minimal constructor.
        /// </summary>
        /// <param name="name">The displayed name of the node.</param>
        public Node(string name)
            : this(Guid.NewGuid(), name, Color.white)
        {
        }

        /// <summary>
        /// Default constructor.
        /// <param name="id">Unique identifier used to link nodes together.</param>
        /// <param name="name">The displayed name of the node.</param>
        /// <param name="color">The color used when representing the node.</param>
        /// </summary>
        public Node(Guid id, string name, Color color)
        {
            _Id = id;
            _Name = name;
            _Color = color;
        }

        /// <summary>
        /// Clone constructor.
        /// </summary>
        /// <param name="node">Instance to clone.</param>
        public Node(Node node)
            : this(node.Id, node.Name, node.Color)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier used to link nodes together.
        /// </summary>
        [SerializeField]
        [Tooltip("Unique identifier used to link nodes together.")]
        private Guid _Id;

        /// <summary>
        /// Unique identifier used to link nodes together.
        /// </summary>
        public Guid Id { get { return _Id; } }



        /// <summary>
        /// The displayed name of the node.
        /// </summary>
        [SerializeField]
        [Tooltip("The displayed name of the node.")]
        private string _Name;

        /// <summary>
        /// The displayed name of the node.
        /// </summary>
        public string Name { get { return _Name; } }



        /// <summary>
        /// The color used when representing the node.
        /// </summary>
        [SerializeField]
        [Tooltip("The color used when representing the node.")]
        private Color _Color;

        /// <summary>
        /// The color used when representing the node.
        /// </summary>
        public Color Color { get { return _Color; } }

        #endregion

        #region Methods

        /// <summary>
        /// Uses the id of the cluster for hash coding.
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Uses the id of the cluster for comparison.
        /// </summary>
        public override bool Equals(object obj)
        {
            Node item = obj as Node;
            return item?.Id == Id;
        }

        /// <summary>
        /// Displays the name of the node.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        #endregion

    }
}
