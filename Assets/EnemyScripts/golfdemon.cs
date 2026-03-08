using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golfdemon : MonoBehaviour
{
    private GameObject Player;
    private GameObject ball;
    public bool timepassed = false;
    public GameObject proj;
  public  Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       
      
        Player = GameObject.FindGameObjectWithTag("Player");
        ball = GameObject.FindGameObjectWithTag("GOlfball");
        Invoke("spew", 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timepassed == false)
        {
            transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
        }

      
    }
    void spew()
    {
        anim.SetBool("attacin", true);
        timepassed = true;
        if (timepassed == true) { 
        Instantiate(proj, (new Vector3(this.transform.position.x, this.transform.position.y + 1.2f, this.transform.position.z)), this.transform.rotation);
            timepassed = false;
    }
       
        Invoke("spew", 4f);
        anim.SetBool("attacin", false);



    }

    
}
