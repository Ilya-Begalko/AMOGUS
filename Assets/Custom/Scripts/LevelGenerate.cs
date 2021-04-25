using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerate : MonoBehaviour
{
    public GameObject player;
    public GameObject[] level;
    private Transform PosLad;

    public float x = 50f;
    private float xNow = 0;
    private float height;
    private float width;
    public float y = 50f;
    public float yPnow = 0;
    public float yP = 5f;
    public float z = -1;
    private int it;

    private float yNow = 0;

    // Start is called before the first frame update
    void Start()
    {
        //height = level.GetComponent<MeshFilter>().sharedMesh.bounds.size.y;
        //width = level.GetComponent<MeshFilter>().sharedMesh.bounds.size.x;
        //PosLad = level.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.transform.position.x);
        Debug.Log(yPnow);
        if (player.transform.position.x > yPnow)
        {
            it = Random.Range(0, level.Length);
            Instantiate(level[it], new Vector3(xNow, yNow, z), Quaternion.identity);
            xNow += x;
            yNow -= y;
            yPnow += yP;
        }
    }
}
