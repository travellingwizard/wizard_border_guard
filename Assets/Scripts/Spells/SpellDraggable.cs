using UnityEngine;
using UnityEngine.EventSystems;

public class SpellDraggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform _rectTransform;
    private float _canvasScaleFactor;
    private Vector2 _initialPointerPos;
    private Vector2 _initialObjectPos;
    private Camera _mainCamera;
    private Spell _spell;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasScaleFactor = GetComponentInParent<Canvas>().scaleFactor;
        _mainCamera = Camera.main;
        _spell = gameObject.GetComponent<Spell>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _initialPointerPos = eventData.position;
        _initialObjectPos = _rectTransform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0f;
        _spell.OnCast(worldPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerDelta = eventData.position - _initialPointerPos;
        _rectTransform.position = _initialObjectPos + pointerDelta / _canvasScaleFactor;
    }
}
