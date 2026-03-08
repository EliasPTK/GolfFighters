using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golferanim : MonoBehaviour
{
    public Animator anim;
    public bool walkin;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.2 || Input.GetAxis("Horizontal") < -0.2 || Input.GetAxis("Vertical") > 0.2 || Input.GetAxis("Vertical") < -0.2)
        {
            anim.SetBool("walkin", true);
            walkin = true;
        }
        else
        {
            anim.SetBool("walkin", false);
            walkin = false;
        }

    }
}
