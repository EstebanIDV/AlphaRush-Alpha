using UnityEngine;

namespace ItemControllers {
    public class EnergyItemController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col) {
            PlayerController.energy += 1;
            Destroy(gameObject);
        }
        
    }
}
