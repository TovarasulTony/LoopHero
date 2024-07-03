using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    TileGenerator m_TileGenerator;

    Tile[,] m_TileRefs;


    // Start is called before the first frame update
    void Start()
    {
        m_TileRefs = new Tile[12, 21];

        for (int i = 0; i < m_TileRefs.GetLength(0); i++)
        {
            for (int j = 0; j < m_TileRefs.GetLength(1); j++)
            {
                m_TileRefs[i, j] = null;
            }
        }

        m_TileGenerator.GenerateTiles(m_TileRefs);
    }
}
