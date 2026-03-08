using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HP = 20f;
    private GameObject Player;
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ball = GameObject.FindGameObjectWithTag("GOlfball");
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GOlfball")
        {
            HP = HP - Player.gameObject.GetComponent<GolfScript>().damage;
            if (HP <= 0)
            {
                Object.Destroy(this.gameObject);
            }
            ball.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(ball.gameObject.GetComponent<Rigidbody>().velocity.x / 2, ball.gameObject.GetComponent<Rigidbody>().velocity.y / 2, ball.gameObject.GetComponent<Rigidbody>().velocity.z / 2);
        }
    }
}
