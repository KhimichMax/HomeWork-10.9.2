using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringExplosion : MonoBehaviour
{
    [SerializeField] private GameObject endObj;
    [SerializeField] private GameObject springObj;
    [SerializeField] private GameObject sphereObj;
    [SerializeField] private float force;
    private Vector3 endTarget;
    private Vector3 startTarget;

    private void Start()
    {
        startTarget = springObj.transform.position;
        endTarget = endObj.transform.position;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Spring")
        {
            Debug.Log("entr");
            if (springObj.transform.position != endObj.transform.position)
            {
                springObj.transform.position = Vector3.MoveTowards(springObj.transform.position, endTarget, Time.deltaTime);
            }
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TriggerPlane")
        {
            Debug.Log("entr");
            springObj.transform.position = Vector3.MoveTowards(springObj.transform.position, endTarget, Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "TriggerPlane")
        {
            Debug.Log("exit");
            Rigidbody rb = sphereObj.GetComponent<Rigidbody>();
            Vector3 forward = new Vector3(0f, 0f, force);
            rb.AddForce(forward, ForceMode.Impulse);
            springObj.transform.position = Vector3.MoveTowards(springObj.transform.position, startTarget, Time.deltaTime);
        }
    }
    
}
