using UnityEngine;

public class stalactite : MonoBehaviour
{
    public GameObject gmstalactite;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gmstalactite.GetComponent<Rigidbody>().useGravity = true;
            Destroy(this);
        }
    }
}
