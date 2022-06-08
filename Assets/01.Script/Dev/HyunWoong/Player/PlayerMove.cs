using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using System;
using Random = UnityEngine.Random;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    [Header("캐릭터 전반적인 속도")]
    public float speed = 1.5f;
    public float jumpPower = 6f;
    int maxDistance = 2;

    [Header("캐릭터가 행동할 수 있는것")]
    public bool isJumping;
    public bool isMoving = true;
    public bool isAttack = true;
    public bool isCanFlip = true;
    public bool isCanTalk = true;
    public bool isCanNPCInteraction = false;
    public bool isCanLeverInteration = false;

    [SerializeField] private UnityEvent<bool> attackStartEvent;
    [SerializeField] private UnityEvent<bool> attackStopEvent;
    [SerializeField] private SpriteRenderer playerRendere;
    [SerializeField] private Transform hand;
    [SerializeField] private GameObject slash_2;
    [SerializeField] private GameObject TalkWindow;
    [SerializeField] private Transform npc;
    [SerializeField] private Animator _doorAnimation;
    [SerializeField] private Animator _doorAnimation_1;
    [SerializeField] private Transform savePosition;
    [SerializeField] private Transform teleportPos_1;
    [SerializeField] private NPCManager manager;
    [SerializeField] private GameObject interactObject;
    [SerializeField] private AudioClip resetClip;
    public int holdCount = 4;

    public GameObject talkSystem;
    private Transform player;
    Animator anim;
    Camera cam;
    Rigidbody2D rb;
    GameObject holdingObject = null;
    SpriteRenderer spriteRenderer;
    GameObject obj;
    public GameObject Slash;
    public int count = 0;
    public bool isAfterTalk = false;
    PauseMenu pause;
    //private 스피드 : 진짜 적용되는것 , RunSpeed , WalkSpeed , BackSpeed;

    Vector3 rayDir;
    RaycastHit2D hit;
    [SerializeField] private LayerMask raycastLayer;
    [SerializeField] private GameObject interactableObject;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask GroundLayerMask;
    [SerializeField] private float range;

    [SerializeField] private AudioClip[] walkClips;
    [SerializeField] private AudioClip[] swingClips;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip fallingClip;
    [SerializeField] private OrbSpawner orbSpawner;
    [SerializeField] private OrbSpawner orbSpawner2;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = transform.GetComponentInParent<Transform>();
        cam = GameManager.instance.cam;
        isJumping = false;

        FadeManager.Instance.FadeOut();
    }

    void Update()
    {
        Move();
        Jump();
        Attack();
        Hold();
        Flip();
        Talk();
        CheckObject();
        TalkTest();
    }

    private void TalkTest()
    {
        /*if(obj != null && Input.GetKeyDown(KeyCode.F))
        {
            obj.GetComponent<IInteract>().InteractionObject();
        }*/
    }

    void CheckObject()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isCanTalk = true;
            count++;
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range, layerMask);
            float distance = 10000;
            GameObject obj = null;
            int i = 0;
            foreach (Collider2D col in cols)
            {
                float dist = Vector2.Distance(transform.position, col.transform.position);
                if (distance > dist)
                {
                    distance = dist;
                    obj = cols[i].transform.gameObject;
                    i++;
                }
            }
            if(obj != null)
            {
                Interactable(obj);
            }
        }
    }
    void Flip()
    {
        if (!isCanFlip || GameManager.playerTimeScale == 0)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void Interactable(GameObject targetObject)
    {
        targetObject.GetComponent<IInteract>().InteractionObject();
    }
    void Talk()
    {
        /*if (Input.GetKeyDown(KeyCode.F) && isCanTalk)
        {
            talkSystem.SetActive(!talkSystem.activeSelf);
        }
        if (talkSystem.activeSelf && isCanNPCInteration)
        {
            speed = 0f;
            jumpPower = 0f;
            isJumping = false;
            isCanFlip = false;
            isAttack = true;
            CameraManager.instance.SetNpcCamActive();
        }
        else if (talkSystem.activeSelf)
        {
            speed = 2.5f;
            playerMove.jumpPower = 6f;
            playerMove.isCanFlip = true;
            playerMove.isAttack = false;
            CameraManager.instance.SetPlayerCamActive();
            playerMove.isCanNPCInteration = true;
        }*/
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed * GameManager.playerTimeScale;

        rb.velocity = new Vector2(x, rb.velocity.y);

        if (x != 0)
        {
            anim.SetBool("PlayerMoving", true);
        }
        else
        {
            anim.SetBool("PlayerMoving", false);
        }
    }
    void Jump()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green, 0.1f);
        if (isJumping)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, GroundLayerMask);
            if (hit)
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && !isJumping && GameManager.playerTimeScale != 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, GroundLayerMask);
            if (hit)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isJumping = true;
                anim.SetTrigger("PlayerJump");
            }
        }
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.playerTimeScale != 0)
        {
            if (!isAttack)
            {
                isAttack = true;
            }
            anim.SetBool("Attack", true);
            AudioPool.instance.Play(swingClips[UnityEngine.Random.Range(0, swingClips.Length)], 1f, 1f);
            StartCoroutine(AttackSlash());
            Vector3 dir = (transform.localScale.x == 1) ? transform.right : -transform.right;

            hit = Physics2D.Raycast(transform.position, dir, maxDistance, raycastLayer);

            if (hit)
            {
                hit.transform.GetComponent<HitAbleObject>().Hit();
                if (hit.transform.CompareTag("Mirror"))
                {
                    holdCount--;
                }

                if (hit.transform.CompareTag("Obe"))
                {
                    hit.transform.GetComponent<ObeHit>().Set(orbSpawner.SpawnOrb);
                    CameraManager.instance._cmObeCam.Follow = hit.transform;
                    CameraManager.instance.SetObeCam();

                }
                if (hit.transform.CompareTag("Obe2"))
                {
                    hit.transform.GetComponent<ObeHit>().Set(orbSpawner2.SpawnOrb);
                    CameraManager.instance._cmObeCam.Follow = hit.transform;
                    CameraManager.instance.SetObeCam();
                }
            }
        }
    }

    void Hold()
    {
        if (Input.GetMouseButtonDown(1))
        {
            holdingObject = null;

            //anim.SetBool("Hold", true);

            hit = Physics2D.Raycast(transform.position, transform.localScale.x == 1 ? transform.right : -transform.right, maxDistance, raycastLayer);

            if (hit)
            {
                jumpPower = 0;
                holdingObject = hit.transform.gameObject;
                isCanFlip = false;
                isAttack = false;
                hit.transform.SetParent(hand);
            }
        }

        if (Input.GetMouseButtonUp(1) )
        {
            isCanFlip = true;
            isAttack = true;

            if (holdingObject != null)
            {
                jumpPower = 6;
                holdingObject.transform.SetParent(null);
                if (isJumping)
                {
                    isJumping = false;
                }
            }
        }
    }
    IEnumerator MovingSpeed()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator AttackSlash()
    {
        GameObject Slash_1 = Instantiate(Slash, slash_2.transform.position, slash_2.transform.rotation);
        Slash_1.transform.SetParent(transform);
        Slash_1.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(0.1f);
        Destroy(Slash_1);
        isAttack = false;
    }
    public void FlipHandle(bool isCancle)
    {
        isCanFlip = !isCancle;
    }

    public void MoveStop(bool isStop)
    {
        isMoving = !isStop;
    }

    public void AttackStart()
    {
        attackStartEvent?.Invoke(true);
    }

    public void AttackStop()
    {
        attackStopEvent?.Invoke(false);
    }

    public void ATS(bool isStop)
    {
        isAttack = !isStop;
    }
    public void PlayFootStep()
    {
        if (!isJumping) return;
        AudioPool.instance.Play(walkClips[UnityEngine.Random.Range(0, walkClips.Length)], 0.5f, 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Reset"))
        {
            AudioPool.instance.Play(resetClip, 0.5f, 1.1f);
            player.transform.position = savePosition.position;//teleportPos_1.position;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            //print("GG");
            //isJumping = false;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //isJumping = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") && isAfterTalk == false)
        {
            interactObject.SetActive(true);

            Sequence seq = DOTween.Sequence();

            seq.Append(interactObject.transform.DOScale(new Vector3(1.2f, 1.2f), 0.2f));
            seq.Append(interactObject.transform.DOScale(new Vector3(0.9f, 0.9f), 0.05f));
            seq.Append(interactObject.transform.DOScale(new Vector3(0.75f, 0.75f), 0.05f));

            obj = collision.gameObject;
            isCanTalk = true;
            isCanNPCInteraction = true;
        }

        if (collision.gameObject.CompareTag("Lever"))
        {
            isCanLeverInteration = true;
        }

        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            savePosition.position = collision.transform.position;
        }
        if (collision.gameObject.CompareTag("CheckPoint_1"))
        {
            savePosition.position = collision.transform.position;
            CameraManager.instance.SetPlayCam();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isCanNPCInteraction)
        {
            isCanNPCInteraction = false;
            obj = collision.gameObject;

            Sequence seq = DOTween.Sequence();

            seq.Append(interactObject.transform.DOScale(new Vector3(1.2f, 1.2f), 0.2f));
            seq.Append(interactObject.transform.DOScale(new Vector3(0.9f, 0.9f), 0.05f));
            seq.Append(interactObject.transform.DOScale(new Vector3(0.75f, 0.75f), 0.05f));
            seq.AppendCallback(() => { interactObject.SetActive(false); });
        }

        if (isCanLeverInteration)
        {
            isCanLeverInteration = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, range);
    }
}
