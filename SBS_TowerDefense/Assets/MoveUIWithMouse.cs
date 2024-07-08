using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUIWithMouse : MonoBehaviour
{
    public RectTransform uiElement;

    void Update()
    {
        Vector2 localPoint;
        // ���콺 ��ġ�� RectTransform ��ǥ�� ��ȯ
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            uiElement.parent as RectTransform,
            Input.mousePosition,
            null,
            out localPoint
        );

        // UI ����� ��ġ�� ���콺 ��ġ�� ����
        uiElement.anchoredPosition = localPoint;
    }
}
