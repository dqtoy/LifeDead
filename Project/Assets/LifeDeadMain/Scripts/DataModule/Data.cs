//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;

public class Data
{
    /// <summary>
    /// 1.解锁了哪些人物
    /// </summary>
    private string[] m_playerArray;
    public string[] PlayerArray
    {
        get { return m_playerArray;  }
        set { m_playerArray = value; }
    }

    /// <summary>
    /// 2.当前过到第几关
    /// </summary>
    private int m_levelCurrent;
    public int LevelCurrent
    {
        get { return m_levelCurrent;  }
        set { m_levelCurrent = value; }
    }

    /// <summary>
    /// 3.每一关的得星数目
    /// </summary>
    public int m_starsCount;
    public int StarsCount
    {
        get { return m_starsCount; }
        set { m_starsCount = value; }
    }   
}


