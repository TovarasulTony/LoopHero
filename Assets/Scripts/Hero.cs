using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    BattlingHero m_BattlingHero;
    [SerializeField]
    WalkingHero m_WalkingHero;

    public WalkingHero GetWalkingHero() { return m_WalkingHero; }
}
