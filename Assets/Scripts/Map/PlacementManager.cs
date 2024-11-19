using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public static PlacementManager Instance { get; private set; }
    Tile m_PlacingTile = null;
    EmptyTile m_EmptyTile = null;


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
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            m_PlacingTile = null;
            HideBuildingGhost();
        }
    }

    public Tile GetCurrentTile()
    {
        return m_PlacingTile;
    }

    public void SetCurrentCard(Tile _tile)
    {
        m_PlacingTile = _tile;
    }

    public void SubscribeCurrentTile(EmptyTile _tile)
    {
        //Debug.Log("SubscribeCurrentTile");
        if (m_EmptyTile)
        {
            Debug.LogError("Current Tile not null!");
        }
        m_EmptyTile = _tile;
        if(!m_PlacingTile)
        {
            return;
        }

        SpriteRenderer referenceSpriteRenderer = m_PlacingTile.GetComponent<SpriteRenderer>();
        SpriteRenderer modifySpriteRenderer = m_EmptyTile.GetComponent<SpriteRenderer>();
        Color newColor = referenceSpriteRenderer.color;
        modifySpriteRenderer.color = newColor;
    }

    public void UnsubscribeCurrentTile(EmptyTile _tile)
    {
        //Debug.Log("UnsubscribeCurrentTile");
        if (!m_EmptyTile)
        {
            Debug.LogError("Current Tile is null!");
        }
        if (m_EmptyTile != _tile)
        {
            Debug.LogError("Current Tile is different from unsubscribed tile!");
        }

        HideBuildingGhost();
        m_EmptyTile = null;
    }

    void HideBuildingGhost()
    {
        SpriteRenderer spriteRenderer = m_EmptyTile.GetComponent<SpriteRenderer>();
        spriteRenderer.color = m_EmptyTile.GetDefaultColor();
    }
}
