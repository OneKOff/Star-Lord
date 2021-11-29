using UnityEngine;
using UnityEngine.EventSystems;

public class AbilitySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private int slotId = 0;
    public int SlotId
    {
        get { return slotId; }
        private set { slotId = value; }
    }

    public DragDrop heldAbility { get; private set; }

    /*private void Awake()
    {
        switch (slotId)
        {
            case 1:
                if (Inventory.AbilityType1 != AbilityType.AType.None)
                {
                    
                }
                break;
            case 2:
                if (Inventory.AbilityType2 != AbilityType.AType.None)
                {

                }
                break;
            case 3:
                if (Inventory.AbilityType3 != AbilityType.AType.None)
                {

                }
                break;
            case 0:
                break;
        }
    }*/

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDropSlot");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
                GetComponent<RectTransform>().anchoredPosition;
            heldAbility = eventData.pointerDrag.GetComponent<DragDrop>();
            heldAbility.SetAbilitySlot(this);

            switch (slotId)
            {
                case 1:
                    Inventory.AbilityType1 = heldAbility.ContainedAbility;
                    Debug.Log("Slot 1: " + Inventory.AbilityType1);
                    break;
                case 2:
                    Inventory.AbilityType2 = heldAbility.ContainedAbility;
                    Debug.Log("Slot 2: " + Inventory.AbilityType2);
                    break;
                case 3:
                    Inventory.AbilityType3 = heldAbility.ContainedAbility;
                    Debug.Log("Slot 3: " + Inventory.AbilityType3);
                    break;
                default:
                    if (Inventory.AbilityType1 == heldAbility.ContainedAbility)
                    {
                        Inventory.AbilityType1 = AbilityType.AType.None;
                    }
                    else if(Inventory.AbilityType2 == heldAbility.ContainedAbility)
                    {
                        Inventory.AbilityType2 = AbilityType.AType.None;
                    }
                    else if (Inventory.AbilityType3 == heldAbility.ContainedAbility)
                    {
                        Inventory.AbilityType3 = AbilityType.AType.None;
                    }
                    break;
            }
        }
    }
}
