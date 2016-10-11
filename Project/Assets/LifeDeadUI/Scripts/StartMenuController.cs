using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartMenuController : MonoBehaviour
{
    #region 字段
    DataController m_dataController;
    /// <summary>
    /// 开始按钮
    /// </summary>
    private Button m_startButton;
    /// <summary>
    /// 音乐按钮
    /// </summary>
    private Button m_musicButton;
    /// <summary>
    /// 结束按钮
    /// </summary>
    private Button m_endButton;
    /// <summary>
    /// 音乐界面
    /// </summary>
    private RectTransform m_musicView;
    /// <summary>
    /// 音乐界面关闭按钮
    /// </summary>
    private Button m_closeButton;
    #endregion
    #region 初始化
    void Start()
    {
        m_startButton = GameObject.Find("StartButton").GetComponent<Button>();
        m_startButton.onClick.AddListener(StartButtonAction);

        m_musicButton = GameObject.Find("MusicButton").GetComponent<Button>();
        m_musicButton.onClick.AddListener(MusicButtonAction);

        m_endButton = GameObject.Find("EndButton").GetComponent<Button>();
        m_endButton.onClick.AddListener(EndButtonAction);
        m_closeButton = GameObject.Find("CloseMusicView").GetComponent<Button>();
        m_closeButton.onClick.AddListener(CloseButtonAction);

        m_musicView = GameObject.Find("Musicview").GetComponent<RectTransform>();
        m_dataController = DataController.GetDataInstance();
    }
    #endregion

    /// <summary>
    /// 开始游戏事件
    /// </summary>
    public void StartButtonAction()
    {
        m_dataController.LoadJsonData();       
        SceneManager.LoadScene(1);
    }

    /// <summary>
    ///  音乐事件
    /// </summary>
    public void MusicButtonAction()
    {
        m_musicView.DOLocalMoveX(0, 0.5f);
    }

    /// <summary>
    /// 结束游戏事件
    /// </summary>
    public void EndButtonAction()
    {
        Application.Quit();
    }

    /// <summary>
    /// 关闭音乐界面事件
    /// </summary>
    public void CloseButtonAction()
    {
        m_musicView.DOLocalMoveX(-900, 0.5f);
    }
  

}
