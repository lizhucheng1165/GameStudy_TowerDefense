using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUIWithMouse : MonoBehaviour
{
    public RectTransform uiElement;
    public static bool isMouseOverButton;

    private void Awake()
    {
        isMouseOverButton = false;
    }

    void Update()
    {
        if (isMouseOverButton)
        {
            MoveUIElementToMousePosition();
        }
        else
        {
            uiElement.anchoredPosition = new Vector2(-500,-500);
        }
    }

    public void MoveUIElementToMousePosition()
    {
        Vector2 localPoint;
        // 마우스 위치를 RectTransform 좌표로 변환
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            uiElement.parent as RectTransform,
            Input.mousePosition,
            null,
            out localPoint
        );

        // UI 요소의 위치를 마우스 위치로 설정 -> 맨 아래 버튼호버시 가려지므로 offset추가
        uiElement.anchoredPosition = localPoint + new Vector2(0, 50);
    }
}
