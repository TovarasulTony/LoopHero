using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyPlacement : MonoBehaviour
{
    [SerializeField]
    MapEntity m_MapEntityPrefab;

    [Header("Spawning enemy road's coords")]
    [SerializeField]
    int i;
    [SerializeField]
    int j;

    void Start()
    {
        Tile tile = Map.Instance.GetTileRef((i,j));
        Road road = tile.GetComponent<Road>();
        if(!road)
        {
            Debug.LogError($"Coords ({i},{j}) does not contain a road!");
            return;
        }
        Debug.Log($"Road found with coords ({i},{j})");
        MapEntity enemy = Instantiate(m_MapEntityPrefab, new Vector3(i, j, 0), Quaternion.identity);
        road.AddRoadEntity(enemy);
    }

    void Update()
    {
        
    }
}
