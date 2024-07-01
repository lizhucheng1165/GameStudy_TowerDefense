using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFlicker : MonoBehaviour
{
    [SerializeField] private float m_filckerRate = 0.5f; // 깜빡거리는 속도 (초 단위)
    [SerializeField] private float m_alphaMin = 0.2f; // 최소 알파값
    [SerializeField] private float m_alphaMax = 1f; // 최대 알파값

    private TextMeshPro m_textMeshPro;
    private float m_currentAlpha;
    private bool m_isIncreasing;

    private void Start()
    {
        // 자신의 TextMeshPro 컴포넌트 가져오기
        m_textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        // 알파값 변경
        UpdateAlpha();

        // TextMeshPro 오브젝트의 알파값 업데이트
        m_textMeshPro.color = new Color(m_textMeshPro.color.r, m_textMeshPro.color.g, m_textMeshPro.color.b, m_currentAlpha);
    }

    private void UpdateAlpha()
    {
        // 알파값 증가 또는 감소
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

        // 알파값 범위 제한
        m_currentAlpha = Mathf.Clamp(m_currentAlpha, m_alphaMin, m_alphaMax);
    }
}
