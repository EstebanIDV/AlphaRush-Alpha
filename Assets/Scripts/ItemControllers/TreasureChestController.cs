using StageControllers;
using UnityEngine;

namespace ItemControllers {
    public class TreasureChestController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col) {
            Stage1MainController.Instance.OpenGate();       
        }
    }
}
