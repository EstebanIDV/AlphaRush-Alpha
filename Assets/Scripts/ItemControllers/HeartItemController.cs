using UnityEngine;

namespace ItemControllers {
    public class HeartItemController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col) {
            PlayerController.hp += 1;
            Destroy(gameObject);
        }
    }
}
