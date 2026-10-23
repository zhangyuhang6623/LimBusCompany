using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    [Header("基本参数")]
    public Rigidbody2D rb;
    public float spead;
    public float jumpForce;
    public InputSystem inputActions;
    public PhysicalCheck physicalCheck;
    private Vector2 moveDirection;
    public Character character;
    private void Awake()
    {
        inputActions=new InputSystem();
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
        physicalCheck = GetComponent<PhysicalCheck>();
        inputActions.Player.Jump.started += Jump;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void Update()
    {
        moveDirection=inputActions.Player .Move.ReadValue<Vector2 >(); 
    }
    private void FixedUpdate()
    {
        if (!character.isChaos)
        {
            Move();
        }
    }
    private void Move()
    {
        if((moveDirection.x < 0 && transform.localScale.x > 0)||(moveDirection.x>0&& transform.localScale.x < 0))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        rb.velocity = new Vector2(moveDirection.x * spead , rb.velocity.y);
    }
    private void Jump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (physicalCheck.isGrand)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
