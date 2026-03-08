using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public GameObject particle;
    public bool LevelComplete = false;
    // Start is called before the first frame update
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "GOlfball")
        {
            if (GameObject.FindGameObjectsWithTag("Enemey").Length == 0)
            {
                LevelComplete = true;
                particle.SetActive(true);
            }

        }
    }
}
