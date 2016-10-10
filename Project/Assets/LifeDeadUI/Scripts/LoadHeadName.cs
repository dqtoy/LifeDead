using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadHeadName : MonoBehaviour {

    private Text m_headNameText;
    private string m_playerName;
    void Start () {
        m_headNameText = GameObject.Find("HeadNameText").GetComponent<Text>();
        m_playerName = PlayerPrefs.GetString("PlayerName");
    }

	void Update () {
        switch (m_playerName)
        {
            case "Ninja":
                m_headNameText.text = "忍者";
                break;
            case "Wizard":
                m_headNameText.text = "巫师";
                break;
            case "EyeMonter":
                m_headNameText.text = "怪物";
                break;
            case "Girl":
                m_headNameText.text = "女孩";
                break;
            case "Knight":
                m_headNameText.text = "佣兵";
                break;
            case "Mummy":
                m_headNameText.text = "木乃伊";
                break;
        }
	}
}
