using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Transform m_GreenHealthBar;

    public void UpdateHealthBar(float _percentage)
    {
        float scaleY = m_GreenHealthBar.transform.localScale.y;
        float positionY = m_GreenHealthBar.transform.localPosition.y;
        float positionZ = m_GreenHealthBar.transform.localPosition.z;
        m_GreenHealthBar.transform.localScale = new Vector3(_percentage/100, scaleY, 1);
        m_GreenHealthBar.transform.localPosition = new Vector3((_percentage - 100) / (100 * 2), positionY, positionZ);
    }
}
