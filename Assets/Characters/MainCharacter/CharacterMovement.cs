using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private const float diagonalUnit = 1.414213562373095f;
    [SerializeField]float speed = 5f;
    
    PlayerInput playerInput;
    enum LastDirectionId { up, down, left, right };
    [SerializeField]LastDirectionId lastDirection = LastDirectionId.down;

    [SerializeField]CharacterController controller;
    [SerializeField]Animator animator;
    SpriteRenderer spriteRenderer;
    
    enum AnimatorState
    {
        Idle_up, Idle_down, Idle_left, Idle_right,  
        Walk_up, Walk_down, Walk_left, Walk_right
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GameObject.Find("GameManager").GetComponent<PlayerInput>();

        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    void Start()
    {
        lastDirection = LastDirectionId.down;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerInput.direction;
        
        ///==================== Cambiar de estado segun el input ======================================
        if (playerInput.oneDirection || playerInput.turning)
        {
            if (direction == Vector3.forward)
            {
                animator.Play(Animator.StringToHash("Walk_up"));
                lastDirection = LastDirectionId.up;
            }
            if (direction == Vector3.back)
            {
                animator.Play(Animator.StringToHash("Walk_down"));
                lastDirection = LastDirectionId.down;
            }
            if (direction == Vector3.left)
            {
                if (spriteRenderer.flipX == false) spriteRenderer.flipX = true;
                animator.Play(Animator.StringToHash("Walk_right"));
                lastDirection = LastDirectionId.left;
            }
            if (direction == Vector3.right)
            {
                if (spriteRenderer.flipX == true) spriteRenderer.flipX = false;
                animator.Play(Animator.StringToHash("Walk_right"));
                lastDirection = LastDirectionId.right;
            }
        }

        if (playerInput.noDirection)
        {
            switch (lastDirection)
            {
                case LastDirectionId.up:
                animator.Play(Animator.StringToHash("Idle_up"));
                break;

                case LastDirectionId.down:
                animator.Play(Animator.StringToHash("Idle_down"));
                break;

                case LastDirectionId.left:
                animator.Play(Animator.StringToHash("Idle_right"));
                spriteRenderer.flipX = true;
                break;
                
                case LastDirectionId.right:
                animator.Play(Animator.StringToHash("Idle_right"));
                spriteRenderer.flipX = false;
                break;
            }
        }
    }

    void FixedUpdate()
    {
        if (playerInput.oneDirection)
        {
            Vector3 direction = playerInput.direction;
            float thisSpeed = direction.x != 0 ? speed : speed * diagonalUnit;
            controller.Move(Time.deltaTime * thisSpeed * direction);
        }
    }



}
