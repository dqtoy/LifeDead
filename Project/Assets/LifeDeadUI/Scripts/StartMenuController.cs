using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartMenuController : MonoBehaviour {
    private Button m_startButton;
    private Button m_musicButton;
    private Button m_endButton;
    private RectTransform m_musicView;
    private Button m_closeButton;
	void Awake () {
        m_startButton = GameObject.Find("StartButton").GetComponent<Button>();
        m_startButton.onClick.AddListener(StartButtonAction);

        m_musicButton = GameObject.Find("MusicButton").GetComponent<Button>();
        m_musicButton.onClick.AddListener(MusicButtonAction);

        m_endButton= GameObject.Find("EndButton").GetComponent<Button>();
        m_endButton.onClick.AddListener(EndButtonAction);
        m_closeButton = GameObject.Find("CloseMusicView").GetComponent<Button>();
        m_closeButton.onClick.AddListener(CloseButtonAction);

        m_musicView = GameObject.Find("Musicview").GetComponent<RectTransform>();
    }

    #region 开始游戏按钮
    public void StartButtonAction()
    {
        SceneManager.LoadScene(1);
    }
    #endregion
    #region 音乐按钮
    public void MusicButtonAction()
    {
        m_musicView.DOLocalMoveX(0, 0.5f);
    }
    #endregion
    #region 结束游戏按钮
    public void EndButtonAction()
    {
        Application.Quit();
    }
    #endregion
    #region 关闭界面按钮
    public void CloseButtonAction()
    {
        m_musicView.DOLocalMoveX(-900, 0.5f);
    }
    #endregion

}
