using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerlevelScript : MonoBehaviour
{
    public Slider slider;
    public GolfScript golf;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = golf.MAXpower;
        slider.value = slider.minValue + (golf.MAXpower/2);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = golf.Power + (golf.MAXpower / 2);
    }
}
