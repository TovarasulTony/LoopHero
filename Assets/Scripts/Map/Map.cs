using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance { get; private set; }
    [SerializeField]
    TileGenerator m_TileGenerator;

    Tile[,] m_TileRefs;

    const int m_MaxHeight = 12;
    const int m_MaxWidth = 21;

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
        Setup();
    }

    void Setup()
    {
        m_TileRefs = new Tile[m_MaxHeight, m_MaxWidth];

        for (int i = 0; i < m_TileRefs.GetLength(0); i++)
        {
            for (int j = 0; j < m_TileRefs.GetLength(1); j++)
            {
                m_TileRefs[i, j] = null;
            }
        }

        m_TileGenerator.GenerateTiles(m_TileRefs);
    }

    public Tile GetTileRef((int,int) _coords)
    {
        return m_TileRefs[_coords.Item1, _coords.Item2];
    }
}
