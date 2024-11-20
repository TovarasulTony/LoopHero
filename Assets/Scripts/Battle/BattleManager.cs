using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    [SerializeField]
    GameObject m_BattleGround;

    [Header("Spawpoints")]
    [SerializeField]
    GameObject m_SpawnPointHero;
    [SerializeField]
    List<GameObject> m_SpawnPointEnemies;

    List<BattlingEnemy> m_BattlingEnemyList;
    BattlingHero m_BattlingHero;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            m_BattlingEnemyList = new List<BattlingEnemy>();
        }
        m_BattleGround.SetActive(false);
    }
    
    public void StartBattle(List<MapEntity> _entityList, BattlingHero _battlingHero)
    {
        m_BattlingHero = _battlingHero;
        m_BattleGround.SetActive(true);
        SpawnEnemies(_entityList);
        SpawnHero();
    }

    public void RemoveBattlingEnemy(BattlingEnemy _battlingEnemy)
    {
        m_BattlingEnemyList.Remove(_battlingEnemy);
        if(m_BattlingEnemyList.Count == 0)
        {
            m_BattleGround.SetActive(false);
            m_BattlingHero.SetBattlingEnemy(null);
            m_BattlingHero.gameObject.SetActive(false);
            m_BattlingHero.GetWalkingHero().FinishBattle();
        }
    }

    void SpawnEnemies(List<MapEntity> _entityList)
    {
        for (int i = 0; i < _entityList.Count; ++i)
        {
            MapEntity entity = _entityList[i];
            BattlingEnemy enemy = Instantiate(_entityList[i].GetBattlingEnemy());
            enemy.transform.position = m_SpawnPointEnemies[i].transform.position;
            enemy.transform.parent = m_BattleGround.transform;
            enemy.SetAssociatedMapEntity(entity);
            m_BattlingEnemyList.Add(enemy);
        }
    }

    void SpawnHero()
    {
        m_BattlingHero.SetBattlingEnemy(m_BattlingEnemyList[m_BattlingEnemyList.Count - 1]);
        m_BattlingHero.gameObject.SetActive(true);
        m_BattlingHero.transform.position = m_SpawnPointHero.transform.position;
    }
}
