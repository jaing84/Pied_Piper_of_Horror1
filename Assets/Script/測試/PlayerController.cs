using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   // public Playerinputcontrols inputControl;
    private Rigidbody2D rb;
   // private PhysicsCheck physicsCheck;
    public Vector2 _moveInput;
    private SpriteRenderer _spriteRenderer;
    [Header("?箸?")]
    public float speed;
    public float jumpFarce;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
   //     physicsCheck = GetComponent<PhysicsCheck>();

        //      inputControl = new Playerinputcontrols();

        //     inputControl.Gameplay.Jump.started += Jump;
    }



    private void OnEnable()
    {
   //     inputControl.Enable();

    }

    private void OnDisable()
    {
//        inputControl.Disable();
    }


    private void Update()
    {
  //      inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.velocity = _moveInput*speed*Time.deltaTime;

       

          if (_moveInput.x > 0)
              _spriteRenderer.flipX = true;
         if (_moveInput.x < 0)
            _spriteRenderer.flipX = false;

        //鈭箇蝧餉?
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

}

