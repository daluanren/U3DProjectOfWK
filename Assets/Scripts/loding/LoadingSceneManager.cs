using UnityEngine;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour 
{
    public static LoadingSceneManager m_instence;
    public UISlider loading_bar;  //loading组
    public float ld_speed = 0.1f;

    void Awake()
    {
        m_instence = this;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        //**************************************test改进****************************************
        if (loading_bar.value < 100) loading_bar.value += Time.deltaTime * ld_speed;
        //**************************************test****************************************

	}

    public void UnloadLoadingScene()
    {
        //**************************************test改进****************************************
        //卸载场景前使得loading到100
        loading_bar.value = 100;
        //**************************************test****************************************
        Debug.Log("卸载loading场景!");
        GameObject.Destroy(this.gameObject);
    }
}
