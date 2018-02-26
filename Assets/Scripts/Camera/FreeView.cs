using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FreeView : MonoBehaviour
{



    // for View
    public float sensitivityHor = 9.0f;     //水平旋转的速度
    public float sensitivityVert = 9.0f;    //垂直旋转的速度
    public float minimumVert = -70.0f;      //垂直旋转的最小角度
    public float maximumVert = 70.0f;       //垂直旋转的最大角度
    public float thirdViewDist = 2.0f;      //第三视角的距离
    private float _rotationX = 0;           //记录垂直角度(以约束
    private bool _pause = false;

    // for Mover
    public float Speed = 15.0f;
    private Dictionary<string, KeyCode> KeyMap = new Dictionary<string, KeyCode>();
    private enum Action { Forward,Backward,Right,Left,Up,Down,Pause,Escape };

	// Use this for initialization
	void Start () {
        KeyMapInit();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //_curForward = transform.forward;
	}

    // Update is called once per frame
    void Update () {
        KeyboardEvent();
        MouseMoveEvent();
	}


    private void OnEnable()
    {
        //将光标锁定到游戏窗口的中心。
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _pause = false;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _pause = true;
    }

    void KeyMapInit()
    {
        KeyMap.Add("Forward", KeyCode.W);
        KeyMap.Add("Backward", KeyCode.S);
        KeyMap.Add("Right", KeyCode.D);
        KeyMap.Add("Left", KeyCode.A);
        KeyMap.Add("Up", KeyCode.Space);
        KeyMap.Add("Down", KeyCode.LeftControl);
        KeyMap.Add("Pause", KeyCode.Escape);
    }

    void MouseMoveEvent()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnEnable();
        }
        if (_pause) return;
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        float rotationY = transform.localEulerAngles.y;             //保持y轴与原来一样
        float delta = Input.GetAxis("Mouse X") * sensitivityHor;    //水平旋转的变化量

        transform.localEulerAngles = new Vector3(_rotationX, rotationY + delta, 0);//相对于全局坐标空间的角度


    }


    void KeyboardEvent()
    {
        if (Input.GetKeyDown(KeyMap["Pause"]))
        {
            OnDisable();
        }
        if (_pause) return;
        if (Input.GetKey(KeyMap["Forward"]))
        {
            transform.position += transform.forward * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyMap["Backward"]))
        {
            transform.position -= transform.forward * Time.deltaTime * Speed;
        }

        if (Input.GetKey(KeyMap["Right"]))
        {
            transform.position += transform.right * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyMap["Left"]))
        {
            transform.position -= transform.right * Time.deltaTime * Speed;
        }

        if (Input.GetKey(KeyMap["Up"]))
        {
            transform.position += transform.up * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyMap["Down"]))
        {
            transform.position -= transform.up * Time.deltaTime * Speed;
        }

    }
}
