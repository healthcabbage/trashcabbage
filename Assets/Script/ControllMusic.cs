using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllMusic : MonoBehaviour
{

    public Slider volum;
    public AudioSource ac;

    float backvol = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        backvol = PlayerPrefs.GetFloat("backvol");
        volum.value = backvol;
        ac.volume = volum.value;

    }

    // Update is called once per frame
    void Update()
    {
        ac.volume = volum.value;
        backvol = volum.value;
        PlayerPrefs.SetFloat("backvol", backvol);
    }
}
