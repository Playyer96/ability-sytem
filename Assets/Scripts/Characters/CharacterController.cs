using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public AbilityController abilityController;
    
    [SerializeField] private StatsScriptableObject stats;
    
    private Stats characterStats;
    private Stat currentHealth;
    private Stat maxHealth;
    private Stat healthRegen;
    private Stat currentMana;
    private Stat maxMana;
    private Stat ManaRegen;
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
        
        currentMana = characterStats.GetStatByID("Mana");
        maxMana       = characterStats.GetStatByID("MaxMana");
        ManaRegen     = characterStats.GetStatByID("ManaRegen");
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
        
        //Mana
        if (currentMana.value < maxMana.value)
        {
            currentMana.value += ManaRegen.value * Time.deltaTime;
        }
        abilityController.CheckCosts();
    }
}