using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlingHero : MonoBehaviour
{
    [SerializeField]
    HealthBar m_HealthBar;

    const float m_DamageInterval = 0.5f;
    float m_CurrentTime = 0;
    float[] m_HealthPercentages = new float[] { 90, 80, 70, 60, 50, 40, 30, 20, 10};
    int m_HealthIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        m_CurrentTime += Time.fixedDeltaTime;
        if (m_DamageInterval > m_CurrentTime)
            return;
        m_CurrentTime = 0;
        if (m_HealthIndex >= m_HealthPercentages.Length)
            return;
        Debug.Log(m_HealthPercentages[m_HealthIndex]);
        m_HealthBar.UpdateHealthBar(m_HealthPercentages[m_HealthIndex]);
        m_HealthIndex++;
    }
}
