using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * 옵저버 패턴 : TopDownCharacterController 내부의 event 들(move, look fire)에 PlayerInputController 내부의 함수를 걸어놓는 것
 * PlayerInputController 내부의 함수에서 event를 호출하면 해당 event에 구독한 클래스나 함수들에 모두 전달됨
 * 
 */
public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;      //해당 Scene 에 존재하는 tag가 main인 카메라를 찾아옴
    }

    /*
     * 함수 이름 앞에 On이 붙으면 On 뒷 부분에 해당하는 이름의 input system 의 입력이 들어왔을 때 
     * 해당 value를 함수의 매개변수로 받아오는 함수
    */
    public void OnMove(InputValue value)        //움직일 때 
    {
        //Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;        //normalized를 통해 대각선 방향 속도를 가로(세로) 단일 속도와 같도록 만듦
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)        //보는 방향에 따라 
    {
        //Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if(newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }
    public void OnFire(InputValue value)        //발사버튼 누를 때마다 
    {
        //Debug.Log("OnFire" + value.ToString());
        IsAttacking = value.isPressed;
    }

}
