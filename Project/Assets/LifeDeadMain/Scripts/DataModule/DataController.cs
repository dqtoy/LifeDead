//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using LitJson;
using System.IO;
using System.Text;


public class DataController
{
	// 字段
	private int m_playerUnLockCount;
	private int m_levelCurrent;

	// 自身引用
	private static DataController DataInstance;

	/// <summary>
	/// 私有构造方法
	/// </summary>
	private DataController ()
	{
		LoadJsonData ();
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

	/// <summary>
	/// 返回当前解锁人物计数器
	/// </summary>
	/// <returns>当前人物</returns>
	public int GetUnLockPlayer ()
	{
		return m_playerUnLockCount;
	}

	/// <summary>
	/// 返回当前解锁关卡
	/// </summary>
	/// <returns>当前关卡</returns>
	public int GetlevelCurrent ()
	{
		return m_levelCurrent;
	}

	/// <summary>
	/// 更新数据
	/// </summary>
	public void LoadJsonData ()
	{
		
		FileInfo file = new FileInfo (Application.dataPath + "/LifeDeadMain/DataFile/DataJson.json");
		StreamReader sr = new StreamReader (file.OpenRead (), Encoding.UTF8);
		string content = sr.ReadToEnd ();
		sr.Close ();
		sr.Dispose ();
		// 开始解析
		// 使用JsonMapper将content文本转换为JsonData对象
		JsonData parseDate = JsonMapper.ToObject (content);

		// 获取数据
		m_playerUnLockCount = (int)parseDate ["PlayerCount"];
		m_levelCurrent = (int)parseDate ["LevelCurrent"];     
	}

    

	/// <summary>
	/// 保存数据
	/// </summary>
	/// <param name="m_playerUnLockCount"></param>
	/// <param name="m_levelCurrent"></param>
	public void SaveData (int m_playerUnLockCount, int m_levelCurrent)
	{
		JsonData DataFileJson = new JsonData ();
		DataFileJson ["PlayerCount"] = m_playerUnLockCount;
		DataFileJson ["LevelCurrent"] = m_levelCurrent;
       
		FileStream file = new FileStream (Application.dataPath + "/LifeDeadMain/DataFile/DataJson.json", FileMode.Create);
		byte[] bts = System.Text.Encoding.UTF8.GetBytes (DataFileJson.ToJson ());
		file.Write (bts, 0, bts.Length);
		if (file != null) {
			file.Close ();
		}
	}
}







