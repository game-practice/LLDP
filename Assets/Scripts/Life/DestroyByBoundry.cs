using UnityEngine;
using System.Collections;

public class DestroyByBoundry : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {
        Debug.LogFormat ("Destory name:s {0}", other.name);
        Destroy(other.gameObject);
    }
}
