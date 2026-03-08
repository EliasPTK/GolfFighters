using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GolfScript : MonoBehaviour
{
    public LineRenderer line;
    public float HP;
    public float maxHP;
    public float numbersofshots = 0f;
    public GameObject Golfball;
    public GameObject golfchecker;
    public float anglegolf;
    public bool lookinatball;
    public bool nearball;
    public bool readytogolf;
    public Vector3 angle;
    public float Power = 0f;
    public float MAXpower = 8f;
    public float powercharge = 0.25f;
    public float velocity;
    public float damage;
    public float damagemulti;
    public Vector3 direction;
    public float damagedecrease;
   
    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;   
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Golfball.GetComponent<Rigidbody>().velocity.magnitude;
        golfchecker.transform.LookAt(Golfball.transform);
        anglegolf = (golfchecker.transform.rotation.y - this.transform.rotation.y);
        if (Mathf.Abs(anglegolf) < 0.3)
        {
            lookinatball = true;
        }
        else
        {
            lookinatball = false;
        }
        if(Vector3.Distance(Golfball.transform.position, this.transform.position) < 3)
        {
            nearball = true;
        }
        else
        {
            nearball = false;

        }
        if(nearball && lookinatball)
        {
            readytogolf = true;
        }
        else
        {
            readytogolf = false;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit mousepos))
        {
            angle = mousepos.point - Golfball.transform.position;
            var distance = angle.magnitude;
             direction = angle / distance;
        }
        if (Input.GetMouseButton(0) && readytogolf)
        {
            Debug.DrawRay(Golfball.transform.position, direction * Power/2, Color.red);
              line.SetPosition(0, Golfball.transform.position);
                line.SetPosition(1, (Golfball.transform.position + direction * (Power/3)));
            
            if (Power < MAXpower)
            {
                Power = Power + (powercharge * Time.deltaTime);
            }
            else
            {
                Power = 0f;
            }

           
        }
        else if (Input.GetMouseButtonUp(0) && readytogolf == true && Power > 0)
        {
            Golfball.GetComponent<Rigidbody>().velocity = direction * (Power * 2);
            damage = Power;
            Power = 0;
            numbersofshots = numbersofshots + 1;
            Invoke("golfstop", 2f);
            line.SetPosition(0,new Vector3(0, 0, 0));
            line.SetPosition(1, new Vector3(0, 0, 0));
        }
        if (damage >= 0)
        {
            damage = damage - (damagedecrease * Time.deltaTime);

        }
        else
        {
            damage = 0;
        }
        if(HP <= 0)
        {
            Destroy(this);
            Destroy(this.gameObject.GetComponent<movement>());
        }

        Color currentLineColor = Color.Lerp(Color.yellow, Color.red, (Power/MAXpower));
        line.startColor = currentLineColor;
        line.endColor = currentLineColor;

        if(readytogolf == false)
        {
            Power = 0;
            line.SetPosition(0, new Vector3(0, 0, 0));
            line.SetPosition(1, new Vector3(0, 0, 0));
        }

    }
    void golfstop()
    {
        Golfball.GetComponent<Rigidbody>().velocity = Golfball.GetComponent<Rigidbody>().velocity * 0.5f;
        if (Golfball.GetComponent<Rigidbody>().velocity.magnitude > 0.3)
        {
            Invoke("golfstop", 0.5f);

        }
        else
        {
            Golfball.GetComponent<Rigidbody>().velocity = Golfball.GetComponent<Rigidbody>().velocity * 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hurt")
        {
            HP = HP - 1;
        }
    }
}
