using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public AbilityController abilityController;
    [SerializeField] private StatsScriptableObject stats;
    private Stats characterStats;

    private Stat currentHealth;
    private Stat maxHealth;
    private Stat healthRegen;

    // Start is called before the first frame update
    void Start()
    {
        characterStats = new Stats(stats);
        abilityController.Setup(characterStats);
        
        currentHealth = characterStats.GetStatByID("Health");
        maxHealth     = characterStats.GetStatByID("MaxHealth");
        healthRegen   = characterStats.GetStatByID("HealthRegen");
    }

    private void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth.value -= 99;
        }
        
        if (currentHealth.value < maxHealth.value)
        {
            currentHealth.value += healthRegen.value * Time.deltaTime;
        }
    }
}