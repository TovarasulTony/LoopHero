using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    GameObject m_TilePrefab;

    void OnMouseDown()
    {
        PlacementManager.Instance.SetCurrentCard(m_TilePrefab.GetComponent<Tile>());
    }
}
