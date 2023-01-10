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
            PlayerController.Instance.health_player += 20;
            PlayerController.sp -= 1;
        }
        canvasText.text = PlayerController.sp.ToString();
    }
    public void increase_Energy()
    {
        if (PlayerController.sp > 0)
        {
            PlayerController.Instance.energy_player += 20;
            PlayerController.sp -= 1;
        }
        canvasText.text = PlayerController.sp.ToString();
    }
    public void increase_Attack()
    {
        if (PlayerController.sp > 0)
        {
            PlayerController.Instance.attack_player += 20;
            PlayerController.sp -= 1;
        }
        canvasText.text = PlayerController.sp.ToString();

    }
    public void increase_Defense()
    {
        if (PlayerController.sp > 0)
        {
            PlayerController.Instance.defense_player += 20;
            PlayerController.sp -= 1;
        }


    }
    public void increase_Special()
    {
        if (PlayerController.sp > 0)
        {
            PlayerController.Instance.special_player += 20;
            PlayerController.sp -= 1;
        }
        canvasText.text = PlayerController.sp.ToString();

    }
    public void increase_Speed()
    {

    }
    public void Regresar()
    {
        botonPausa.SetActive(false);
        CanvasMenu.SetActive(true);
        canvasSkill.SetActive(false);
    }
}
