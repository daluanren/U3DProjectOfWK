using UnityEngine;
using System.Collections;

public class ClickChooseServer : MonoBehaviour {
    public UILabel lab_serverName;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        lab_serverName.text = this.transform.FindChild("Label").GetComponent<UILabel>().text;
        lab_serverName.transform.localPosition = new Vector3(75.0f, lab_serverName.transform.localPosition.y, lab_serverName.transform.localPosition.z);
        lab_serverName.alpha = 1;
    }
}
