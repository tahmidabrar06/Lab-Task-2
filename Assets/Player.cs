using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private CharacterController cc;
    [SerializeField] 
    private float speed = 5;
    [SerializeField] 
    private float gravityStrength = -9.8f;
    [SerializeField]
    private float verticalAcc;
    [SerializeField]
    private float jumpStrength = 5;
    [SerializeField]
    private int extraJumps = 1;
    private int jumpCount = 0;

    private Transform groundCheck;
    [SerializeField] 
    float groundDistance = 0.6f;
    [SerializeField] 
    LayerMask groundMask;
    private bool gravReset;

    [SerializeField]
    private Weapon equippedWeapon;
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
        Attack();
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
        if (jumpAction.WasPressedThisFrame())
        {
            if(jumpCount<extraJumps)
            {
                //Debug.Log("jumped");
                verticalAcc = jumpStrength;
                jumpCount += 1; //first jump doesnt count for some reason?
            }
        }
        if(IsGrounded())
        {
            jumpCount = 0;
        }
    }

    void Attack()
    {
        if (equippedWeapon == null)
            return;

        equippedWeapon.HandleWeaponInput(attackAction.WasPressedThisFrame(), attackAction.IsPressed());
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
