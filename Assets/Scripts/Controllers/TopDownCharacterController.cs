using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;           //event -> 외부에서 호출하지 못하게 막는 기능
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);         //?. -> ?.앞의 내용이 Null이 아닐 경우만 뒤의 내용 실행

    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }



    #region 이동 처리 예시
    //float speed = 5f;         //유니티 inspector 에서 접근하진 못하지만 코드에 적용되는 변수
    //[SerializeField]private float speed = 5f;         //유니티와 강제적으로 동기화하여 값을 바꿀 수 없게 만든 변수
    //public float speed = 5f;            //유니티 inspector 에서 접근하여 변경 가능한 변수


    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //    float x = Input.GetAxis("Horizontal");
    //    float y = Input.GetAxis("Vertical");

    //    transform.position += new Vector3(x, y) * speed * Time.deltaTime;

    //}
    #endregion
}
