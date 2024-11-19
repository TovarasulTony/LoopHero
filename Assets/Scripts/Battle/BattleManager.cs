using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    [SerializeField]
    private GameObject m_BattleGround;

    [Header("Spawpoints")]
    [SerializeField]
    private GameObject m_SpawnPointHero;
    [SerializeField]
    private List<GameObject> m_SpawnPointEnemies;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        m_BattleGround.SetActive(false);
    }
    
    public void StartBattle(List<MapEntity> _entityList, BattlingHero _battlingHero)
    {
        m_BattleGround.SetActive(true);
        SpawnEnemies(_entityList);
        SpawnHero(_battlingHero);
    }

    void SpawnEnemies(List<MapEntity> _entityList)
    {
        for (int i = 0; i < _entityList.Count; ++i)
        {
            MapEntity entity = _entityList[i];
            BattlingEnemy enemy = Instantiate(_entityList[i].GetBattlingEnemy());
            enemy.transform.position = m_SpawnPointEnemies[i].transform.position;
            enemy.transform.parent = m_BattleGround.transform;
        }
    }

    void SpawnHero(BattlingHero _battlingHero)
    {
        _battlingHero.gameObject.SetActive(true);
        _battlingHero.transform.position = m_SpawnPointHero.transform.position;
    }
}
