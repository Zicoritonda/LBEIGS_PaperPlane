using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public static Manager Instance { set; get; }

    public int currentMode = 0; //saat mengubah menu ke game scene
    public int menuFocus = 0; // untuk tau menu yang mana yg ingin difokuskan

    private Dictionary<int, Vector2> activeTouches = new Dictionary<int, Vector2>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public Vector3 GetPlayerInput()
    {
        Vector3 r = Vector3.zero;
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)//start pressing the screen
            {
                activeTouches.Add(touch.fingerId, touch.position);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                if (activeTouches.ContainsKey(touch.fingerId))
                    activeTouches.Remove(touch.fingerId);
            }
            else //saat jari kita bergerak atau tetap, menggunakan delta
            {
                float mag = 0;
                r = (touch.position - activeTouches[touch.fingerId]);
                mag = r.magnitude / 300;
                r = r.normalized * mag;
            }
        }
        return r;
    }
}
