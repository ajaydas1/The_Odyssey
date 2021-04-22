using UnityEngine;

namespace Platformer
{
        public class PlayerController : MonoBehaviour
    {
       [SerializeField]private InputManager inputManager;
       private Animator animate;
       private CharacterController character;
       [SerializeField]private float PlayerSpeed = 20f;
       [SerializeField]private float JumpForce = 40f;
       [SerializeField]private float jump = 0f;
       [SerializeField]private float gravity = -2f;
       [SerializeField] Vector3 Movement;
       [SerializeField] Transform GroundCheck;
       [SerializeField]private int ExtraJumps = 1;
       private int ExtraJumpValues;
       private int PlayerLife;

       [SerializeField]private Transform target;

       void Start()
       {
            ExtraJumpValues = ExtraJumps;
            character = GetComponent<CharacterController>();
            animate = GetComponent<Animator>();
       }

        void Update()
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
            if(inputManager.Move != 0)animate.SetBool("isRunning", true);
            if(inputManager.Move == 0)animate.SetBool("isRunning", false);
            if(inputManager.Jump == 1)animate.SetBool("isJumping", true);
            if(inputManager.Jump == 0 && isGrounded())animate.SetBool("isJumping", false);           
        }

       void FixedUpdate ()
       {
           
           
           Run();
           Jump();
           PlayerRotation();
       }

       void PlayerRotation()
       {


           Vector3 mouseInputPosition = inputManager.MousePointer.position;

           Vector3 PlayerRotation = mouseInputPosition - transform.position;

           if(PlayerRotation.z > 0)
           {
               transform.rotation = Quaternion.Euler(0f, 0f, 0f);
               //animate.SetFloat("PlayerRotation", 1f * inputManager.Move);
           }

           if(PlayerRotation.z < 0)
           {
               transform.rotation = Quaternion.Euler(0f, 180f, 0f);
               //animate.SetFloat("PlayerRotation", -1f * inputManager.Move);
           }
       }

       void Run()
       {
           float Running = inputManager.Move * PlayerSpeed * Time.deltaTime;
           Movement = new Vector3(0f,jump,Running * transform.forward.z);

           character.Move(Movement);
           //if(inputManager.Move == 0) animate.SetFloat("Run", 0f);
           //if(inputManager.Move > 0) animate.SetFloat("Run", inputManager.Move);    
       }

       void Jump()
       {
           if(isGrounded())
           {
                ExtraJumpValues = ExtraJumps;
                jump = inputManager.Jump * JumpForce * Time.deltaTime;
           }
           else
           {
              if(inputManager.Jump == 1 && ExtraJumpValues > 0)
                {
               jump = inputManager.Jump * JumpForce * Time.deltaTime;
               ExtraJumpValues--;
                }
             else{
               jump += gravity * Time.deltaTime;
             }

           }
       }

       bool isGrounded()
       {

           RaycastHit hit;
           bool HitCheck = Physics.Raycast(GroundCheck.position, -Vector3.up,out hit, 0.2f);
           return HitCheck;
       }

       void OnAnimatorIK()
       {
           
           //Vector3 goalPosition = new Vector3(inputManager.MousePointer.position.x, inputManager.MousePointer.position.y, inputManager.MousePointer.position.z);
           animate.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
           animate.SetIKPosition(AvatarIKGoal.RightHand, inputManager.MousePointer.position);
           //animate.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
           //animate.SetIKRotation(AvatarIKGoal.RightHand, goalRotation);
           animate.SetLookAtWeight(1f);
           animate.SetLookAtPosition(inputManager.MousePointer.position);
       }

       void OnCollisionEnter(Collision collide)
       {
           if(collide.gameObject.tag == "Destroyables")
           {
               PlayerLife--;
               Destroy(collide.gameObject);
               if(PlayerLife <= 0) Destroy(gameObject);
           }
       }
    }
}
