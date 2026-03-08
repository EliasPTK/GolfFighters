using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj : MonoBehaviour
{
    public float movementSpeed;
   
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
}
