using UnityEngine;

public static class Inventory
{
    /*[SerializeField] private static List<AbilityType.AType> allAbilityTypes;
    public static List<AbilityType.AType> AllAbilityTypes
    {
        get { return allAbilityTypes; }
        set { allAbilityTypes = value; }
    }*/
    [SerializeField] private static AbilityType.AType abilityType1 = AbilityType.AType.FireCannon, 
        abilityType2 = AbilityType.AType.None, abilityType3 = AbilityType.AType.None;
    public static AbilityType.AType AbilityType1
    {
        get { return abilityType1; }
        set { abilityType1 = value; }
    }
    public static AbilityType.AType AbilityType2
    {
        get { return abilityType2; }
        set { abilityType2 = value; }
    }
    public static AbilityType.AType AbilityType3
    {
        get { return abilityType3; }
        set { abilityType3 = value; }
    }
}
