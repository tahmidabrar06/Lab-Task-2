using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private CharacterController cc;
    [SerializeField] 
    private float speed;
    [SerializeField] 
    private float gravityStrength;
    [SerializeField]
    private float verticalAcc;
    [SerializeField]
    private float jumpStrength;

    private Transform groundCheck;
    [SerializeField] 
    float groundDistance = 0.6f;
    [SerializeField] 
    LayerMask groundMask;
    private bool gravReset;
    void Start()
    {        
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        cc = gameObject.GetComponent<CharacterController>();
        groundCheck = GameObject.Find("GroundChecker").GetComponent<Transform>();
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
        if(!IsGrounded())
        {
            gravReset = false;
            verticalAcc += gravityStrength * Time.deltaTime;
        }
        else if(IsGrounded() && !gravReset)
        {
            verticalAcc = 0;
            gravReset = true;
        }
        cc.Move(Vector3.up * verticalAcc * Time.deltaTime);
    }

    void Movement()
    {
        Vector2 moveDir = moveAction.ReadValue<Vector2>();
        Vector3 movement = transform.right * moveDir.x + transform.forward * moveDir.y;
        cc.Move(movement * speed * Time.deltaTime);
    }
    void Jump()
    {
        if (jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            //Debug.Log("jumped");
            verticalAcc = jumpStrength;
        }        
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    void OnDrawGizmosSelected()
{
    if (groundCheck == null)
        return;

    Gizmos.DrawWireSphere(
        groundCheck.position,
        groundDistance
    );
}
}
