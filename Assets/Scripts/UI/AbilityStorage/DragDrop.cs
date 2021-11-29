using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] private AbilityType.AType containedAbility;
    public AbilityType.AType ContainedAbility
    {
        get { return containedAbility; }
        private set { containedAbility = value; }
    }

    private RectTransform _rectTransform;
    private Vector3 _prevPosition;
    private CanvasGroup _canvasGroup;
    public AbilitySlot abilitySlot { get; private set; }

    private bool _changed = false;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _prevPosition = _rectTransform.position;

        _canvasGroup = GetComponent<CanvasGroup>();

        abilitySlot = null;

        if (containedAbility == Inventory.AbilityType1)
        {
            abilitySlot = GameObject.Find("Slot1").GetComponent<AbilitySlot>();
            GetComponent<RectTransform>().anchoredPosition = 
                abilitySlot.GetComponent<RectTransform>().anchoredPosition;
        }
        else if (containedAbility == Inventory.AbilityType2)
        {
            abilitySlot = GameObject.Find("Slot2").GetComponent<AbilitySlot>();
            GetComponent<RectTransform>().anchoredPosition =
                abilitySlot.GetComponent<RectTransform>().anchoredPosition;
        }
        else if (containedAbility == Inventory.AbilityType3)
        {
            abilitySlot = GameObject.Find("Slot3").GetComponent<AbilitySlot>();
            GetComponent<RectTransform>().anchoredPosition =
                abilitySlot.GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        _prevPosition = _rectTransform.position;
        abilitySlot = null;
        _changed = false;

        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        if (_changed == false)
            _rectTransform.position = _prevPosition;

        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData) {}

    public void SetAbilitySlot(AbilitySlot abilitySlot)
    {
        this.abilitySlot = abilitySlot;
        _changed = true;

        Debug.Log(abilitySlot.gameObject.name + ", " + name);
    }
}
