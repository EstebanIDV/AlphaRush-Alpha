using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject owner;

    [SerializeField]
    private string animationName;


    [SerializeField]
    private bool specialAttack;
    public float specialCost;

    [SerializeField]
    private float minAttackMultiplier;
    [SerializeField]
    private float maxAttackMultiplier;
    [SerializeField]
    private float minDefenseMultiplier;
    [SerializeField]
    private float maxDefenseMultiplier;[SerializeField]
    private FighterStats attackerStats;
    private FighterStats targetStats;
    
    private float damage=0.0f;



    // Update is called once per frame
    public void Attack(GameObject victim)
    {
        attackerStats=owner.GetComponent<FighterStats>();
        targetStats=victim.GetComponent<FighterStats>();
        
        
        if(attackerStats.energy >= specialCost){
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
            
            damage=multiplier*attackerStats.attack;
            if(specialAttack){
                damage=multiplier*attackerStats.special;  
            }
            Debug.Log(specialCost+ "SPECIALLL");
            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0,damage-(defenseMultiplier*targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.updateEnergyFill(specialCost);
        }else{
            Invoke("skipTurnContinueGame",3);
        }
        
    }
     void skipTurnContinueGame(){
        GameObject.Find("GameControllerObj").GetComponent<TurnBasedController>().NextTurn();
    }
}
