    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer
{
    public class BulletFire : MonoBehaviour
    {
        [SerializeField]private InputManager inputManager;
        [SerializeField]private GameObject Bullet;
        [SerializeField]private Rigidbody _rb;
        [SerializeField]private float BulletForce;
        [SerializeField]private Transform Muzzle;
        [SerializeField]private ParticleSystem BulletFlash;
        

        // Start is called before the first frame update
        void Start()
        {
             _rb = Bullet.GetComponent<Rigidbody>();
        }   

        // Update is called once per frame
        void FixedUpdate()
        {
            if(inputManager.Fire) FireGun();
            
        }

        void FireGun()
        {
            GameObject instBullet = Instantiate(Bullet, Muzzle.position, Muzzle.rotation);
            _rb = instBullet.GetComponent<Rigidbody>();
            BulletFlash.Play();
            _rb.position = new Vector3(Muzzle.position.x * 0f, Muzzle.position.y, Muzzle.position.z);
            _rb.AddForce(instBullet.transform.forward * BulletForce, ForceMode.Force);
            StartCoroutine("DestroyBullets",instBullet);
        }

        IEnumerator DestroyBullets(GameObject FiredBullet)
        {
            
            yield return new WaitForSeconds(0.5f);
            Destroy(FiredBullet);
        }
    }

}
