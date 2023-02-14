using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public AbilityController abilityController;
    [SerializeField]
    private StatsScriptableObject stats;
    
    
    // Start is called before the first frame update
    void Start()
    {
        abilityController.Setup(stats);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
