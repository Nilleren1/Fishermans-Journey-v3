using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyhealth : MonoBehaviour
{
    private Image EnemyHealth;
    public float CurrentHealth;
    private float MaxHealth = 4f;
    enemyFollowScript EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = GetComponent<Image>();
        EnemyPrefab = FindObjectOfType<enemyFollowScript>();

    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = EnemyPrefab.Health;
        EnemyHealth.fillAmount = CurrentHealth / MaxHealth;
    }
}
