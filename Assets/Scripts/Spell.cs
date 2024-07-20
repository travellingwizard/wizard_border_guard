using UnityEngine;
using UnityEngine.EventSystems;

public class Spell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform _rectTransform;
    private float _canvasScaleFactor;
    private Vector2 _initialPointerPos;
    private Vector2 _initialObjectPos;
    private Camera _mainCamera;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasScaleFactor = GetComponentInParent<Canvas>().scaleFactor;
        _mainCamera = Camera.main;
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
        Debug.Log($"Pointer up in world coordinates: {worldPosition}");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerDelta = eventData.position - _initialPointerPos;
        _rectTransform.position = _initialObjectPos + pointerDelta / _canvasScaleFactor;
    }
}
