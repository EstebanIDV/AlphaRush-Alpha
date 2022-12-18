using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{

    private Animator _animator;
    void Awake(){
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void AddDamage()
    {
        _animator.SetTrigger("Died");
    }
    void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
    


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
