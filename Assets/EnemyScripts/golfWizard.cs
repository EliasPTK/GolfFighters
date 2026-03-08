using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class golfWizard : MonoBehaviour
{
    public GameObject spell;
    private GameObject field;
    private GameObject currentproj;
    private GameObject Player;
    public GameObject Behind;
    private RaycastHit hit;
    private GameObject ball;
    public bool timepassed = false;
    public GameObject proj;
    public Animator anim;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {


        Player = GameObject.FindGameObjectWithTag("Player");
        ball = GameObject.FindGameObjectWithTag("GOlfball");
        Invoke("spew", 5f);
       
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
        if (Vector2.Distance(this.gameObject.transform.position, Player.gameObject.transform.position) < 12)
        {
            if (Physics.Raycast(Behind.transform.position, this.transform.TransformDirection(Vector3.back), out hit, 5))
            {
                Debug.DrawRay(Behind.transform.position, this.transform.TransformDirection(Vector3.back) * hit.distance, Color.yellow);
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = -transform.forward * speed;
                Debug.DrawRay(Behind.transform.position, Behind.transform.TransformDirection(Vector3.forward), Color.yellow);
            }
        }    
        


    }
    void spew()
    {


        GameObject field = Instantiate(spell, new Vector3(Player.transform.position.x, Player.transform.position.y - 1.2f, Player.transform.position.z), Quaternion.identity) as GameObject;
        Invoke("fall", 4f);
        field = null;





    }
    void fall()
    {
      
        Instantiate(proj, new Vector3(Player.transform.position.x, Player.transform.position.y + 10f, Player.transform.position.z), Quaternion.identity);

        Invoke("spew", 4f);
    }

   
}
