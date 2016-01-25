using UnityEngine;
using System.Collections;

public class ClickEnterGame : MonoBehaviour {
    public SceneManager sceneManager;
    public string nextSceneName;
    public UILabel lab_InputID;
    public UILabel lab_BtnID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        if (CheckString(lab_InputID, "ID") && CheckString(lab_BtnID, "Server"))
        {
            //进入游戏场景
            sceneManager.gameObject.SetActive(true);
            sceneManager.StartCoroutineToLoadScene(nextSceneName);
        }
    }

    bool CheckString(UILabel uilab, string checkWord)
    {
        if (uilab.text == checkWord)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
