using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEffect : MonoBehaviour
{
    public int hp = 3;
    public float light = 40f;
    private float startLight;
    public float lightPerS = 0.01f;
    public Light torch;
    public RawImage[] hpImg;
    private AudioSource audioDamage;
    public Material mainMat;
    public float time = 1f;
    private bool paused = false;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        audioDamage = GetComponent<AudioSource>();
        startLight = light;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (paused)
            {
                paused = false;
                Time.timeScale = 1;
                SceneManager.LoadScene("myLevel");
            }
        }

        if (light > 0)
        {
            light -= lightPerS;
        }
        torch.range = light;
    }

    public void getFire()
    {
        light = startLight;
    }

    public void getHealth()
    {
        hp += 1;
        for (int i = 0; i < hpImg.Length; i++)
        {
            hpImg[i].enabled = false;
        }
        for (int i = 0; i < hp; i++)
        {
            hpImg[i].enabled = true;
        }
    }

    public void getDamage()
    {
        StartCoroutine(hdr());
        audioDamage.Play();
        hp -= 1;
        for (int i = 0; i < hpImg.Length; i++)
        {
            hpImg[i].enabled = false;
        }
        for (int i = 0; i < hp; i++)
        {
            hpImg[i].enabled = true;
        }
        if (hp == 0)
        {
            gameOver.SetActive(true);
            paused = true;
            Time.timeScale = 0;
            //SceneManager.LoadScene("myLevel");
        }
    }

    private IEnumerator hdr()
    {
        mainMat.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(time);
        mainMat.DisableKeyword("_EMISSION");
    }
}
