using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
public class CannonShoot : MonoBehaviour
{
    [SerializeField]private Transform Muzzle;
    [SerializeField]private GameObject Cannon;
    [SerializeField]private float FireForce;
    [SerializeField]private Rigidbody _rb;
    [SerializeField]private ParticleSystem CannonFlash;
    private bool isFire = false;
    private bool shoot = false;
    [SerializeField]int CannonLife;

    // Start is called before the first frame update
    void Start()
    {
       Rigidbody _rb = Cannon.GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shoot) isShooting();
    }

    void isShooting()
    {
        StartCoroutine(FireCannon());
    }
    IEnumerator FireCannon()
    {
        if(isFire) yield break;
        isFire = true;
        GameObject instCannon = Instantiate(Cannon, Muzzle.position, transform.rotation);
        _rb = instCannon.GetComponent<Rigidbody>();
        _rb.AddForce(Muzzle.forward * FireForce * Time.deltaTime, ForceMode.VelocityChange);
        CannonFlash.Play(); 
        Destroy(instCannon, 2f);
        yield return new WaitForSeconds(2f);
        isFire = false;
        
    }
    void OnTriggerEnter(Collider Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            shoot = true;
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            shoot = false;
        }
    }
    void OnCollisionEnter(Collision collide)
    {
        if(collide.gameObject.tag == "PlayerFire")
        {
            CannonLife--;
            Destroy(collide.gameObject);
            if(CannonLife <= 0) Destroy(gameObject);
        }
    }
}

}
