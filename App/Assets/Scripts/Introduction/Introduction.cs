using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour {

    public int Order;
    public string Explanation;

	// in place of start
	void Awake ()
    {
        IntroductionManager.Instance.Introductions.Add(this); //on awake, will add all steps to list of IntroductionManager
	}

    // will be called from IntroductionManager
    // purposefully empty
    public virtual void CheckIfHappening() { }



} // end class
