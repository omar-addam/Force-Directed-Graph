using ForceDirectedGraph.DataStructure;
using System.Collections.Generic;
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
            GetComponentInChildren<Text>().text = node.Name;
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



        /// <summary>
        /// List of all forces to apply.
        /// </summary>
        private List<Vector2> Forces;

        #endregion

        #region Movement

        /// <summary>
        /// Apply forces to the node.
        /// </summary>
        /// <param name="applyImmediately">States whether we should apply the forces immediately or wait till the next frame.</param>
        public void ApplyForces(List<Vector2> forces, bool applyImmediately = false)
        {
            if (applyImmediately)
                foreach (var force in forces)
                    Rigidbody.AddForce(force);
            else
                Forces = forces;
        }

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

                Vector2 velocity = Vector2.zero;
                if (Forces != null)
                    foreach (var force in Forces)
                        velocity += force;

                velocity = velocity.normalized * Mathf.Clamp(velocity.magnitude, 0f, 200f);

                Rigidbody.AddForce(velocity);
            }
        }

        #endregion

    }
}
