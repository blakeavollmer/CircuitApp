using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to use simple text

public class IntroductionManager : MonoBehaviour
{

    public List<Introduction> Introductions = new List<Introduction>();

    public Text expText;

    private static IntroductionManager instance;
    public static IntroductionManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<IntroductionManager>(); // assigns instances

            // no object found as IntroductionManager...
            if (instance == null)
                Debug.Log("No Introduction Manager found.");

            return instance;
        }
    }

    private static Introduction currentIntroduction;


	// Use this for initialization
	void Start ()
    {
        SetNextIntroduction(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentIntroduction)
            currentIntroduction.CheckIfHappening();
		
	}

    public void CompletedIntroduction()
    {

        SetNextIntroduction(currentIntroduction.Order + 1);
    }


    public void SetNextIntroduction(int currentOrder)
    {
        currentIntroduction = GetIntroductionByOrder(currentOrder);

        // is there intro left?
        if(!currentIntroduction)
        {
            CompletedAllIntroduction();
            //return;
        }

        //expText.text = currentIntroduction.Explanation;
    }

    public void CompletedAllIntroduction()
    {
        //expText.text = "This concludes the Introduction.";

        // load scene ???????????????????
    }

    public Introduction GetIntroductionByOrder(int Order)
    {
        for (int i = 0; i < Introductions.Count; i++)
        {
            if (Introductions[i].Order == Order)
                return Introductions[i];
        }

        return null; //if returns null, either an error or introduction is complete
    } 

    public static int FindCurrentIntroduction()
    {
        int current = currentIntroduction.Order;
        return current;
    }


}
