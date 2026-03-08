using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerchecker : MonoBehaviour
{
    public GameObject Anglechecker;
    public golfdemon demscript;
    public kartcharge kart;
    public golfWizard wiz;
    private GameObject Player;
    private RaycastHit hit;
    private float anglegolf;
    public bool PlayerMoved;
    public GameObject particle;
    public GameObject golfball;
    public GameObject golfclub;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (kart != null)
        {
            kart.enabled = false;
        }

        if (demscript != null)
        {
            demscript.enabled = false;
        }
        if (wiz != null)
        {
            wiz.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Anglechecker.transform.position, Anglechecker.transform.TransformDirection(Vector3.forward) * 50, Color.red);

        Anglechecker.transform.LookAt(Player.transform);
        if (Physics.Raycast(Anglechecker.transform.position, Anglechecker.transform.TransformDirection(Vector3.forward) * 50, out hit))
        {


            if (hit.collider == Player.GetComponent<BoxCollider>() && PlayerMoved)
            {

                if (kart != null)
                {
                    kart.enabled = true;
                }

                if (demscript != null)
                {
                    demscript.enabled = true;
                }
                if (wiz != null)
                {
                    wiz.enabled = true;
                }
                particle.SetActive(true);


            }

        }

        if (Input.GetAxis("Horizontal") > 0.2 || Input.GetAxis("Horizontal") < -0.2 || Input.GetAxis("Vertical") > 0.2 || Input.GetAxis("Vertical") < -0.2 || Input.GetMouseButtonDown(0))
        {
            PlayerMoved = true;

            if (golfclub != null)
            {
                golfclub.SetActive(false);

            }
            if(golfball != null)
            {
                golfball.SetActive(false);
            }
        }
    }
}
