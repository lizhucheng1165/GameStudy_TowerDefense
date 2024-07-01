using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFlicker : MonoBehaviour
{
    [SerializeField] private float m_filckerRate = 0.5f; // �����Ÿ��� �ӵ� (�� ����)
    [SerializeField] private float m_alphaMin = 0.2f; // �ּ� ���İ�
    [SerializeField] private float m_alphaMax = 1f; // �ִ� ���İ�

    private TextMeshPro m_textMeshPro;
    private float m_currentAlpha;
    private bool m_isIncreasing;

    private void Start()
    {
        // �ڽ��� TextMeshPro ������Ʈ ��������
        m_textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        // ���İ� ����
        UpdateAlpha();

        // TextMeshPro ������Ʈ�� ���İ� ������Ʈ
        m_textMeshPro.color = new Color(m_textMeshPro.color.r, m_textMeshPro.color.g, m_textMeshPro.color.b, m_currentAlpha);
    }

    private void UpdateAlpha()
    {
        // ���İ� ���� �Ǵ� ����
        if (m_isIncreasing)
        {
            m_currentAlpha += Time.deltaTime / m_filckerRate;
            if (m_currentAlpha >= m_alphaMax)
            {
                m_isIncreasing = false;
            }
        }
        else
        {
            m_currentAlpha -= Time.deltaTime / m_filckerRate;
            if (m_currentAlpha <= m_alphaMin)
            {
                m_isIncreasing = true;
            }
        }

        // ���İ� ���� ����
        m_currentAlpha = Mathf.Clamp(m_currentAlpha, m_alphaMin, m_alphaMax);
    }
}
