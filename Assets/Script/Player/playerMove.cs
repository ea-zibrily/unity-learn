using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Header("Scriptable Object")]
    public playerDefinition _SOPlayerDefinition;

    [Header("Player Movement Component")]
    public float playerSpeed;
    public float playerSprintSpeed;
    private float _playerOriginSpeed;
    public float playerOriginSpeed
    {
        get { return _playerOriginSpeed; }
        set { _playerOriginSpeed = value; }
    }
    public Vector2 playerDirection;


    [Header("Reference")]
    Rigidbody2D myRb;
    Animator myAnim;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Start()
    {
        playerSpeed = _SOPlayerDefinition.speed;
        playerSprintSpeed = _SOPlayerDefinition.sprintSpeed;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        playerWalk();
    }

    void playerWalk()
    {
        float moveX, moveY;
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(moveX, moveY);
        playerDirection.Normalize();

        myRb.velocity = playerDirection * playerSpeed;

        if (playerDirection != Vector2.zero)
        {
            myAnim.SetFloat("Hori", playerDirection.x);
            myAnim.SetFloat("Vert", playerDirection.y);
            myAnim.SetBool("isWalk", true);
        }
        else
        {
            myAnim.SetFloat("Hori", playerDirection.x);
            myAnim.SetFloat("Vert", playerDirection.y);
            myAnim.SetBool("isWalk", false);
        }
    }
}
