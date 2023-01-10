using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

namespace Scripts
{
    public class MenuPausa : MonoBehaviour
    {
        [SerializeField] private GameObject botonPausa;
        [SerializeField] private GameObject CanvasMenu;
        [SerializeField] private GameObject canvasSkill;

        //Text Mesh Pro Characteristics
        public TMP_Text Health_Text;



        public void Pausa()
        {
            Time.timeScale = 0f;
            botonPausa.SetActive(false);
            CanvasMenu.SetActive(true);
        }

        public void Caracteristicas()
        {
            Time.timeScale = 1f;
            botonPausa.SetActive(false);
            CanvasMenu.SetActive(false);
            canvasSkill.SetActive(true);
        }
    }
}