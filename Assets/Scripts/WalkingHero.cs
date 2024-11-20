using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingHero : MonoBehaviour
{
    [SerializeField]
    private BattlingHero m_BattlingHero;

    Road m_CurrentRoadRef;

    const float m_MoveInterval = 0.5f;
    float m_CurrentTime = 0;
    bool m_IsInBattle = false;

    public void SetStartingCoords((int,int) _startingCoords)
    {
        m_CurrentRoadRef = Map.Instance.GetTileRef(_startingCoords).GetComponent<Road>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        m_CurrentTime += Time.fixedDeltaTime;
        if (m_MoveInterval > m_CurrentTime ||
            m_IsInBattle == true)
        {
            return;
        }
        m_CurrentTime = 0;
        Road nextRoad = Map.Instance.GetTileRef(m_CurrentRoadRef.GetNextCoords()).GetComponent<Road>();
        transform.position = new Vector3(nextRoad.transform.position.x, nextRoad.transform.position.y, nextRoad.transform.position.z - 0.1f);
        m_CurrentRoadRef = nextRoad;

        Battle();
    }

    void Battle()
    {
        List<MapEntity> entityList = m_CurrentRoadRef.GetRoadEntities();
        if(entityList.Count == 0)
        {
            return;
        }
        m_IsInBattle = true;
        BattleManager.Instance.StartBattle(entityList, m_BattlingHero);
    }

    public void FinishBattle() { m_IsInBattle = false; }
}
