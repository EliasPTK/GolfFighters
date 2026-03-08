using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public GameObject player;
    private float MAXhp;
    private float hp;
    private float decrease;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
      
    }

    // Update is called once per frame
    void Update()
    {
        hp = player.GetComponent<GolfScript>().HP;
        MAXhp = player.GetComponent<GolfScript>().maxHP;

        this.gameObject.GetComponent<Text>().text = hp.ToString() + "/" + MAXhp.ToString();
    }
}
