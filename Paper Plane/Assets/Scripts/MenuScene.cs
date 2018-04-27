using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour {

    private CanvasGroup fadeGroup;
    private float fadeInspeed = 0.33f;

    public RectTransform menuContainer;
    public Transform gamePanel;

    private Vector3 desiredMenuPosition;

    private void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();
        fadeGroup.alpha = 1;

        InitGamePlay();
    }

    private void Update()
    {
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInspeed;

        //menu navigation
        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);
    }
    
    private void InitGamePlay()
    {
        if (gamePanel == null) //memastikan untuk menentukan referensi
            Debug.Log("Didnt assign game panel in the inspector");

        int i = 0;
        foreach(Transform t in gamePanel)
        {
            int currentIndex = i;
            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnModeSelect(currentIndex));

            i++;
        }
    }

    private void NavigateTo(int menuIndex)
    {
        switch (menuIndex)
        {
            //main menu
            default:
            case 0:
                desiredMenuPosition = Vector3.zero;
                break;
            case 1:
                desiredMenuPosition = Vector3.left * 1280;
                break;
        }
    }

    //button
    private void OnModeSelect(int currentIndex)
    {
        Manager.Instance.currentMode = currentIndex;
        Debug.Log("selecting current index" + currentIndex);
    }

    public void OnPlayClick()
    {
        NavigateTo(1);
        Debug.Log("Bisa play");
    }

    public void OnFreeFlyClick()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Bisa fly");
    }

    public void OnChallengeClick()
    {
        Debug.Log("Bisa challenge");
    }

    public void OnPlaneClick()
    {
        Debug.Log("Bisa plane");
    }

    public void OnBackClick()
    {
        NavigateTo(0);
        Debug.Log("bisa back");
    } 
}
