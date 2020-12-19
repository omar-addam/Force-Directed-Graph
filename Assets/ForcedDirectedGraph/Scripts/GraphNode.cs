using ForceDirectedGraph.DataStructure;
using UnityEngine;

namespace ForceDirectedGraph
{
    public class GraphNode : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Initializes the graph entity.
        /// </summary>
        /// <param name="node">The node being presented</param>
        public void Initialize(Node node)
        {
            _Node = node;

            // Set the color
            GetComponent<SpriteRenderer>().color = node.Color;
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// The node being presented.
        /// </summary>
        [SerializeField]
        [Tooltip("The node being presented.")]
        private Node _Node;

        /// <summary>
        /// The node being presented.
        /// </summary>
        public Node Node { get { return _Node; } }

        #endregion

    }
}
