using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerMenuController : MonoBehaviour {

    private Button m_leftButton;
    private Button m_rightButton;
    private Button m_jumpButton;
    private Button m_skillButton;
    private Button m_stopButton;
    private Button m_continueButton;
    private Button m_replayButton;
    private Button m_returnButton;

    private Scrollbar m_countdownBar;
    private RectTransform m_selectBar;
    void Awake () {
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
        m_countdownBar = GameObject.Find("CountDownBar").GetComponent<Scrollbar>();
        m_selectBar = GameObject.Find("SelectBar").GetComponent<RectTransform>();
    }
	
	void Update () {

        StartCoroutine(CountDown());
    }
    #region 左键点击事件
    public void LeftButtonAction()
    {

    }
    #endregion
    #region 右键点击事件
    public void RightButtonAction()
    {

    }
    #endregion
    #region 跳键点击事件
    public void JumpButtonAction()
    {

    }
    #endregion
    #region 技能键点击事件
    public void SkillButtonAction()
    {

    }
    #endregion
    #region 暂停键点击事件
    public void StopButtonAction()
    {
        m_selectBar.DOLocalMoveY(0, 0.5f);
    }
    #endregion
    #region 继续游戏点击事件
    public void ContinueButtonAction()
    {
        m_selectBar.DOLocalMoveY(600, 0.5f);
    }
    #endregion
    #region 重玩点击事件
    public void ReplayButtonAction()
    {
        m_selectBar.DOLocalMoveY(600, 0.5f);
    }
    #endregion
    #region 返回点击事件
    public void ReturnButtonAction()
    {
        m_selectBar.DOLocalMoveY(600, 0.5f);
    }
    #endregion
    #region 携程事件
    IEnumerator CountDown()
    {
        m_countdownBar.value -= Time.deltaTime * 0.03f;

        yield return new WaitForSeconds(3);
    }
    #endregion
    #region 当倒计时为0
    public void CountZeroAction()
    {

    }
    #endregion


}
