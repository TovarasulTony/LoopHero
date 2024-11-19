using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    protected int m_CoordX;
    protected int m_CoordY;

    public void SetCoords(int _coordX, int _coordY)
    {
        m_CoordX = _coordX;
        m_CoordY = _coordY;
    }
}
