//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public InputField inputfiled;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void buttonActon()
    {
        print("aa");
        PlayerPrefs.SetString("name", inputfiled.text);
        SceneManager.LoadScene("TestScene");
       
    }
}
