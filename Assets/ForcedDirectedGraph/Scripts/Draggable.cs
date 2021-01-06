using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForceDirectedGraph
{
    public class Draggable : MonoBehaviour
    {

        #region Constants

        /// <summary>
        /// Force applied when dragging objects.
        /// </summary>
        private const float DRAGGING_FORCE = 20000f;

        #endregion

        #region Initialization

        /// <summary>
        /// Executes once on start.
        /// </summary>
        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// References the rigid body that handles the movements of the node.
        /// </summary>
        private Rigidbody2D Rigidbody;

        /// <summary>
        /// States whether the object is currently being dragged or not.
        /// </summary>
        public bool IsBeingDragged { private set; get; }

        #endregion

        #region Methods

        /// <summary>
        /// Starts the dragging process.
        /// </summary>
        private void OnMouseDown()
        {
            IsBeingDragged = true;
        }

        /// <summary>
        /// Stops the dragging process.
        /// </summary>
        private void OnMouseUp()
        {
            IsBeingDragged = false;
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity = 0;
        }

        /// <summary>
        /// Drags the object around.
        /// </summary>
        private void Update()
        {
            if (!IsBeingDragged)
                return;

            // Get mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);

            // Get the force vector
            Vector3 force = mousePosition - transform.position;
            force *= DRAGGING_FORCE * Time.deltaTime;

            // Apply force
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.AddForce(force);
        }

        #endregion

    }
}
