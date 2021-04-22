using UnityEngine;
namespace Platformer
{
    public class InputManager : MonoBehaviour
    {
        public int Move;
        public int Jump;
        public Camera cam;
        public LayerMask MouseLayer;
        public Transform MousePointer;
        public bool Fire;

        void Start()
        {
            cam = Camera.main;
        }

        void Update()
        {
            Inputs();
            MouseInput();
        }

        public void Inputs()
        {
            if(Input.GetKey(KeyCode.R))Move = 1; else Move = 0;
            if(Input.GetKeyDown(KeyCode.W))Jump = 1; else Jump = 0;
            Fire = Input.GetKeyDown(KeyCode.Mouse0);
        }

        public void MouseInput()
        {
            Ray MousePosition = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(MousePosition, out hit, Mathf.Infinity, MouseLayer))
                {
                    MousePointer.position = hit.point;
                }
        }
    }
}
