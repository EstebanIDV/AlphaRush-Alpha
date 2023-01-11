using UnityEngine;

namespace ItemControllers {
    public class HeartItemController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col) {
            if (!col.CompareTag("Player")) return;
            if (PlayerController.Instance.current_health_player + 5 > PlayerController.Instance.health_player) {
                PlayerController.Instance.current_health_player = PlayerController.Instance.health_player;
            }
            else {
                PlayerController.Instance.current_health_player += 5;
            }

            Destroy(gameObject);
        }
    }
}
