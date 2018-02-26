using UnityEngine;
using System.Collections;

public class StopByContact : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogFormat("Plane Enter: {0}", other.name);
        if (CompareTag("Plane") && other.CompareTag("Bullet"))
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<BulletMover>().Active = false;
        } 
        if (CompareTag("Player2"))
        {
            //Debug.LogFormat(other.gameObject.name);
            other.gameObject.GetComponent<BulletMover>().Active = false;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.LogFormat("Plane Exit: {0}", other.name);
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.LogFormat("Plane Stay: {0}", other.name);
    //}
}
