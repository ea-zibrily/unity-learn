using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Header("Scriptable Object")]
    public playerDefinition _SOPlayerDefinition;

    [Header("Player Movement Component")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerSprintSpeed;
    [SerializeField] private float _playerOriginSpeed;
    public float playerOriginSpeed
    {
        get { return _playerOriginSpeed; }
        set { _playerOriginSpeed = value; }
    }
    public Vector2 playerDirection;
    public bool isSprint;
    public bool isLock;

    [Header("Aim Area")]
    public float radius;
    public Transform target;
    public LayerMask targets;
    public Vector2 targetDirection;
    public bool isLockTarget;

    [Header("Reference")]
    public GameObject crossHair;
    Rigidbody2D myRb;
    Animator myAnim;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        playerSpeed = _SOPlayerDefinition.speed;
        playerSprintSpeed = _SOPlayerDefinition.sprintSpeed;
    }

    private void Start()
    {
        playerOriginSpeed = playerSpeed;
    }

    private void Update()
    {
        PlayerSprint();

        #region Aim
        LockTargetOnEnemy();
        AimDirection();
        #endregion
    }

    private void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        float moveX, moveY;
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(moveX, moveY);
        playerDirection.Normalize();

        myRb.velocity = playerDirection * playerSpeed;
        PlayerAnimationDirection();
    }

    void PlayerAnimationDirection()
    {
        if (playerDirection != Vector2.zero)
        {
            myAnim.SetFloat("Hori", playerDirection.x);
            myAnim.SetFloat("Vert", playerDirection.y);
            myAnim.SetBool("isWalk", true);
        }
        else
        {
            if (isLock)
            {
                myAnim.SetFloat("Hori", targetDirection.x);
                myAnim.SetFloat("Vert", targetDirection.y);
            }
            myAnim.SetBool("isWalk", false);
        }
    }

    void PlayerSprint()
    {
        isSprint = Input.GetKey(KeyCode.LeftShift);
        playerSpeed = isSprint ? playerSprintSpeed : playerOriginSpeed;
        if (isSprint)
        {
            Debug.Log("Sprint Speed" + playerSpeed);
        }
        else
        {
            Debug.Log("Normal Speed" + playerSpeed);
        }
    }

    void LockTargetOnEnemy()
    {
        isLock = Input.GetKeyDown(KeyCode.X) && playerDirection == Vector2.zero || OnArea();

        if (Input.GetKeyDown(KeyCode.X) && OnArea())
        {
            Debug.Log("Lock Target");
            crossHair.SetActive(true);
        }
        else if (!OnArea())
        {
            crossHair.SetActive(false);
        }
    }

    void AimDirection()
    {
        float aimX, aimY;
        aimX = crossHair.transform.position.x - transform.position.x;
        aimY = crossHair.transform.position.y - transform.position.y;

        targetDirection = new Vector2(aimX, aimY);
        targetDirection.Normalize();
    }

    bool OnArea()
    {
        return Physics2D.OverlapCircle(target.position, radius, targets);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(target.position, radius);
    }
}
