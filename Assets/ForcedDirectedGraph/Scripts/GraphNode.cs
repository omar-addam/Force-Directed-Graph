using ForceDirectedGraph.DataStructure;
using UnityEngine;
using UnityEngine.UI;

namespace ForceDirectedGraph
{
    public class GraphNode : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Executes once on start.
        /// </summary>
        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Draggable = GetComponent<Draggable>();

            // Freeze rotation
            Rigidbody.angularVelocity = 0;
            Rigidbody.freezeRotation = true;
        }

        /// <summary>
        /// Initializes the graph entity.
        /// </summary>
        /// <param name="node">The node being presented.</param>
        public void Initialize(Node node)
        {
            _Node = node;

            // Set the color
            GetComponent<SpriteRenderer>().color = node.Color;

            // Set name
            GetComponent<Text>().text = node.Name;
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



        /// <summary>
        /// References the rigid body that handles the movements of the node.
        /// </summary>
        private Rigidbody2D Rigidbody;

        /// <summary>
        /// References the draggable script that will notify us if the node is being dragged.
        /// </summary>
        private Draggable Draggable;

        #endregion

        #region Movement

        /// <summary>
        /// Updates the forces applied to the node.
        /// </summary>
        private void Update()
        {
            // Check if the object is being dragged
            if (Draggable.IsBeingDragged)
            {
                // Do nothing
            }

            // The object is not being dragged
            else
            {
                Rigidbody.velocity = Vector3.zero;
            }
        }

        #endregion

    }
}
