using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEntity : MonoBehaviour
{
    [SerializeField]
    BattlingEnemy m_BattlingEnemyPrefab;

    public BattlingEnemy GetBattlingEnemy() { return m_BattlingEnemyPrefab; }
}
