using UnityEngine;

public class block : MonoBehaviour
{
    public float timeDelay = 5f;

    private float time = 0f;
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > timeDelay)
        {
            animator.SetBool("isBack", !animator.GetBool("isBack"));
            time = 0f;
        }
    }
}
