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
        // 数据控制器
        DataController m_dataController = DataController.GetDataInstance();

        // 关卡总分
        int sumScore = m_dataController.GetSumScore(index);

        // 关卡总时间
        float sumTime = m_dataController.GetSumTime(index);
       
        // 计算得分                  
        return StarCount(sumTime, time, sumScore, MScore);
    }

    
    /// <summary>
    /// 刷新当前类的计分器
    /// </summary>
    public static void UpdateInfo()
    {
        MScore = 0;
    }

    /// <summary>
    /// 计算得星算法函数
    /// </summary>
    /// <param name="Time"></param>
    /// <param name="CurTime"></param>
    /// <param name="SumScore"></param>
    /// <param name="CurScore"></param>
    /// <returns></returns>
    private static int StarCount(float Time, float CurTime, float SumScore, float CurScore)
    {                 
        int starcount = 0;
        if (CurTime / Time > 0.3f)
        {
            starcount++;
            if (CurScore / SumScore > 0.3f && CurScore / SumScore < 0.6f)
            {
                starcount++;
            }
            else if (CurScore / SumScore > 0.6f)
            {
                starcount = starcount + 2;
            }
        
            return starcount;
        }
        else if (CurTime / Time < 0.3f)
        {
            if (CurScore / SumScore > 0.3f && CurScore / SumScore < 0.6f)
            {
                starcount++;
            }
            else if (CurScore / SumScore > 0.6f)
            {
                starcount = starcount + 2;
            }
        
            return starcount;
        }
        else
        {      
            return starcount;
        }
    }
}
