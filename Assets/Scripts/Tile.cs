using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int m_CoordX;
    int m_CoordY;

    public void SetCoords(int _coordX, int _coordY)
    {
        m_CoordX = _coordX;
        m_CoordY = _coordY;
    }
}
