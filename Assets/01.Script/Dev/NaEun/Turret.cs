using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_NaEun : MonoBehaviour
{
    [SerializeField] private float fireDelay;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePosition;
    [Range(1f, 10f)] [SerializeField] private float time = 1f;
    [SerializeField] private int maxCharge;
    int curCharge;
    Animator turretAnim;

    private void Start()
    {
       //StartCoroutine(TurretShooting());
       turretAnim = GetComponent<Animator>();
    }
    public void Shoot()
    {
                    Instantiate(bullet, firePosition.position, firePosition.rotation);
    }

    /*IEnumerator TurretShooting()
    {
        yield return new WaitUntil(() => isReadyToShoot);
        while (true)
        {
            Instantiate(bullet, firePosition.position, firePosition.rotation);
            yield return new WaitForSeconds(fireDelay);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obe"))
        {
            curCharge++;
            Destroy(collision.gameObject);
            if(curCharge % maxCharge == 0 && curCharge != 0)
            {
                curCharge = 0;
                turretAnim.SetTrigger("On");
                StartCoroutine(Use(5));
            }
        }
    }
    IEnumerator Use(float time)
    {
        yield return new WaitForSeconds(time);
        turretAnim.SetTrigger("Off");
    }
}
