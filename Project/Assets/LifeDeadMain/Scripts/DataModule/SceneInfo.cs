//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
// 用来记录场景中的分数 和 计算得星的个数
//********************************************************



using UnityEngine;
using System.Collections;

public static class SceneInfo
{
    // 本关结束时的总得分
    public static int MScore = 0;

    /// <summary>
    /// 计算得星数
    /// </summary>
    /// <param name="index">当前关卡数</param>
    /// <param name="time">通过本关所用的时间</param>
    /// <returns></returns>           
    public static int CalculateInfo(int index,float time)
    {

        // 得星数
        int starCount = 0;

        // 数据控制器
        DataController m_dataController = DataController.GetDataInstance();

        int sumScore = m_dataController.GetSumScore(index);

        float sumTime = m_dataController.GetSumTime(index);

        // 计算得分
        /// ..........

        return starCount;
    }

    
    /// <summary>
    /// 刷新当前类的计分器
    /// </summary>
    public static void UpdateInfo()
    {
        MScore = 0;
    }
}
