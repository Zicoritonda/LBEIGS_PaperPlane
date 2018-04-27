using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour {


    public float speed = 90.0f;

    // Use this for initialization
    void Start () {
        Debug.Log("plane pilot script added to:" + gameObject.name);

        

        
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 moveCamTo = transform.position - transform.forward * 0.5f + Vector3.up * 2.5f;
        float bias = 0.96f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias);
        
        Camera.main.transform.LookAt(transform.position + transform.forward * 0.5f);

        transform.position += transform.forward * Time.deltaTime * 25.0f;

        speed -= transform.forward.y * Time.deltaTime * 12.0f;

        if(speed < 5.0f)
        {
            speed = 5.0f;
        }
        
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);

        if(terrainHeight > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }
	}
}
