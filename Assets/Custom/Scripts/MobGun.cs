using System.Collections;
using UnityEngine;

public class MobGun : MonoBehaviour
{

    public GameObject bullet;
    public Transform gunPoint;
    public float fireRate = 1;
    private bool isStart = true;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
            if (isStart)
                StartCoroutine(ToDamage());
    }

    private IEnumerator ToDamage()
    {
        isStart = false;
        Instantiate(bullet, gunPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(fireRate);
        isStart = true;
    }
}
