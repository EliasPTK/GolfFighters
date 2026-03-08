using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golfball : MonoBehaviour
{
    private Rigidbody ball;
    public float mag;
    public float force = 15;

    private void Start()
    {
        ball = this.gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        mag = ball.velocity.magnitude;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "edge")
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = new Vector3(0, 0, 0) - dir.normalized;
            ball.AddForce(dir * (force * ball.velocity.magnitude));
        }
    }
}
