using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class FighterStats : MonoBehaviour, IComparable
{
    // Start is called before the first frame update
private bool dead = true;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    public GameObject healthFill;

    public string fighterName;

    [SerializeField]

    public GameObject energyFill;
    

    [Header("Stats")]


    public float health;
    public float energy;
    public float attack;
    public float defense;
    public float special;
    public float speed;
    public float experience;


    private float startHealth;
    private float startEnergy;
    
    [HideInInspector]
    public int nextActTurn;
    //Resize bars
    private Transform healthTransform;
    private Transform energyTransform;

    private Vector2 healthScale;
    private Vector2 energyScale;

    private float xNewHealthScale;
    private float xNewEnergyScale;

    private GameObject GameController;

    void Start() {
        healthTransform=healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        energyTransform = energyFill.GetComponent<RectTransform>();
        energyScale = energyTransform.localScale;

        startHealth=health;
        startEnergy=energy;

        GameController = GameObject.Find("GameControllerObj");
    }
    public void ReceiveDamage(float damage){
        health = health - damage;
        animator.Play("hurt");
         Debug.Log("Damage received:"+damage);
        if(health<=0){
            dead = true;
            gameObject.tag="Dead";
            Destroy(healthFill);
            Destroy(gameObject);
            GameController.GetComponent<TurnBasedController>().checkRemainingEnemies();

        }else if(damage>0){
            xNewHealthScale= healthScale.x * (health/startHealth);
           
            healthFill.transform.localScale=new Vector2(xNewHealthScale, healthScale.y);


        }
        GameController.GetComponent<TurnBasedController>().damageText.gameObject.SetActive(true);
        GameController.GetComponent<TurnBasedController>().damageText.text=damage.ToString();
        Invoke("continueGame",2);
    }
    public void updateEnergyFill(float cost){
        if(cost>1){
            energy=energy-cost;
            xNewEnergyScale=energyScale.x*(energy/startEnergy);
            energyFill.transform.localScale=new Vector2(xNewEnergyScale,energyScale.y);
    
        }
    }
    void continueGame(){
        GameObject.Find("GameControllerObj").GetComponent<TurnBasedController>().NextTurn();
    }

    public bool GetDead(){
        return dead;
    }

    public void CalculateNextTurn(int currentTurn){
        nextActTurn = currentTurn + Mathf.CeilToInt(100f/speed);
    }

    public int CompareTo(object otherStat){
        int nex= nextActTurn.CompareTo(((FighterStats)otherStat).nextActTurn);
        return nex;
        
    }

    
}
