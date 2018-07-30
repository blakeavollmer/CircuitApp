using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public int Order;
    public Text Explanation;


	void Awake () {
        TutorialManager.Instance.Tutorials.Add(this);
	}


    public virtual void CheckIfHappening() { }
	
}
