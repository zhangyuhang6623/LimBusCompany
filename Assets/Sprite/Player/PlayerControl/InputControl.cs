using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputControl : MonoBehaviour
{
    [Header("基本参数")]
    public Rigidbody2D rb;
    public float spead;
    public float jumpForce;
    public PhysicalCheck physicalCheck;
    private Vector2 moveDirection;
    public Character character;
    public DotManage dotManage;
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        physicalCheck = GetComponent<PhysicalCheck>();
        character = GetComponent<Character>();
        dotManage = GetComponent<DotManage>();
    }
    private void OnEnable()
    {
        InputDetection.inputDetection.Player.Jump.started += Jump;
        InputDetection.inputDetection.Enable();
    }
    private void OnDisable()
    {
        InputDetection.inputDetection.Player.Jump.started -= Jump;
        InputDetection.inputDetection.Disable();
    }
    private void Update()
    {
        moveDirection= InputDetection.inputDetection.Player .Move.ReadValue<Vector2 >(); 
    }
    private void FixedUpdate()
    {
            Move();
    }
    //Move要重新设计
    private void Move()
    {
        if (character.isChaos) return;
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
            if (character != null && dotManage != null)
            {
                dotManage.bleed.DotAchive(character);
            }
        }
    }
}
