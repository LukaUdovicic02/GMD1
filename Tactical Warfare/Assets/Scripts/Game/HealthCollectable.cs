using UnityEngine;

namespace Game
{
    public class HealthCollectable : MonoBehaviour , ICollectableBehaviour
    {

        [SerializeField] private int healthAmount = 20;
        
        public void OnCollected(GameObject player)
        {
            player.GetComponent<Health>().IncreaseHealth(healthAmount);
        }
    }
}