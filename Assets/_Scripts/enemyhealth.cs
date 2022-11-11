using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyhealth : MonoBehaviour
{
    private Image EnemyHealth;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    Enemy EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = GetComponent<Image>();
        EnemyPrefab = FindObjectOfType<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = EnemyPrefab.currentHealth;
        EnemyHealth.fillAmount = CurrentHealth / MaxHealth;
    }
}
