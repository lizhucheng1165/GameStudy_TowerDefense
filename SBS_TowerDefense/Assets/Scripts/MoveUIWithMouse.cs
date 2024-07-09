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
        // ���콺 ��ġ�� RectTransform ��ǥ�� ��ȯ
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            uiElement.parent as RectTransform,
            Input.mousePosition,
            null,
            out localPoint
        );

        // UI ����� ��ġ�� ���콺 ��ġ�� ���� -> �� �Ʒ� ��ưȣ���� �������Ƿ� offset�߰�
        uiElement.anchoredPosition = localPoint + new Vector2(0, 50);
    }
}
