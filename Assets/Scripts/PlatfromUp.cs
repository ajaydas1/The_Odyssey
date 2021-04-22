using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatfromUp : MonoBehaviour
{
    [SerializeField]Transform targetPosition;
    [SerializeField]Transform StartPosition;
    [SerializeField]CharacterController controller;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= targetPosition.position.y) StartCoroutine("GameOver");
        
    }
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            Debug.Log("CollisonDetected");
            controller = collide.GetComponent<CharacterController>();
        }

    }

    void OnTriggerStay(Collider collide)
    {
        
        if(collide.gameObject.tag == "Player")
        {
            //Debug.Log("LiftTriggered");
            if(transform.position.y < targetPosition.position.y)
            {
                transform.Translate(Vector3.forward * 4 * Time.deltaTime);       
            }
        }
    }
    
    void OnTriggerExit(Collider collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            if(transform.position.y < targetPosition.position.y && collide.transform.position.y < transform.position.y)
            {
                transform.position = StartPosition.position;
            }
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

}
