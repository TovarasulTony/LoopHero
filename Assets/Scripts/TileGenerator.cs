using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject m_HeroPrefab;
    [SerializeField]
    GameObject m_TilePrefab;
    [SerializeField]
    GameObject m_RoadPrefab;
    [SerializeField]
    GameObject m_MapReference;
    [SerializeField]
    Camera m_CameraReference;

    const int m_Height = 12;
    const int m_Width = 21;
    const int m_CameraX = 10;
    const int m_CameraY = 4;
    const int m_CameraZ = -10;
    const int m_CameraSize = 7;

    const int m_StartingX = 8;
    const int m_StartingY = 8;

    (int, int)[] m_RoadTilesCoords = new (int, int)[]
    {
        (8,5), (8,6), (8,7), (8,8), (8,9), (8,10), (8,11), (8,12), (8,13), (8,14),
        (7,14), (6,14), (5,14), (4,14), (3,14),
        (3, 13), (3,12), (3,11), (3,10), (3,9), (3,8), (3,7), (3,6), (3,5), (3,4),
        (4,4), (5,4), (6,4), (7,4), (8,4)
    };


    public void GenerateTiles(Tile[,] _tileRefs)
    {
        PositionCamera();
        InitMap(_tileRefs);
        InitRoad(_tileRefs);
        InitHero();
    }

    void InitMap(Tile[,] _tileRefs)
    {
        for (int i = 0; i < m_Height; i++)
        {
            for (int j = 0; j < m_Width; j++)
            {
                GameObject instantiatedTile = Instantiate(m_TilePrefab, new Vector3(j, i, 0), Quaternion.identity, m_MapReference.transform);
                instantiatedTile.transform.name = $"[{i}, {j}] Empty Tile";
                instantiatedTile.GetComponent<SpriteRenderer>().color = ((i + j) % 2 == 0) ? Color.white : Color.black;
                Tile tile = instantiatedTile.GetComponent<Tile>();
                tile.SetCoords(i, j);
                _tileRefs[i,j] = tile;
            }
        }
    }

    void InitRoad(Tile[,] _tileRefs)
    {
        Road prevRoad = null;
        foreach (var roadCoords in m_RoadTilesCoords)
        {
            Destroy(_tileRefs[roadCoords.Item1, roadCoords.Item2].gameObject);
            int i = roadCoords.Item1;
            int j = roadCoords.Item2;
            GameObject instantiatedTile = Instantiate(m_RoadPrefab, new Vector3(j, i, 0), Quaternion.identity, m_MapReference.transform);
            instantiatedTile.transform.name = $"[{i}, {j}] Road Tile";

            Road road = instantiatedTile.GetComponent<Road>();
            _tileRefs[i, j] = road;
            road.SetCoords(i, j);
            if (prevRoad)
            {
                prevRoad.SetNeighbourCoords(i, j);
            }
            prevRoad = road;
        }
        prevRoad.SetNeighbourCoords(m_RoadTilesCoords[0].Item1, m_RoadTilesCoords[0].Item2);
    }

    void PositionCamera()
    {
        m_CameraReference.transform.position = new Vector3(m_CameraX, m_CameraY, m_CameraZ);
        m_CameraReference.orthographicSize = m_CameraSize;
    }

    void InitHero()
    {
        GameObject instantiatedHero = Instantiate(m_HeroPrefab, new Vector3(m_StartingX, m_StartingY, 0), Quaternion.identity, m_MapReference.transform);
        instantiatedHero.transform.name = "Hero";
        instantiatedHero.GetComponent<Hero>().SetMapRef(m_MapReference.GetComponent<Map>());
        instantiatedHero.GetComponent<Hero>().SetStartingCoords((m_StartingX, m_StartingY));
    }
}
