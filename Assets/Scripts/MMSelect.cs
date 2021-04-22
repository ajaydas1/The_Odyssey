using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMSelect : MonoBehaviour
{
    float offset = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider UI)
    {
        if(UI.gameObject.tag == "UI")
        {
            Debug.Log("Collided");
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset);
        }
    }

    void OnTriggerExit(Collider UI)
    {
        if(UI.gameObject.tag == "UI")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - offset);
        }
    }
}
