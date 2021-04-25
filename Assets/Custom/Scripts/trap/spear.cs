using UnityEngine;
using UnityEngine.SceneManagement;

public class spear : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerEffect>().getDamage();
        }
        Destroy(this.gameObject);
    }
}
