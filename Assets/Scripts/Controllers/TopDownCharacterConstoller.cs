using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterConstoller : MonoBehaviour
{
    //float speed = 5f;         //유니티 inspector 에서 접근하진 못하지만 코드에 적용되는 변수
    //[SerializeField]private float speed = 5f;         //유니티와 강제적으로 동기화하여 값을 바꿀 수 없게 만든 변수
    public float speed = 5f;            //유니티 inspector 에서 접근하여 변경 가능한 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, y) * speed * Time.deltaTime;
    }
}
