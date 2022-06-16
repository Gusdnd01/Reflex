using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretA : Turret_NaEun
{
    private void Awake()
    {
        maxCharge = 3;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obe"))
        {
            curCharge++;
            Destroy(collision.gameObject);
            if (curCharge % maxCharge == 0 && curCharge != 0)
            {
                curCharge = 0;
                turretAnim.SetTrigger("On");
                StartCoroutine(Use(5));
            }
        }
    }
}