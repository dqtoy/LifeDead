//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class DoorWayScript : MonoBehaviour
{

    // 数据控制器
    public DataController m_dataController;

    // 当前关卡解锁人物
    public int m_unLockPlayerNum;

    // 当前关卡名称 外部提供
    public string m_sceneName;
    
    // 时间控制器
    private GameObject m_timeController;
   
    // 本关所用时间
    private int m_currentTime;
    
    // 本关的星数
    private int m_starCount;
    

    void Start()
    {
        // 获取数据控制器单例类
        m_dataController = DataController.GetDataInstance();
        // 获取时间控制器
        m_timeController = GameObject.FindWithTag("TimeController");                
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            StartCoroutine("GoToSecletScene");         
        }
    }

    IEnumerator GoToSecletScene()
    {

        m_dataController.LoadLevelData(1);

        
        // 获取本关所用时间
        m_currentTime = (int)m_timeController.GetComponent<TimeController>().m_currentTime;
       
        print("本关所用时间"+m_currentTime);

        // 获取所有当前关卡要存储的数据 封装到LevelData类中
        m_starCount = SceneInfo.CalculateInfo(SubstringLevelName(m_sceneName)-1, m_currentTime);
      
        print("得星个数"+ m_starCount);

        // 封装用户数据
        LevelData leveData = new LevelData();
        leveData.Name = SubstringLevelName(m_sceneName);
        leveData.Score = SceneInfo.MScore;
        leveData.Time = m_currentTime;
        leveData.StarNum = m_starCount;


        // 加载本地数据
        m_dataController.LoadJsonData();

        int unLockPlayer = m_dataController.GetUnLockPlayer();

        int unCurrentLevel = m_dataController.GetlevelCurrent();
       
        // 判断是否保存场景数据
        if(m_unLockPlayerNum > unLockPlayer || SubstringLevelName(m_sceneName) >unCurrentLevel)
        {          
            // 保存数据
            m_dataController.SaveData(m_unLockPlayerNum, SubstringLevelName(m_sceneName), leveData);
        }

        // 刷新SceneInfo类中的计分器
        SceneInfo.UpdateInfo();

        yield return new WaitForSeconds(2);
       
        // 场景切换
        SceneManager.LoadScene("SelectCustoms");
    }

    // 截取关卡名称的关卡数
    int SubstringLevelName(string m_levelCurrentName)
    {
        string strLevelName = m_levelCurrentName;
        string strtempn = "n";
        int IndexofN = strLevelName.IndexOf(strtempn);
        int levelNum = Convert.ToInt32(strLevelName.Substring(IndexofN + 1));
        return levelNum;
    }
}
