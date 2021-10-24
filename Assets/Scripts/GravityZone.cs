using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("IN THAT ZONE");
        GameObject obj = other.gameObject;
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        if (obj.CompareTag("CueBall") || obj.CompareTag("Yellow") ||
            obj.CompareTag("Red") || obj.CompareTag("Black"))
        {
            rb.constraints = RigidbodyConstraints.None;
            obj.GetComponent<SphereCollider>().material.bounciness = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("SORTIS DE LA ZONE");
        GameObject obj = other.gameObject;
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        if (obj.CompareTag("CueBall") || obj.CompareTag("Yellow") ||
            obj.CompareTag("Red") || obj.CompareTag("Black"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            obj.GetComponent<SphereCollider>().material.bounciness = 0.9f;
        }
    }
}
