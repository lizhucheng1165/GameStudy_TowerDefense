using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    [SerializeField] private int m_money;
    [SerializeField] private int m_killCount;

    public int money { get { return m_money; } set { m_money = value; } }
    public int killCount { get { return m_killCount; } set { m_killCount = value; } }
}
