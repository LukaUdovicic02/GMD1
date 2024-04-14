    using UnityEngine;

    namespace Game
    {
        public interface ICollectableBehaviour
        {
            void OnCollected(GameObject player);
        }
    }