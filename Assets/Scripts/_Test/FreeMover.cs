using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FreeMover : MonoBehaviour {

    public float Speed = 5.0f;
    public Transform CameraTransform;

    private Dictionary<string, KeyCode> KeyMap = new Dictionary <string, KeyCode>();

	// Use this for initialization
	void Start () {
        if (CameraTransform == null)
            Debug.Log("Cannot find 'CameraTransform' Object");
        KeyMapInit();
	}
	
	// Update is called once per frame
	void Update () {
        KeyboardEvent();
	}

    void KeyMapInit()
    {
        KeyMap.Add("Forward", KeyCode.W);
        KeyMap.Add("Backward", KeyCode.S);
        KeyMap.Add("Right", KeyCode.D);
        KeyMap.Add("Left", KeyCode.A);
        KeyMap.Add("Up", KeyCode.Space);
        KeyMap.Add("Down", KeyCode.LeftControl);
    }

    void KeyboardEvent()
    {
        if (Input.GetKey(KeyMap["Forward"]))
        {
            transform.position += CameraTransform.forward * Time.deltaTime * Speed;
        } 
        if (Input.GetKey(KeyMap["Backward"]))
        {
            transform.position -= CameraTransform.forward * Time.deltaTime * Speed;
        } 

        if (Input.GetKey(KeyMap["Right"]))
        {
            transform.position += CameraTransform.right * Time.deltaTime * Speed;
        } 
        if (Input.GetKey(KeyMap["Left"]))
        {
            transform.position -= CameraTransform.right * Time.deltaTime * Speed;
        } 

        if (Input.GetKey(KeyMap["Up"]))
        {
            transform.position += CameraTransform.up * Time.deltaTime * Speed;
        } 
        if (Input.GetKey(KeyMap["Down"]))
        {
            transform.position -= CameraTransform.up * Time.deltaTime * Speed;
        } 
    }


}

