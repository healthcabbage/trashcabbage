using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllMusic : MonoBehaviour
{

    public Slider volum;
    public AudioSource ac;

    public float backvol = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        volum.value = backvol;
        ac.volume = volum.value;
        //backvol = PlayerPrefs.GetFloat("backvol");
    }

    // Update is called once per frame
    void Update()
    {
        ac.volume = volum.value;
        backvol = volum.value;
        //PlayerPrefs.SetFloat("backvol", backvol);
    }
}
