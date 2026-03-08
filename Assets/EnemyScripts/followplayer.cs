using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    private bool moving = true;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Invoke("stop", 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            this.transform.position = new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z);
        }
    }
    void stop()
    {
        
           
        
            moving = false;
        Destroy(this.gameObject, 1f);

    }
}
