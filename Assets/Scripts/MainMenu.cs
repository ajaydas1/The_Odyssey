using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]LevelManager Manager;
    [SerializeField]Transform MousePointer;
    Camera Cam;
    [SerializeField]LayerMask WhatIsUI;
    Vector3 Play_offset = new Vector3(3f,3f,2f);
    Vector3 Exit_offset = new Vector3(3f,3f,2f);
    [SerializeField]Vector3 offset = new Vector3(4f,4f,2f);
    [SerializeField]Transform PlayButton, ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();   
        PlayButton.localScale = Play_offset;
        ExitButton.localScale = Exit_offset;
    }

    void MouseInput()
        {
            Ray MousePosition = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(MousePosition, out hit, Mathf.Infinity, WhatIsUI))
                {
                    MousePointer.position = hit.point;
                    
                    Debug.Log(hit.transform.name);
                    if(hit.transform.name == "Mouse") Play_offset = new Vector3(3f,3f,2f); Exit_offset = new Vector3(3f,3f,2f);
                    if(hit.transform.name == "Play")
                    {
                         Play_offset = offset;
                         if(Input.GetKeyDown(KeyCode.Mouse0))Manager.Play();
                    }
                    if(hit.transform.name == "Exit")
                    {
                         Exit_offset = offset;
                         if(Input.GetKeyDown(KeyCode.Mouse0))Manager.Quit();
                    }
                   
                }
        }
}
