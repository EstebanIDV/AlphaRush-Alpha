using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleController : MonoBehaviour
{

    public static bool inBattle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerBattle(){
        inBattle=true;
        SceneManager.LoadScene("TurnBased", LoadSceneMode.Additive);

    }
}
