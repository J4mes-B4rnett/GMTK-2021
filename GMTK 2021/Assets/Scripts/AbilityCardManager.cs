using System.Collections.Generic;
using UnityEngine;

public class AbilityCardManager : MonoBehaviour
{
    public Controller controller;
    [SerializeField] List<AbilityHolder> abilityHolders;
    private void Awake()
    {

    }
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            abilityHolders.Add(this.transform.GetChild(i).GetComponent<AbilityHolder>());
        }
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateAbilities();
    }
    void UpdateAbilities()
    {
        controller.shellActivated = (abilityHolders.FindIndex(r => r.ability && r.ability.name == "Shell") != -1) ? true : false;
        controller.fastMotion = (abilityHolders.FindIndex(r => r.ability && r.ability.name == "Speed") != -1) ? true : false;
        controller.slowMotion = (abilityHolders.FindIndex(r => r.ability && r.ability.name == "Speed") != -1) ? false : true;
        controller.jump = (abilityHolders.FindIndex(r => r.ability && r.ability.name == "Jump") != -1) ? true : false;

    }
}
