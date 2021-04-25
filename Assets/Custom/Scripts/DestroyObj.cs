using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject pl;
    public float rangeDestroy = 50f;
    // Start is called before the first frame update
    void Awake()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.transform.position.x - transform.position.x > rangeDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
