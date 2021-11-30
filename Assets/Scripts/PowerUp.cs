using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    void Start()
    {
        Invoke("HidePowerUp", 8f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            
            this.gameObject.SetActive(false);
        }
    }

    public void HidePowerUp()
    {
        this.gameObject.SetActive(false);
    }
}