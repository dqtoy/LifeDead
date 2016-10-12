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

    public DataController m_dataController;

    public int m_unLockPlayerNum;

    public string m_sceneName;

    public GameObject m_timeController;

    public float m_currentTime;

    public int m_starCount;


    void Start()
    {
        m_dataController = DataController.GetDataInstance();
        m_timeController = GameObject.FindWithTag("TimeController");
        m_currentTime = m_timeController.GetComponent<TimerController>().m_currentTime;
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
        // 获取所有当前关卡要存储的数据 封装到LevelData类中
        m_starCount = SceneInfo.CalculateInfo(SubstringLevelName(m_sceneName), m_currentTime);

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
       
        SceneManager.LoadScene("SelectCustoms");
    }

    // 截取关卡名称的关卡数
    int SubstringLevelName(string m_levelCurrentName)
    {
        string strLevelName = m_levelCurrentName;
        string strtempn = "n";
        int IndexofN = strLevelName.IndexOf(strtempn);
        int levelNum = Convert.ToInt32(strLevelName.Substring(IndexofN + 1));
        return levelNum+1;
    }
}
