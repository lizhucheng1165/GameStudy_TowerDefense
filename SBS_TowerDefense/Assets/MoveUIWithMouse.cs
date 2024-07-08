using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUIWithMouse : MonoBehaviour
{
    public RectTransform uiElement;

    void Update()
    {
        Vector2 localPoint;
        // 마우스 위치를 RectTransform 좌표로 변환
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            uiElement.parent as RectTransform,
            Input.mousePosition,
            null,
            out localPoint
        );

        // UI 요소의 위치를 마우스 위치로 설정
        uiElement.anchoredPosition = localPoint;
    }
}
