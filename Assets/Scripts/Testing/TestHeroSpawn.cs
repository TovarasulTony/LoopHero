using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeroSpawn : MonoBehaviour
{
    [SerializeField]
    Hero m_HeroPrefab;

    [Header("Spawning enemy road's coords")]
    [SerializeField]
    const int m_StartingX = 8;
    [SerializeField]
    const int m_StartingY = 8;
    void Start()
    {
        Hero instantiatedHero = Instantiate(m_HeroPrefab, new Vector3(m_StartingX, m_StartingY, 0), Quaternion.identity);
        instantiatedHero.transform.name = "Hero";
        instantiatedHero.GetWalkingHero().SetStartingCoords((m_StartingX, m_StartingY));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
