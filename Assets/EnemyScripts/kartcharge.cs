using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kartcharge : MonoBehaviour
{
    private GameObject Player;
    private GameObject ball;
    public bool timepassed = false;
    public Animator anim;
    public float inbtwntime;
    public float speed;
    private Rigidbody thus;
    public bool chargin;
    // Start is called before the first frame update
    void Start()
    {

        thus = this.gameObject.GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
        ball = GameObject.FindGameObjectWithTag("GOlfball");
        StartCoroutine("chase");


    }

    // Update is called once per frame
    void Update()
    {
        if (timepassed == false)
        {
            transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
        }
        if( chargin == true)
        {
            thus.velocity = transform.forward * speed;
        }


    }
   

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "edge")
        {
            if(chargin == true)
            {
                chargin = false;
                timepassed = false;
            }
        }
        if(collision.gameObject == Player)
        {
            Player.GetComponent<GolfScript>().HP = Player.GetComponent<GolfScript>().HP - 1;
        }
    }

    private IEnumerator chase()
    {
        yield return new WaitForSeconds(1f);
        timepassed = true;
        chargin = true;
        yield return new WaitForSeconds(1f);

        chargin = false;
        timepassed = false;
        yield return new WaitForSeconds(inbtwntime);
        StartCoroutine("chase");

    }
}