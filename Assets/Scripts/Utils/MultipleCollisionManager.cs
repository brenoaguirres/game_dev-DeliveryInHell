using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CBPXL.Utils
{
    public class MultipleCollisionManager : MonoBehaviour
    {
        #region FIELDS
        private List<CollisionProvider> _providers;
        #endregion

        #region PROPERTIES
        public List<CollisionProvider> Providers { get { return _providers; } }
        #endregion

        #region EVENTS
        public Action<GameObject, Collision> ON_COLLISION_ENTER;
        public Action<GameObject, Collision> ON_COLLISION_STAY;
        public Action<GameObject, Collision> ON_COLLISION_EXIT;
        public Action<GameObject, Collider> ON_TRIGGER_ENTER;
        public Action<GameObject, Collider> ON_TRIGGER_STAY;
        public Action<GameObject, Collider> ON_TRIGGER_EXIT;
        #endregion

        #region DEFAULT METHODS
        public void Awake()
        {
            foreach (var colprovider in GetComponentsInChildren<CollisionProvider>().ToList())
            {
                _providers.Add(colprovider);
                colprovider.ON_COLLISION_ENTER += OnCollisionEnterCustom;
                colprovider.ON_COLLISION_STAY += OnCollisionStayCustom;
                colprovider.ON_COLLISION_EXIT += OnCollisionExitCustom;
                colprovider.ON_TRIGGER_ENTER += OnTriggerEnterCustom;
                colprovider.ON_TRIGGER_STAY += OnTriggerStayCustom;
                colprovider.ON_TRIGGER_EXIT += OnTriggerExitCustom;
            }
        }
        public void OnDestroy()
        {
            foreach (var colprovider in _providers)
            {
                colprovider.ON_COLLISION_ENTER -= OnCollisionEnterCustom;
                colprovider.ON_COLLISION_STAY -= OnCollisionStayCustom;
                colprovider.ON_COLLISION_EXIT -= OnCollisionExitCustom;
                colprovider.ON_TRIGGER_ENTER -= OnTriggerEnterCustom;
                colprovider.ON_TRIGGER_STAY -= OnTriggerStayCustom;
                colprovider.ON_TRIGGER_EXIT -= OnTriggerExitCustom;
            }
        }
        #endregion

        #region CUSTOM METHODS
        public void OnCollisionEnterCustom(GameObject providerInfo, Collision collisionInfo)
        {
            ON_COLLISION_ENTER?.Invoke(providerInfo, collisionInfo);
        }
        public void OnCollisionStayCustom(GameObject providerInfo, Collision collisionInfo)
        {
            ON_COLLISION_STAY?.Invoke(providerInfo, collisionInfo);
        }
        public void OnCollisionExitCustom(GameObject providerInfo, Collision collisionInfo)
        {
            ON_COLLISION_EXIT?.Invoke(providerInfo, collisionInfo);
        }
        public void OnTriggerEnterCustom(GameObject providerInfo, Collider colliderInfo)
        {
            ON_TRIGGER_ENTER?.Invoke(providerInfo, colliderInfo);
        }
        public void OnTriggerStayCustom(GameObject providerInfo, Collider colliderInfo)
        {
            ON_TRIGGER_STAY?.Invoke(providerInfo, colliderInfo);
        }
        public void OnTriggerExitCustom(GameObject providerInfo, Collider colliderInfo)
        {
            ON_TRIGGER_EXIT?.Invoke(providerInfo, colliderInfo);
        }
        #endregion
    }
}