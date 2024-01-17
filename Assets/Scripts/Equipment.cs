using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject gunPrefab;
    public GameObject grenadePrefab;
    // Start is called before the first frame update
    public void Gun()
    {
        Instantiate(gunPrefab);
    }

    public void Grenade()
    {
        Instantiate(grenadePrefab);
    }
}
