using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    private Text text;
    private int score = 0;
    Vector3 pos;

    void Start()
    {
        text = GetComponent<Text>();
        pos = player.transform.position;
    }
    void Update()
    {
        Vector3 pos_now = player.transform.position;
        if ((int)((pos_now - pos).x / 3) > score){
            score = (int)((pos_now - pos).x / 3);
            text.text = "" + score;
        }
    }
}
