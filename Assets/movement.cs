using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Vector3 inputMovement;

    public Vector3 MousePosition;

    public float moveSpeed = 8f;
    public float rotatespeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        MousePosition = Input.mousePosition;

        var targetpos = transform.position + (inputMovement * (moveSpeed * Time.deltaTime));

        if (Input.GetAxis("Horizontal") > 0.2 || Input.GetAxis("Horizontal") < -0.2 || Input.GetAxis("Vertical") > 0.2 || Input.GetAxis("Vertical") < -0.2)
        {
            transform.Translate(inputMovement.normalized * Time.deltaTime * moveSpeed, Space.World);
            var rotation = Quaternion.LookRotation(inputMovement);
            transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotation, rotatespeed);
        }
      

    }
}
