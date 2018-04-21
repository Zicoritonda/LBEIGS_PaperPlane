using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour {
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumLogoTime = 3.0f; //Waktu minimum untuk memuat scene

    private void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>(); //mencari canvasgroup
        fadeGroup.alpha = 1; //layar putih
        if (Time.time < minimumLogoTime) //jika ketika load game kurang dari 3 detik
        {
            loadTime = minimumLogoTime;
        }
        else
            loadTime = Time.time;
    }

    private void Update()
    {
        if(Time.time < minimumLogoTime) //fade in
        {
            fadeGroup.alpha = 1 - Time.time;
        }
        if(Time.time > minimumLogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimumLogoTime;
            if(fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
