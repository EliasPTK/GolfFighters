using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camsystem : MonoBehaviour
{
    public GameObject CamBoss;
    public float camspeed = 1f;
    private Vector3 returntost;
    // Start is called before the first frame update
    void Start()
    {
        returntost = this.transform.position;   
    }

    // Update is called once per frame
    
     
    void Update()
    {

        transform.LookAt(CamBoss.transform);
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.right * Time.deltaTime * camspeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * Time.deltaTime * camspeed);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.transform.position = returntost;
        }
    }

}
