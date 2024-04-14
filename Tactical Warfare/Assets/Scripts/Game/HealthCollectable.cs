using UnityEngine;

namespace Game
{
    public class HealthCollectable : MonoBehaviour , ICollectableBehaviour
    {

        [SerializeField] private int healthAmount = 20;
        
        public void OnCollected(GameObject player)
        {
            Debug.Log("Test2");
            player.GetComponent<Health>().IncreaseHealth(healthAmount);
        }
    }
}