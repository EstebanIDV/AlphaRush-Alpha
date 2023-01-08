using UnityEngine;

namespace StageControllers {
    public class Stage1MainController : MonoBehaviour
    {

        public static Stage1MainController Instance { get; private set; }
        private void Awake() 
        { 
            // If there is an instance, and it's not me, delete myself.
    
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
        }
    

        public void OpenGate() {
            Debug.Log("Hola");
        }
    }
}
