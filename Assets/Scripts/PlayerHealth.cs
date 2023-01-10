using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth=3;
    public RectTransform rt;
    private int health;
    private SpriteRenderer _renderer;
    private Animator _animator;
    // Start is called before the first frame update
    void Awake(){
        _renderer= GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {   
        
        health= totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-8){
            health=0;
            LoadScene("Lost");
        }
    }
    public void Damage(int amount){
        health=health-1;
        if(health<=0){
            health=0;
            _animator.SetTrigger("died");

        }else{
            //GameObject.Find("BattleControllerObj").GetComponent<BattleController>().StartBattle();
            //Time.timeScale = 0f;
            //Debug.Log("Player health: "+health);
           // _animator.SetTrigger("hurt");
        }
        rt.sizeDelta = new Vector2(16*health, 16);
	
    }
        public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
