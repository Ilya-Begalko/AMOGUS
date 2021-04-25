using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spearTrigger : MonoBehaviour
{
    public GameObject spear;
    private Animation animation;

    private void Start()
    {
        animation = spear.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerSpear();
        }
    }

    void triggerSpear()
    {
        animation.Play();
        Destroy(this.gameObject);
        
    }
}