using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnBasedController : MonoBehaviour
{
    private List<FighterStats> fighterStats;
    
    [SerializeField]
    private GameObject battleMenu;
    [SerializeField]
    public TextMeshProUGUI damageText;
    

    // Start is called before the first frame update
    void Start()
    {
        fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);



        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyBattle");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);


        fighterStats.Sort();
        battleMenu.SetActive(false);


        NextTurn();


        
    }
    
    public void NextTurn()
    {
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
