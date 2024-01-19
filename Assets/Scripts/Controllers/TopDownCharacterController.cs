using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 탑다운캐릭터컨트롤러가 3개의 event를 가지고 있고
 * 각각의 이벤트를 구독한 클래스, 함수들에서 해당 이벤트를 호출하면
 * callmoveevent 함수 같은데에서 null인지 아닌지 예외처리 후 이벤트를 실행해줌?
 * 
 */

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;           //event -> 외부에서 호출하지 못하게 막는 기능
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;

    protected bool IsAttacking { get; set; }

    protected CharacterStatsHandler Stats {  get; private set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (Stats.CurrentStates.attackSO == null)
            return;

        if(_timeSinceLastAttack <= Stats.CurrentStates.attackSO.delay)        //todo
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        
        if(IsAttacking && _timeSinceLastAttack > Stats.CurrentStates.attackSO.delay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);         //?. -> ?.앞의 내용이 Null이 아닐 경우만 뒤의 내용 실행

    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
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
