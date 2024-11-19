using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBar : MonoBehaviour
{
    [SerializeField]
    Transform m_AttackBar;

    public void UpdateAttackBar(float _percentage)
    {
        float scaleY = m_AttackBar.transform.localScale.y;
        float positionY = m_AttackBar.transform.localPosition.y;
        float positionZ = m_AttackBar.transform.localPosition.z;
        m_AttackBar.transform.localScale = new Vector3(_percentage / 100, scaleY, 1);
        m_AttackBar.transform.localPosition = new Vector3((_percentage - 100) / (100 * 2), positionY, positionZ);
    }
}
