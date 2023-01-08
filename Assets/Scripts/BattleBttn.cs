using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleBttn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool physical;

    private GameObject Hero;
    void Start()
    {
        
        
        string temp = gameObject.name;
        Debug.Log(temp);
        gameObject.GetComponent<Button>().onClick.AddListener(()=> AttachCallback(temp));
        Hero = GameObject.FindGameObjectWithTag("Hero");
    }

    // Update is called once per frame
    private void AttachCallback(string btn){
        
        if(btn.CompareTo("MeleeBttn")== 0){
            Hero.GetComponent<FighterAction>().SelectAttack("melee");

        }else if(btn.CompareTo("SpecialBttn")== 0){
            Hero.GetComponent<FighterAction>().SelectAttack("special");

        }else if(btn.CompareTo("RunBttn")== 0){
            SceneManager.UnloadSceneAsync("TurnBased");
            Debug.Log("Battle Fled");
            //Hero.GetComponent<FighterAction>().SelectAttack("run");
        }else{
            
            Debug.Log("No sirvió");
        }
    }
}
