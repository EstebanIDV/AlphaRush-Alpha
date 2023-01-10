using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BattleController : MonoBehaviour
{
    
    public GameObject infoPrefab;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public static bool inBattle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartBattle(){
        StartCoroutine(TriggerBattle());
    }

    public void setEnemy(int slot, GameObject newEnemy){
        GameObject enemyPosition;
        GameObject enemyInfo; 
        switch (slot) {
            case 2:
                enemyPosition = GameObject.Find("Position2");
                enemyInfo = GameObject.Find("EnemyInfo2");
            break;
            case 3:
                enemyPosition = GameObject.Find("Position3");
                enemyInfo = GameObject.Find("EnemyInfo3");
            break;
            default:
                enemyPosition = GameObject.Find("Position1");
                enemyInfo = GameObject.Find("EnemyInfo1");
            break;

        }
        GameObject Enemy = Instantiate (newEnemy) as GameObject;
        GameObject Info = Instantiate (infoPrefab) as GameObject;

        Enemy.transform.SetParent(enemyPosition.transform);
        Enemy.transform.localPosition = Vector3.zero;   
        Enemy.GetComponent<FighterStats>().healthFill = Info.transform.Find("HealthBar/HealthFill").gameObject;
        Enemy.GetComponent<FighterStats>().energyFill = Info.transform.Find("EnergyBar/EnergyFill").gameObject;
        
        

        Info.transform.SetParent(enemyInfo.transform);
        Info.transform.localPosition = Vector3.zero;   
        Info.transform.localScale = new Vector3(1f,1f,1f);   
        Info.transform.Find("Portrait/EnemyPortrait").GetComponent<Image>().sprite = Enemy.GetComponent<FighterAction>().Icon;
        Info.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = Enemy.GetComponent<FighterStats>().fighterName;
        

    }


    public IEnumerator TriggerBattle(){
        inBattle=true;
        Scene originalScene = SceneManager.GetActiveScene();
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync("TurnBased", LoadSceneMode.Additive);
        while (!sceneLoad.isDone)
        {
            yield return null;

        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TurnBased"));
        setEnemy(1, enemyPrefab1);

        if(enemyPrefab2!=null){
            setEnemy(1, enemyPrefab1);
        }
        if(enemyPrefab3!=null){

        }

        
        SceneManager.SetActiveScene(originalScene);
        
    }
}