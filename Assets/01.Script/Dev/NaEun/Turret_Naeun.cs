using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_NaEun : MonoBehaviour
{
    #region 발사 관련
    [Header("발사 관련")]
    [SerializeField] protected float fireDelay;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform firePosition;
    [Range(1f, 10f)] [SerializeField] protected float time = 1f;
    #endregion

    #region 터렛 충전
    [Header("터렛 충전")]
    [SerializeField] protected int maxCharge;
    protected int curCharge;
    #endregion

    #region 애니메이션
    protected Animator turretAnim;
    #endregion

    private void Awake()
    {
        //StartCoroutine(TurretShooting());
        turretAnim = GetComponent<Animator>();
        ChildAwake();
    }

    protected virtual void ChildAwake()
    {

    }

    /// <summary>
    /// 총알 발사 함수
    /// </summary>
    protected virtual void Shoot()
    {
        Instantiate(bullet, firePosition.position, firePosition.rotation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    /// <summary>
    /// 터렛 작동 함수
    /// </summary>
    /// <param name="time"></param> 작동 시간
    /// <returns></returns>
    protected virtual IEnumerator Use(float time)
    {
        yield return new WaitForSeconds(time);
        turretAnim.SetTrigger("Off");
    }
}
