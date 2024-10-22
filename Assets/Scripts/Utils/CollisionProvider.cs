using System;
using UnityEngine;

namespace CBPXL.Utils
{
    public class CollisionProvider : MonoBehaviour
    {
        #region EVENTS
        public Action<GameObject, Collider> ON_TRIGGER_ENTER;
        public Action<GameObject, Collider> ON_TRIGGER_STAY;
        public Action<GameObject, Collider> ON_TRIGGER_EXIT;

        public Action<GameObject, Collision> ON_COLLISION_ENTER;
        public Action<GameObject, Collision> ON_COLLISION_STAY;
        public Action<GameObject, Collision> ON_COLLISION_EXIT;
        #endregion

        #region DEFAULT METHODS
        public void OnCollisionEnter(Collision collision)
        {
            ON_COLLISION_ENTER?.Invoke(this.gameObject, collision);
        }
        public void OnCollisionStay(Collision collision)
        {
            ON_COLLISION_STAY?.Invoke(this.gameObject, collision);
        }
        public void OnCollisionExit(Collision collision)
        {
            ON_COLLISION_EXIT?.Invoke(this.gameObject, collision);
        }
        public void OnTriggerEnter(Collider other)
        {
            ON_TRIGGER_ENTER?.Invoke(this.gameObject, other);
        }
        public void OnTriggerStay(Collider other)
        {
            ON_TRIGGER_STAY?.Invoke(this.gameObject, other);
        }
        public void OnTriggerExit(Collider other)
        {
            ON_TRIGGER_EXIT?.Invoke(this.gameObject, other);
        }
        #endregion
    }
}