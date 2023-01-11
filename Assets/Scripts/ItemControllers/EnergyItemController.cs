using UnityEngine;

namespace ItemControllers {
    public class EnergyItemController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col) {
            if (!col.CompareTag("Player")) return;
            if (PlayerController.Instance.current_energy_player + 5 > PlayerController.Instance.energy_player) {
                PlayerController.Instance.current_energy_player = PlayerController.Instance.energy_player;
            }
            else {
                PlayerController.Instance.current_energy_player += 5;
            }

            Destroy(gameObject);
        }
        
    }
}
