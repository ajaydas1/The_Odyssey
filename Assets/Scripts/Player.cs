using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
public class Player : MonoBehaviour
{
    [SerializeField]private Rigidbody _rb;
    //[SerializeField]private InputManager inputManager;
    [SerializeField]private float MoveVelocity = 200;
    [SerializeField]private float JumpForce = 200;
    private float move;
    private int jump;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
       
    }
    // Update is called once per frame
    void Update()
    {
         move = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.W)) jump = 1;else jump = 0;
    }

    void FixedUpdate()
    {
        _rb.AddForce(transform.right * MoveVelocity * move * Time.deltaTime, ForceMode.VelocityChange );
        _rb.AddForce(transform.up * JumpForce * jump * Time.deltaTime, ForceMode.VelocityChange );
    }

}
}
