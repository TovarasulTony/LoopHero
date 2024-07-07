using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingHero : MonoBehaviour
{
    Map m_MapReference;
    Road m_CurrentRoadRef;

    const float m_MoveInterval = 0.5f;
    float m_CurrentTime = 0;

    public void SetStartingCoords((int,int) _startingCoords)
    {
        m_CurrentRoadRef = m_MapReference.GetTileRef(_startingCoords).GetComponent<Road>();
    }

    public void SetMapRef(Map _ref)
    {
        m_MapReference = _ref;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        m_CurrentTime += Time.fixedDeltaTime;
        if (m_MoveInterval > m_CurrentTime)
        {
            return;
        }
        m_CurrentTime = 0;
        Road nextRoad = m_MapReference.GetTileRef(m_CurrentRoadRef.GetNextCoords()).GetComponent<Road>();
        transform.position = nextRoad.transform.position;
        m_CurrentRoadRef = nextRoad;
    }
}
