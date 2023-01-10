using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class StageController : MonoBehaviour
{
    // Start is called before the first frame update
    public float x;
    public float y;
    
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var camera = GameObject.FindGameObjectWithTag("VRCamera");
            
        player.transform.position = new Vector3(x, y, 0f);
        camera.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
