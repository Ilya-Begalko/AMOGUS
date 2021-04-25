using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 playerPos;
    public float speed;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerPos = player.transform.position;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
        if ((transform.position - playerPos).magnitude < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerEffect>().getDamage();
        }
        Destroy(gameObject);
    }
}
