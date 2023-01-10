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
    private bool attackselected=false;
    private bool meleeSelected;

    private GameObject Hero;
    void Start()
    {
        
        
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(()=> AttachCallback(temp, gameObject));
        Hero = GameObject.FindGameObjectWithTag("Hero");
    }

    void turnOnIndicators(bool indicatorState){
        GameObject uiPanel = transform.parent.parent.parent.gameObject;
         
        Transform currentIndicator =uiPanel.transform.Find("EnemyInfo1/EnemyInfo(Clone)/Indicator");

        if(currentIndicator!=null){
            currentIndicator.gameObject.SetActive(indicatorState);
        }
        currentIndicator =uiPanel.transform.Find("EnemyInfo2/EnemyInfo(Clone)/Indicator");
        if(currentIndicator!=null){
            currentIndicator.gameObject.SetActive(indicatorState);
        }
        currentIndicator =uiPanel.transform.Find("EnemyInfo3/EnemyInfo(Clone)/Indicator");
        if(currentIndicator!=null){
            currentIndicator.gameObject.SetActive(indicatorState);
        }
    }


    // Update is called once per frame
    private void AttachCallback(string btn, GameObject btnPressed){
        if(attackselected){
             if(btn.CompareTo("MeleeBttn")== 0 || btn.CompareTo("SpecialBttn")== 0){
                attackselected=false;
                turnOnIndicators(false);

            }
            else if(btn.CompareTo("Indicator")== 0){
                switch(btnPressed.transform.parent.parent.gameObject.name){
                    case "EnemyInfo1":
                        if(meleeSelected){
                            Hero.GetComponent<FighterAction>().SelectAttack("melee","Position1");
                        }else{
                            Hero.GetComponent<FighterAction>().SelectAttack("special","Position1");
                        }
                        break;
                        case "EnemyInfo2":
                        if(meleeSelected){
                            Hero.GetComponent<FighterAction>().SelectAttack("melee","Position2");
                        }else{
                            Hero.GetComponent<FighterAction>().SelectAttack("special","Position2");
                        }
                        break;
                        case "EnemyInfo3":
                        if(meleeSelected){
                            Hero.GetComponent<FighterAction>().SelectAttack("melee","Position3");
                        }else{
                            Hero.GetComponent<FighterAction>().SelectAttack("special","Position3");
                        }
                        break;
                }

            }
            else if(btn.CompareTo("RunBttn")== 0){
                BattleController.inBattle=false;
                SceneManager.UnloadSceneAsync("TurnBased");
                Debug.Log("Battle Fled");
            }else{
                
                Debug.Log("No sirvió");
            }
        }else{
            if(btn.CompareTo("MeleeBttn")== 0){
                meleeSelected=true;
                attackselected=true;
                turnOnIndicators(true);
                //showindicators

            }else if(btn.CompareTo("SpecialBttn")== 0){
                meleeSelected=false;
                attackselected=true;
                turnOnIndicators(true);
            }
            else if(btn.CompareTo("Indicator")== 0){
                switch(btnPressed.transform.parent.parent.gameObject.name){
                    case "EnemyInfo1":
                        if(meleeSelected){
                            Hero.GetComponent<FighterAction>().SelectAttack("melee","Position1");
                        }else{
                            Hero.GetComponent<FighterAction>().SelectAttack("special","Position1");
                        }
                        break;
                        case "EnemyInfo2":
                        if(meleeSelected){
                            Hero.GetComponent<FighterAction>().SelectAttack("melee","Position2");
                        }else{
                            Hero.GetComponent<FighterAction>().SelectAttack("special","Position2");
                        }
                        break;
                        case "EnemyInfo3":
                        if(meleeSelected){
                            Hero.GetComponent<FighterAction>().SelectAttack("melee","Position3");
                        }else{
                            Hero.GetComponent<FighterAction>().SelectAttack("special","Position3");
                        }
                        break;
                }
                turnOnIndicators(true);
                attackselected=false;

            }
            else if(btn.CompareTo("RunBttn")== 0){
                BattleController.inBattle=false;
                SceneManager.UnloadSceneAsync("TurnBased");
                Debug.Log("Battle Fled");
                //Hero.GetComponent<FighterAction>().SelectAttack("run");
            }else{
                
                Debug.Log("No sirvió");
            }
        }
    }
}
