using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

namespace MenuSkills
{
    public class MenuPausa : MonoBehaviour
    {
        public int prueba = 0;

        [SerializeField] private GameObject botonPausa;
        [SerializeField] private GameObject CanvasMenu;
        [SerializeField] private GameObject canvasSkill;

        public TMP_Text canvasText_SP;
        //Text Mesh Pro Characteristics
 



        public void Pausa()
        {
            prueba++;
            //;
           //Health_Text = FighterStats.health.ToString();
            Time.timeScale = 0f;
            botonPausa.SetActive(false);
            CanvasMenu.SetActive(true);
        }

        public void Caracteristicas()
        {
            prueba++;
            Time.timeScale = 1f;
            botonPausa.SetActive(false);
            CanvasMenu.SetActive(false);
            canvasSkill.SetActive(true);
        }
    }
}