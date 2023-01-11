using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TurnBasedController : MonoBehaviour
{
    public static bool attackselected;
    
    public static bool meleeselected;
    private List<FighterStats> fighterStats;
    private int energyGained=0;
    
    [SerializeField]
    private GameObject battleMenu;
    [SerializeField]
    public TextMeshProUGUI damageText;
    

    // Start is called before the first frame update
    void Start()
    {

        Invoke("newOrders",3);


        
    }
    private void newOrders(){
        fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBattle");
        foreach (GameObject ienemy in enemies)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("EnemyBattle");
            FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
            currentEnemyStats.CalculateNextTurn(0);
            fighterStats.Add(currentEnemyStats);
        }

        fighterStats.Sort();
        battleMenu.SetActive(false);
        NextTurn();

    }
    
    private void oneFighterLeft(){
        if(GameObject.FindGameObjectWithTag("Hero")!=null){
            BattleController.inBattle=false;
            BattleController.PlayerWon(energyGained);
        }else{
            BattleController.PlayerLost();
            BattleController.inBattle=false;
            Debug.Log("ACTIVE: "+SceneManager.GetActiveScene().name);
            SceneManager.UnloadSceneAsync("TurnBased");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void checkRemainingEnemies(){

        


        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBattle");
        if(enemies.Length<=0){
            GameObject startingPlayer = GameObject.FindGameObjectWithTag("Hero");
            PlayerController.Instance.current_health_player =startingPlayer.GetComponent<FighterStats>().health;
            PlayerController.Instance.current_energy_player =startingPlayer.GetComponent<FighterStats>().energy;
            BattleController.inBattle=false;
            SceneManager.UnloadSceneAsync("TurnBased");
            BattleController.PlayerWon(energyGained);
        }else if(GameObject.FindGameObjectWithTag("Hero")==null){
            BattleController.PlayerLost();
            BattleController.inBattle=false;
            SceneManager.UnloadSceneAsync("TurnBased");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void NextTurn()
    {
        Debug.Log("Checkpoing:   "+fighterStats.Count);
        /*
        if(fighterStats.Count<=1){
            oneFighterLeft();
        }
        */
        Debug.Log(fighterStats.Count);
        damageText.gameObject.SetActive(false);
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);

        if(currentFighterStats.GetDead()){
            GameObject  currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if(currentUnit.tag=="Hero"){
                this.battleMenu.SetActive(true);

            }else{
                Debug.Log("Enemy Attack!!");
                this.battleMenu.SetActive(false);
                string attackType= Random.Range(0,2)==1?"melee":"special";
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType, currentUnit.transform.parent.gameObject.name);
            }
        }else{
            NextTurn();
        }
        //if(!GameObject.FindGameObjectWithTag)
        

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
