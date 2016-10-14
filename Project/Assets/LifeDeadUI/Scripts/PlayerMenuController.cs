using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerMenuController : MonoBehaviour
{
    #region 字段
    private Button m_leftButton;
    private Button m_rightButton;
    private Button m_jumpButton;
    private Button m_skillButton;
    private Button m_stopButton;
    private Button m_continueButton;
    private Button m_replayButton;
    private Button m_returnButton;

    //AudioController m_audioController;

    private RectTransform m_selectBar;
    #endregion

    void Start()
    {
        #region 注册点击事件
        m_leftButton = GameObject.Find("LeftButton").GetComponent<Button>();
        m_leftButton.onClick.AddListener(LeftButtonAction);

        m_rightButton = GameObject.Find("RightButton").GetComponent<Button>();
        m_rightButton.onClick.AddListener(RightButtonAction);

        m_jumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        m_jumpButton.onClick.AddListener(JumpButtonAction);

        m_skillButton = GameObject.Find("SkillButton").GetComponent<Button>();
        m_skillButton.onClick.AddListener(SkillButtonAction);

        m_stopButton = GameObject.Find("StopButton").GetComponent<Button>();
        m_stopButton.onClick.AddListener(StopButtonAction);

        m_continueButton = GameObject.Find("ContinueButton").GetComponent<Button>();
        m_continueButton.onClick.AddListener(ContinueButtonAction);

        m_replayButton = GameObject.Find("ReplayButton").GetComponent<Button>();
        m_replayButton.onClick.AddListener(ReplayButtonAction);

        m_returnButton = GameObject.Find("ReturnButton").GetComponent<Button>();
        m_returnButton.onClick.AddListener(ReturnButtonAction);
        #endregion
        m_selectBar = GameObject.Find("SelectBar").GetComponent<RectTransform>();
        // 播放背景音效
       // m_audioController.GetSceneAudioAbstract().PlayBGAudio(1);
    }
    
    /// <summary>
    /// 左键点击事件
    /// </summary>
    public void LeftButtonAction()
    {
        //m_audioController.GetSceneAudioAbstract().PlayButtonAudioA();
    }

    /// <summary>
    /// 右键点击事件
    /// </summary>
    public void RightButtonAction()
    {

    }

    /// <summary>
    /// 跳键点击事件
    /// </summary>
    public void JumpButtonAction()
    {

    }

    /// <summary>
    /// 技能键点击事件
    /// </summary>
    public void SkillButtonAction()
    {

    }

    /// <summary>
    /// 暂停键点击事件
    /// </summary>
    public void StopButtonAction()
    {
        m_selectBar.DOLocalMoveY(0, 0.5f);
        StartCoroutine(StopTime());
    }

    /// <summary>
    /// 继续游戏点击事件
    /// </summary>
    public void ContinueButtonAction()
    {
        m_selectBar.DOLocalMoveY(600, 0.5f);
    }

    /// <summary>
    /// 重玩点击事件
    /// </summary>
    public void ReplayButtonAction()
    {
        m_selectBar.DOLocalMoveY(600, 0.5f);
    }

    /// <summary>
    /// 返回点击事件
    /// </summary>
    public void ReturnButtonAction()
    {
        m_selectBar.DOLocalMoveY(600, 0.5f);
    }
  
   
    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(0.5f);
        //Time.timeScale = 0;
    }
  
 
    /// <summary>
    /// 当倒计时为0
    /// </summary>
    public void CountZeroAction()
    {

    }
  
}
