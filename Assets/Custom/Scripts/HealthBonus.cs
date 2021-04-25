using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerEffect>().hp < 3)
            {
                Destroy(this.gameObject);
                other.gameObject.GetComponent<PlayerEffect>().getHealth();
            }
        }
    }
}
