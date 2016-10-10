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
    
    void Start()
    {
        m_dataController = DataController.GetDataInstance();
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
        

        m_dataController.LoadJsonData();

        int unLockPlayer = m_dataController.GetUnLockPlayer();

        int unCurrentLevel = m_dataController.GetlevelCurrent();

        // 判断。。。。
        if(m_unLockPlayerNum > unLockPlayer || SubstringLevelName(m_sceneName) >unCurrentLevel)
        {
            // 保存数据
            m_dataController.SaveData(m_unLockPlayerNum, SubstringLevelName(m_sceneName));
        }
                  
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
        return levelNum;
    }
}
