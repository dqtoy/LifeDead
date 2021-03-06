﻿//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
using System;


public class DataController
{
    #region 字段
    // 关卡数据Model
    private LevelData m_levelData;

    // 获取数据的parseDate的引用对象
    JsonData parseDate;

    // 自身引用
    private static DataController DataInstance;

    //路径
    string path = "";
    #endregion

    #region 单例基本类
    /// <summary>
    /// 私有构造方法
    /// </summary>
    private DataController ()
	{		
        path = "/StreamingAssets/DataJson.json";

        m_levelData = new LevelData();
               
        // 刷新数据
        LoadJsonData();
    }

	/// <summary>
	/// 静态单例类
	/// </summary>
	/// <returns>DataController</returns>
	public static DataController GetDataInstance ()
	{
		if (DataInstance != null) {
			return DataInstance;
		}

		DataInstance = new DataController ();

		return DataInstance;
	}
    #endregion

    #region 数据更新
    /// <summary>
    /// 更新数据
    /// 加载数据 
    /// </summary>
    public void LoadJsonData()
    {    
        FileInfo file = new FileInfo(Application.dataPath + path);
        StreamReader sr = new StreamReader(file.OpenRead(), Encoding.UTF8);
        string content = sr.ReadToEnd();
        sr.Close();
        sr.Dispose();
        // 开始解析
        // 使用JsonMapper将content文本转换为JsonData对象
        parseDate = JsonMapper.ToObject(content);
    }
    #endregion

    #region 获取文件数据
    /// <summary>
    /// 返回当前解锁人物计数器
    /// </summary>
    /// <returns>当前人物</returns>
    public int GetUnLockPlayer ()
	{
        // 获取数据      
        return (int)parseDate["PlayerCount"];      
	}

	/// <summary>
	/// 返回当前解锁关卡
	/// </summary>
	/// <returns>当前关卡</returns>
	public int GetlevelCurrent ()
	{
        return (int)parseDate["LevelCurrent"];
    }

    /// <summary>
    /// 获取当前关卡一共的分数
    /// </summary>
    /// <param name="index">当前关卡</param>
    /// <returns></returns>
    public int GetSumScore(int index)
    {
        return (int)parseDate["LevelData"][index]["SumScore"];
    }

    /// <summary>
    /// 获取当前关卡的总时间
    /// </summary>
    /// <param name="index">当前关卡</param>
    /// <returns></returns>

    public int GetSumTime(int index)
    {    
        return (int)parseDate["LevelData"][index]["SumTime"];   
    }

    /// <summary>
    /// 获取开场动画计数器
    /// </summary>
    /// <returns></returns>
    public int GetStartAnimationIndex()
    {
        return (int)parseDate["IsPlayStartAnimation"];
    }

    /// <summary>
    /// 设置开场动画计数器
    /// </summary>
    /// <param name="index">0为没有播放过，1为播放过</param>
    public void SetStartAnimationIndex(int index)
    {
        parseDate["IsPlayStartAnimation"] = index;

        // 文件数据写入
        FileStream file = new FileStream(Application.dataPath + path, FileMode.Create);
        byte[] bts = System.Text.Encoding.UTF8.GetBytes(parseDate.ToJson());
        file.Write(bts, 0, bts.Length);
        if (file != null)
        {
            file.Close();
        }
    }

    /// <summary>
    /// 获取当前关卡的得分数据
    /// </summary>
    /// <param name="index">当前关卡</param>
    /// <returns></returns>
    public LevelData LoadLevelData(int index)
    {                  
        m_levelData.Name = (int)parseDate["LevelData"][index]["Name"];      
        m_levelData.StarNum = (int)parseDate["LevelData"][index]["StarNum"];
        m_levelData.Score = (int)parseDate["LevelData"][index]["Score"];
        m_levelData.SumScore = (int)parseDate["LevelData"][index]["SumScore"];
        m_levelData.Time = (int)parseDate["LevelData"][index]["Time"];
        return m_levelData;
    }
    #endregion

    #region 保存文件数据
    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="m_playerUnLockCount"></param>
    /// <param name="m_levelCurrent"></param>
    public void SaveData (int m_playerUnLockCount, int m_levelCurrent,LevelData levelData)
	{
        // 保存解锁关卡信息和解锁人物信息
        parseDate["PlayerCount"] = m_playerUnLockCount;
        parseDate["LevelCurrent"] = m_levelCurrent;

        // Json数据从0开始计数 第一关为第0个对象
        levelData.Name -= 1;

        // 保存当前关卡的玩家信息
        parseDate["LevelData"][levelData.Name]["Time"] = levelData.Time;
        parseDate["LevelData"][levelData.Name]["StarNum"] = levelData.StarNum;
        parseDate["LevelData"][levelData.Name]["Score"] = levelData.Score;
               
        // 文件写入
        FileStream file = new FileStream (Application.dataPath + path, FileMode.Create);
		byte[] bts = System.Text.Encoding.UTF8.GetBytes (parseDate.ToJson ());
		file.Write (bts, 0, bts.Length);
		if (file != null) {
			file.Close ();
		}
	}
    #endregion
}







