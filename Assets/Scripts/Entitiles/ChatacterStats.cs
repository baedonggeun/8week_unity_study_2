using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]

public class CharacterStats
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;

    //공격 데이터
    //scriptable object 를 만들어 사용
    public AttackSO attackSO;


}
