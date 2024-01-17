using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTeleport : MonoBehaviour
{
    public void HouseTele()
        {
            SceneManager.LoadScene("HouseScene");
        }
    public void MarketTele()
    {
        SceneManager.LoadScene("MarketScene");
    }
    public void OfficeTele()
    {
        SceneManager.LoadScene("OfficeScene");
    }
    public void cafeTele()
    {
        SceneManager.LoadScene("CafeScene");
    }
}
