using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_NaEun : MonoBehaviour
{
    [SerializeField] protected float fireDelay;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform firePosition;
    [Range(1f, 10f)][SerializeField] protected float time = 1f;
    [SerializeField] protected int maxCharge;
    protected int curCharge;
    protected Animator turretAnim;

    private void Awake()
    {
        //StartCoroutine(TurretShooting());
        turretAnim = GetComponent<Animator>();
        ChildAwake();
    }
    protected virtual void ChildAwake()
    {

    }
    protected virtual void Shoot()
    {
        Instantiate(bullet, firePosition.position, firePosition.rotation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }
    protected virtual IEnumerator Use(float time)
    {
        yield return new WaitForSeconds(time);
        turretAnim.SetTrigger("Off");
    }
}
