using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RatingTextConfig", menuName = "ScriptableObjects/RatingTextConfig", order = 1)]

public class RatingTextConfig : ScriptableObject
{
    [SerializeField] private List<string> m_ratingTexts;
    //[SerializeField] private string m_ratingText_1;
    //[SerializeField] private string m_ratingText_2;
    //[SerializeField] private string m_ratingText_3;
    //[SerializeField] private string m_ratingText_4;
    //[SerializeField] private string m_ratingText_5;
    //[SerializeField] private string m_ratingText_6;

    public List<string> ratingTexts { get { return m_ratingTexts; } }
    //public string ratingText_1 { get { return m_ratingText_1; } }
    //public string ratingText_2 { get { return m_ratingText_2; } }
    //public string ratingText_3 { get { return m_ratingText_3; } }
    //public string ratingText_4 { get { return m_ratingText_4; } }
    //public string ratingText_5 { get { return m_ratingText_5; } }
    //public string ratingText_6 { get { return m_ratingText_6; } }
}
