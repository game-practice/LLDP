using UnityEngine;
using System.Collections;

public class RectView : MonoBehaviour {

    public float MaxDist = 15.0f;
    public float MinDist = 5.0f;
    public float ScaleSpeed = 30.0f;

    public float LeftLimit = 0.0f;
    public float RightLimit = 100.0f;
    public float MoveSpeed = 30.0f;

    public GameObject Player1;
    public GameObject Player2;
    public float PlayerToCameraLimit = 5.0f;

    public GameObject Follower;
    private bool isFollowed = false;

	// Use this for initialization
	void Start () {}

    private void OnEnable()
    {
        TrySetLimitByPlayers();
        if (null != Follower) isFollowed = true;
    }

    // Update is called once per frame
    void Update () {
        MouseEvent();
	}

    void TrySetLimitByPlayers()
    {
        if ( null == Player1 && null == Player2 ) return;
        //float CameraDist = 10.0f;
        LeftLimit = Player1.transform.position.z - PlayerToCameraLimit;
        RightLimit = Player2.transform.position.z + PlayerToCameraLimit;
    }


    void MouseEvent()
    {
        MouseScaleView();
        if( isFollowed ) {
            GameobjectDraggingView(Follower);
        } else {
            MouseDraggingView();
        }
    }

    void MouseScaleView()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (transform.position.x <= MaxDist)
            {
                transform.position += Vector3.right * ScaleSpeed * Time.deltaTime;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (transform.position.x >= MinDist)
            {
                transform.position -= Vector3.right * ScaleSpeed * Time.deltaTime;
            }
        }
    }

    void MouseDraggingView()
    {
        float TriggerWidth = Screen.width / 5;
        float TriggerHeight = Screen.height / 3;

        if (Input.mousePosition.y > TriggerHeight && Input.mousePosition.y < Screen.height - TriggerHeight)
        {
            if (Input.mousePosition.x < TriggerWidth)
            {
                //Debug.Log("in Left");
                if (transform.position.z > LeftLimit)
                {
                    transform.position -= Vector3.forward * MoveSpeed * Time.deltaTime;
                }
            }
            if (Input.mousePosition.x > Screen.width - TriggerWidth)
            {
                //Debug.Log("in Right");
                if (transform.position.z < RightLimit)
                {
                    transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;

                }

            }
        }
    }

    void GameobjectDraggingView(GameObject go)
    {
        if (null == go) return;
        //transform.position.Set(transform.position.x, transform.position.y, go.transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, go.transform.position.z);

    }


}
