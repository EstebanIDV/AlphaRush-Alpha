using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject owner;

    [SerializeField]
    private string animationName;


    [SerializeField]
    private bool specialAttack;
    private float specialCost;

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
    private float xSpecialNewScale;
    private Vector2 specialScale;


    void Start()
    {
        specialScale=GameObject.Find("BikerEnergyFill").GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    public void Attack(GameObject victim)
    {
        attackerStats=owner.GetComponent<FighterStats>();
        targetStats=victim.GetComponent<FighterStats>();

        if(attackerStats.energy >= specialCost){
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
            attackerStats.updateEnergyFill(specialCost);

            damage=multiplier*attackerStats.attack;
            if(specialAttack){
                damage=multiplier*attackerStats.energy;
                attackerStats.energy -= specialCost;
            }
            float defenseMultiplier = Random.RandomRange(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0,damage-(defenseMultiplier*targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(damage);
        }
    }
}
