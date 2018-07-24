using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class BreadboardHoles : MonoBehaviour, IFocusable {


    // Use this for initialization
    void Start () {
        //transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
        transform.GetComponent<MeshRenderer>().material.color = Color.clear;
    }

    void IFocusable.OnFocusEnter()
    {
        transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    void IFocusable.OnFocusExit()
    {
        //transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
        transform.GetComponent<MeshRenderer>().material.color = Color.clear;
    }

}
