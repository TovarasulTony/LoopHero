using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject m_TilePrefab;
    [SerializeField]
    GameObject m_MapReference;

    const int m_Height = 12;
    const int m_Width = 21;
    const int m_MapX = -10;
    const int m_MapY = -4;
    const float m_MapScale = 0.75f;


    void Start()
    {
        InstantiateMap();
        PositionMap();
    }

    void InstantiateMap()
    {
        for (int i = 0; i < m_Height; i++)
        {
            for (int j = 0; j < m_Width; j++)
            {
                GameObject instantiatedTile = Instantiate(m_TilePrefab, new Vector3(j, i, 0), Quaternion.identity, m_MapReference.transform);
                instantiatedTile.GetComponent<SpriteRenderer>().color = ((i + j) % 2 == 0) ? Color.white : Color.black;
            }
        }
    }

    void PositionMap()
    {
        m_MapReference.transform.position = new Vector3(m_MapX, m_MapY, 0);
        m_MapReference.transform.localScale = new Vector3(m_MapScale, m_MapScale, m_MapScale);
    }
}
