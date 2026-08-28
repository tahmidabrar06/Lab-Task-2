using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private CharacterController cc;
    private bool isJumping = false;
    public float speed;
    public float gravityStrength;
    [SerializeField]
    private float acceleration;
    public float jumpStrength;
    void Start()
    {        
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        Movement();
        Jump();
    }

    void Gravity()
    {
        if(acceleration > gravityStrength)
        {
            acceleration += gravityStrength * Time.deltaTime;
        }
        else if(cc.isGrounded)
        {
            acceleration = gravityStrength;
        }
        cc.Move(Vector3.up * acceleration * Time.deltaTime);
    }

    void Movement()
    {
        Vector2 moveDir = moveAction.ReadValue<Vector2>();
        Vector3 movement = transform.right * moveDir.x + transform.forward * moveDir.y;
        cc.Move(movement * speed * Time.deltaTime);
    }
    void Jump()
    {
        if (jumpAction.WasPressedThisFrame() && isJumping == false)
        {
            Debug.Log("jumped");
            isJumping = true;
            acceleration = jumpStrength;
        }
        if (cc.isGrounded)
        {
            isJumping = false;
        }
        
    }
}
