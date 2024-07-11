using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RatingColorConfig", menuName = "ScriptableObjects/RatingColorConfig", order = 1)]

public class RatingColorConfig : ScriptableObject
{
    [SerializeField] private List<Color> m_ratingColors;
    //[SerializeField] private Color m_ratingColor_1;
    //[SerializeField] private Color m_ratingColor_2;
    //[SerializeField] private Color m_ratingColor_3;
    //[SerializeField] private Color m_ratingColor_4;
    //[SerializeField] private Color m_ratingColor_5;
    //[SerializeField] private Color m_ratingColor_6;

    public List<Color> ratingColors { get { return m_ratingColors; } }
    //public Color ratingColor_1 { get { return m_ratingColor_1; } }
    //public Color ratingColor_2 { get { return m_ratingColor_2; } }
    //public Color ratingColor_3 { get { return m_ratingColor_3; } }
    //public Color ratingColor_4 { get { return m_ratingColor_4; } }
    //public Color ratingColor_5 { get { return m_ratingColor_5; } }
    //public Color ratingColor_6 { get { return m_ratingColor_6; } }
}
