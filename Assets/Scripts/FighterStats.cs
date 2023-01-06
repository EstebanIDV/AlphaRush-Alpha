using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStats : MonoBehaviour
{
    // Start is called before the first frame update
private bool dead = true;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject healthFill;

    [SerializeField]

    private GameObject energyFill;

    [Header("Stats")]
    public float health;
    public float energy;
    public float attack;
    public float defense;
    public float range;
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

    private void Start() {
        healthTransform=healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        energyTransform = energyFill.GetComponent<RectTransform>();
        energyScale = energyTransform.localScale;

        startHealth=health;
        startEnergy=energy;
    }
    public void ReceiveDamage(float damage){
        health = health - damage;
        animator.Play("hurt");

        if(health<=0){
            dead = true;
            gameObject.tag="Dead";
            Destroy(healthFill);
            Destroy(gameObject);

        }else{
            xNewHealthScale= healthScale.x * (health/startHealth);
            healthFill.transform.localScale=new Vector2(xNewHealthScale, healthScale.y);


        }
    }
    public void updateEnergyFill(float cost){
        energy=energy-cost;
        xNewEnergyScale=energyScale.x*(energy/startEnergy);
        energyFill.transform.localScale=new Vector2(xNewEnergyScale,energyScale.y);
    }
}
