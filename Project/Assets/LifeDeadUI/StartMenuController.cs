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
        m_musicButton= GameObject.Find("MusicButton").GetComponent<Button>();
        m_musicButton.onClick.AddListener(MusicButtonAction);
        m_endButton= GameObject.Find("EndButton").GetComponent<Button>();
        m_musicView = GameObject.Find("Musicview").GetComponent<RectTransform>();
        m_closeButton = GameObject.Find("CloseMusicView").GetComponent<Button>();
        m_closeButton.onClick.AddListener(CloseButtonAction);
    }
	
	void Update () {
	
	}
    public void StartButtonAction()
    {
       
    }
    public void MusicButtonAction()
    {
        m_musicView.DOLocalMoveX(0, 0.5f);
    }
    public void EndButtonAction()
    {

    }
    public void CloseButtonAction()
    {
        m_musicView.DOLocalMoveX(-900, 0.5f);
    }
}
