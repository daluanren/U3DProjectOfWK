using UnityEngine;
using System.Collections;

public class ClickShowAndHideObjs : MonoBehaviour {

    public GameObject[] beShowObjs;
    public GameObject[] beHideObjs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SetObjsActive(beShowObjs, true);
        SetObjsActive(beHideObjs, false);
    }

    void SetObjsActive(GameObject[] objs, bool active)
    {
        if (objs.Length != 0)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] != null) objs[i].SetActive(active);
            }
        }
    }
}
