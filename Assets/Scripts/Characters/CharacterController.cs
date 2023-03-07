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
    private InputMaster _inputMaster;

    // Start is called before the first frame update
    void Start()
    {
        _inputMaster = new InputMaster();
        _inputMaster.AbilitySystem.Enable();
        characterStats = new Stats(stats);
        abilityController.Setup(characterStats, _inputMaster);
        
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