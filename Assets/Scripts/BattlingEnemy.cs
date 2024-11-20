using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlingEnemy : MonoBehaviour
{
    [SerializeField]
    HealthBar m_HealthBar;

    MapEntity m_MapEntity;

    const float m_DamageInterval = 0.5f;
    float m_CurrentTime = 0;
    float[] m_HealthPercentages = new float[] { 90, 80, 70, 60, 50, 40, 30, 20, 10 };
    int m_HealthIndex = 0;

    const float m_MaxHealth = 100;
    float m_Health = m_MaxHealth;

    public void SetAssociatedMapEntity(MapEntity _mapEntity) {  m_MapEntity = _mapEntity; }

    private void Awake()
    {
        m_HealthBar.UpdateHealthBar(100 * m_Health / m_MaxHealth);
    }

    public void Hit(float _damage)
    {
        m_Health -= _damage;
        m_HealthBar.UpdateHealthBar(100 * m_Health / m_MaxHealth);
        if (m_Health <= 0)
        {
            BattleManager.Instance.RemoveBattlingEnemy(GetComponent<BattlingEnemy>());
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
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
}
