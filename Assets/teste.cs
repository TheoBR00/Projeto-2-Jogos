using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionStay(Collision collision)
    {
        print("2aaaa");
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
     }

     void OnTriggerEnter(Collider other)
    {
                print("2bbbbbb");

    }


}
