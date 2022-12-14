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

    [Header("Reference")]
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
}
