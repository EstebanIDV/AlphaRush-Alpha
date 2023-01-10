using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSkills : MonoBehaviour
{
    public void increase_Health()
    {
        if(PlayerController.sp > 0){
            FighterStats.Instance.aumentar_health(20);
            PlayerController.sp -= 1;
        }

    }
    public void increase_Energy()
    {
        if (PlayerController.sp > 0)
        {
            FighterStats.Instance.energy += 20;
            PlayerController.sp -= 1;
        }
    }
    public void increase_Attack()
    {
        if (PlayerController.sp > 0)
        {
            FighterStats.Instance.attack += 20;
            PlayerController.sp -= 1;
        }

    }
    public void increase_Defense()
    {
        if (PlayerController.sp > 0)
        {
            FighterStats.Instance.defense += 20;
            PlayerController.sp -= 1;
        }

    }
    public void increase_Special()
    {
        if (PlayerController.sp > 0)
        {
            FighterStats.Instance.special += 20;
            PlayerController.sp -= 1;
        }

    }
    public void increase_Speed()
    {

    }
    public void Regresar()
    {

    }
}
