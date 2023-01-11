using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseSkills : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject CanvasMenu;
    [SerializeField] private GameObject canvasSkill;

    public TMP_Text canvasText;

    public void increase_Health()
    {
        if(PlayerController.sp > 0){
            PlayerController.Instance.health_player += 5f;
            PlayerController.Instance.current_health_player = PlayerController.Instance.health_player;
            PlayerController.sp -= 1;
        }
        canvasText.text = PlayerController.sp.ToString();
    }
    public void increase_Energy()
    {
        if (PlayerController.sp > 0)
        {
            PlayerController.Instance.energy_player += 5f;
            PlayerController.Instance.current_energy_player =  PlayerController.Instance.energy_player;
            PlayerController.sp -= 1;
        }
        canvasText.text = PlayerController.sp.ToString();
    }
    public void increase_Attack()
    {
        if (PlayerController.sp > 0)
        {
            PlayerController.Instance.attack_player += 3f;
            PlayerController.sp -= 1;
        }
        canvasText.text = PlayerController.sp.ToString();

    }
    public void increase_Defense()
    {
        if (PlayerController.sp > 0)
        {
            PlayerController.Instance.defense_player += 0.2f;
            PlayerController.sp -= 1;
        }


    }
    public void increase_Special()
    {
        if (PlayerController.sp > 0)
        {
            PlayerController.Instance.special_player += 4f;
            PlayerController.sp -= 1;
        }
        canvasText.text = PlayerController.sp.ToString();

    }
    public void increase_Speed()
    {
         if (PlayerController.sp > 0)
            {
             PlayerController.Instance.speed_player += 3f;
             PlayerController.sp -= 1;
            }
            canvasText.text = PlayerController.sp.ToString();
    }
    public void Regresar()
    {
        botonPausa.SetActive(false);
        CanvasMenu.SetActive(true);
        canvasSkill.SetActive(false);
    }
}
