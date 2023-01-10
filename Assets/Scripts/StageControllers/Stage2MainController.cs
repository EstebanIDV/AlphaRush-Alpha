using Cinemachine;
using UnityEngine;

namespace StageControllers {
    public class Stage2MainController : MonoBehaviour {

        
        // Start is called before the first frame update
        void Start() {
            var player = GameObject.FindGameObjectWithTag("Player");
            var camera = GameObject.FindGameObjectWithTag("VRCamera");
            
            player.transform.position = new Vector3(-1.7f, -0.5f, 0f);
            camera.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
