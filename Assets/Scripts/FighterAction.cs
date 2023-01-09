using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{

    private GameObject enemy;
    private GameObject hero;

    [SerializeField]
    private GameObject meleePrefab;

    [SerializeField]
    private GameObject rangePrefab;

    [SerializeField]
    public Sprite Icon;

    private GameObject currentAttack;
    private GameObject meleeAttack;
    private GameObject specialAttack;
    // Start is called before the first frame update
     void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("EnemyBattle");
    }


    public void SelectAttack(string btn, string enemySelected)
    {
        

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBattle");
        foreach (GameObject ienemy in enemies)
        {
            if(enemySelected.CompareTo(ienemy.transform.parent.gameObject.name)==0){
                enemy=ienemy;
                break;
            }
        }
        Debug.Log(enemy.transform.parent.gameObject.name);

        GameObject victim = tag == "Hero"? enemy: hero;


        
        switch (btn) {
             
        case "melee":
            meleePrefab.GetComponent<AttackScript>().Attack(victim);
            Debug.Log("Melee");
            break;
 
        case "special":
            rangePrefab.GetComponent<AttackScript>().Attack(victim);
            Debug.Log("Special");
            break;
 
        case "run":
            Debug.Log("Run");
            break;
        default:
            Debug.Log("Unknown");
            break;
        }
    }


}
