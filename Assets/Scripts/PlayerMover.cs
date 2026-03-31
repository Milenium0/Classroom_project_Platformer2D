using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] // у любого объекта который имеет Playmover обязательно был Rigidbody
public class PlayerMover : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50;
    //private const string HorizontalxAxis = "Horizontal";
    private bool _isMovingLeft = false;
    private bool _isMovingRight = false;
    private bool _isJump = false;
    private bool _isGround = false;
    private const string GROUND_TAG = "Ground";

    [SerializeField] private float _speedX = 1; // [SerializeField]  делает переменную видимой для inspector Unity при этом делая ее приватной
    [SerializeField] private float _jumpForce = 50;

    private Rigidbody2D rbody;
    //private float _direction;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();            // Получить rigidbody

    }

    private void FixedUpdate()                                 // вызывает метод "каждый кадр" 50 раз в секунду
    {
        if (_isMovingRight)
        {
            rbody.linearVelocity = new Vector2(_speedX, rbody.linearVelocity.y);
        }
        else if (_isMovingLeft)
            rbody.linearVelocity = new Vector2(-_speedX, rbody.linearVelocity.y);

        if (_isJump && _isGround)
        {
            rbody.AddForce(new Vector2(0, _jumpForce));
            _isJump = false;
            _isGround = false;
        }
        
    }

    private void Update()
    {
        //_direction = Input.GetAxis(HorizontalxAxis);  \\ старый стиль


        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            Debug.Log("reaction");
            _isMovingLeft = true;
        }
        if (Keyboard.current.aKey.wasReleasedThisFrame)
        {
            _isMovingLeft = false;
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            Debug.Log("reaction");
            _isMovingRight = true;
        }
        if (Keyboard.current.dKey.wasReleasedThisFrame)
        {
            _isMovingRight = false;
        }
        if (_isGround && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _isJump=true;
        }
        if (_isGround && Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            _isJump=false;

        }



    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag(GROUND_TAG)) _isGround = true;
    }
}

//if (Keyboard.current.aKey.isPressed)   // зажата
//{

//    Debug.Log("Pressed A"); 
//}



//Vector2 — хранит (x, y), используется для позиции и скорости

//Rigidbody2D.linearVelocity — скорость объекта

//Time.fixedDeltaTime — время одного шага физики

//Vector2(x, y):
//x — движение по горизонтали
//y — движение по вертикали