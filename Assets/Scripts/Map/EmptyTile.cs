using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTile : Tile
{
    Color m_OldColor;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        m_OldColor = spriteRenderer.color;
    }

    void OnMouseEnter()
    {
        PlacementManager.Instance.SubscribeCurrentTile(GetComponent<EmptyTile>());
    }

    void OnMouseExit()
    {
        PlacementManager.Instance.UnsubscribeCurrentTile(GetComponent<EmptyTile>());
    }

    public Color GetDefaultColor()
    {
        return m_OldColor;
    }
}
