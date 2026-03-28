using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] // у любого объекта который имеет Playmover обязательно был Rigidbody
public class PlayerMover : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50;
    private bool _isMovingLeft = false;
    private bool _isMovingRight = false;

    [SerializeField] private float _speedX = 2; // [SerializeField]  делает переменную видимой для inspector Unity при этом делая ее приватной


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();            // Получить rigidbody
        //  rb.linearVelocity = new Vector2(-1,0)      присвоение скорости
    }

    private void FixedUpdate()                                 // вызывает метод "каждый кадр" 50 раз в секунду
    {
        if (_isMovingRight)
        {
            rb.linearVelocity = new Vector2(_speedX * SPEED_COEFFICIENT * Time.fixedDeltaTime, rb.linearVelocity.y);
        }
        else if(_isMovingLeft)
            rb.linearVelocity = new Vector2(-_speedX * SPEED_COEFFICIENT * Time.fixedDeltaTime, rb.linearVelocity.y);
        

    }

    private void Update()
    {

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