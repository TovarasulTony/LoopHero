using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Tile
{
    int m_NeighbourCoordX;
    int m_NeighbourCoordY;


    public void SetNeighbourCoords(int _coordX, int _coordY)
    {
        m_NeighbourCoordX = _coordX;
        m_NeighbourCoordY = _coordY;
    }

    public (int,int) GetNextCoords()
    {
        return (m_NeighbourCoordX, m_NeighbourCoordY);
    }
}
