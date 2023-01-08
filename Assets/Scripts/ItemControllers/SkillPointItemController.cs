using UnityEngine;

namespace ItemControllers {
    public class SkillPointItemController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col) {
            PlayerController.sp += 1;
            Destroy(gameObject);
        }
    }
}
