using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlingHero : MonoBehaviour
{
    [SerializeField]
    HealthBar m_HealthBar;
    [SerializeField]
    AttackBar m_AttackBar;
    [SerializeField]
    WalkingHero m_WalkingHero;

    BattlingEnemy m_BattlingEnemy;

    const float m_DamageInterval = 0.5f;
    float m_CurrentTime = 0;
    const float m_AttackInterval = 2f;
    float m_CurrentAttackTime = 0;
    float[] m_HealthPercentages = new float[] { 90, 80, 70, 60, 50, 40, 30, 20, 10, 0};
    int m_HealthIndex = 0;

    void Update()
    {
        UpdateAttackBar();
    }

    void FixedUpdate()
    {
        //UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        m_CurrentTime += Time.fixedDeltaTime;
        if (m_DamageInterval > m_CurrentTime)
            return;
        m_CurrentTime = 0;
        if (m_HealthIndex >= m_HealthPercentages.Length)
            return;
        m_HealthBar.UpdateHealthBar(m_HealthPercentages[m_HealthIndex]);
        m_HealthIndex++;
    }

    void UpdateAttackBar()
    {
        m_CurrentAttackTime += Time.deltaTime;
        if (m_AttackInterval < m_CurrentAttackTime)
        {
            m_CurrentAttackTime = 0;
            AttackEnemy();
        }
        m_AttackBar.UpdateAttackBar(100 * m_CurrentAttackTime / m_AttackInterval);
    }

    void AttackEnemy()
    {
        m_BattlingEnemy.Hit(10);
    }

    public void SetBattlingEnemy(BattlingEnemy _battlingEnemy){ m_BattlingEnemy = _battlingEnemy; }
    public WalkingHero GetWalkingHero() { return m_WalkingHero; }
}
