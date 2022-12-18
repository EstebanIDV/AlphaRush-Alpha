using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Jump!!");
        }
        if(Input.GetButtonDown("Jump")){
            Debug.Log("Jump 2!!");
        }
        
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        
        if(horizontal < 0f || horizontal > 0f){
            Debug.Log("Horizontal: "+horizontal);
        }
        if(vertical < 0f || vertical > 0f){
            Debug.Log("Horizontal: "+vertical);
        }
    
    }
}
