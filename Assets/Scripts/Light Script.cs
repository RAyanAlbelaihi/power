using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    Light MyLight;

    void Start()
    {
        MyLight = GetComponent<Light>();

        // Set the initial state of the light (either on or off)
        MyLight.enabled = true; // or false if you want it initially off

        // Call the ToggleLight function every 1 second starting from the beginning
        InvokeRepeating("ToggleLight", 0f, 1f);
    }

    // Function to toggle the light state
    void ToggleLight()
    {
        MyLight.enabled = !MyLight.enabled;
    }
}
