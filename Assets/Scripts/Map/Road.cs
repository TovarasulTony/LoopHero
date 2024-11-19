using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Tile
{
    int m_NeighbourCoordX;
    int m_NeighbourCoordY;
    List<MapEntity> m_RoadEntities;
    [SerializeField]
    DrawMapEntity m_DrawMapEntity;

    const int m_MaxRoadEntities = 4;

    Road()
    {
        m_RoadEntities = new List<MapEntity>();
    }

    public void SetNeighbourCoords(int _coordX, int _coordY)
    {
        m_NeighbourCoordX = _coordX;
        m_NeighbourCoordY = _coordY;
    }

    public (int,int) GetNextCoords()
    {
        return (m_NeighbourCoordX, m_NeighbourCoordY);
    }

    public void AddRoadEntity(MapEntity _entity)
    {
        if (m_RoadEntities.Count >= m_MaxRoadEntities)
        {
            Debug.Log("To many road entities");
            return;
        }
        m_RoadEntities.Add(_entity);

        //m_DrawMapEntity.DrawMapEntities(m_RoadEntities);
        _entity.transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f); //HARDCODED
    }

    public List<MapEntity> GetRoadEntities()
    {
        return m_RoadEntities;
    }
}
