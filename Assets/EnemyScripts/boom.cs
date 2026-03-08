using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GolfScript>().HP = collision.gameObject.GetComponent<GolfScript>().HP - 2f;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
