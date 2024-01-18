using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;

    private Vector3 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        /*GetComponent<TopDownMovement> : TopDownMovement 가 달려있는 같은 object 에서 component를 찾아온다는 것
         * inspector 내에서 component 간에 서로가 서로를 인지할 수 있는 방법
         * 다른 object에서 접근하려면 다른 오브젝트 이름.GetComponent<> 이런 방식으로 접근해야함
         */
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;

        _rigidbody.velocity = direction;
    }
}
