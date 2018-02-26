using UnityEngine;
using System.Collections;

public class FirstViewScript : MonoBehaviour {
	//定义枚举数据结构，将名称和设置关联起来
	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityHor = 9.0f;     //水平旋转的速度
	public float sensitivityVert = 9.0f;    //垂直旋转的速度
	public float minimumVert = -70.0f;      //垂直旋转的最小角度
	public float maximumVert = 70.0f;       //垂直旋转的最大角度
    public float thirdViewDist = 2.0f;      //第三视角的距离

    public Transform PlayerTransform;

	private float _rotationX = 0;           //记录垂直角度
    private bool _parseESC = false;
    private bool _thirdView = false;
    private Vector3 _curForward;


	void Start()
	{
		//将光标锁定到游戏窗口的中心。
		//Cursor.lockState = CursorLockMode.Locked;

		Cursor.visible = false;
        _curForward = transform.forward;
	}



	void Update()
	{
        MouseMoveEventUpdate();
        KeyboardEventUpdate();

        //Vector3 CameraForwardToXZ = Vector3.Normalize(new Vector3(transform.forward.x, 0, transform.forward.z));
        //Debug.LogFormat("Ca: {0}, Player: {1}", transform.forward, PlayerTransform.forward);
        //Debug.LogFormat("Ca: {0}, Player: {1}", CameraForwardToXZ, PlayerTransform.forward);

	}

    void MouseMoveEventUpdate()
    {
        if (_parseESC) return;

        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        float rotationY = transform.localEulerAngles.y;             //保持y轴与原来一样
        //float delta = Input.GetAxis("Mouse X") * sensitivityHor;    //水平旋转的变化量

        if (_thirdView)
        {
            transform.position += _curForward * thirdViewDist;      // change camera to origin
        }

        //transform.localEulerAngles = new Vector3(_rotationX, rotationY + delta, 0);//相对于全局坐标空间的角度

       // PlayerTransform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        //PlayerTransform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

        switch (axes)
        {
            case RotationAxes.MouseX:
                PlayerTransform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
               // transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
                break;

            case RotationAxes.MouseY:
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                break;

            case RotationAxes.MouseXAndY:
                //transform.localEulerAngles = new Vector3(_rotationX, rotationY + delta, 0);//相对于全局坐标空间的角度
                PlayerTransform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                break;
        }

        if (_thirdView)
        {
            _curForward = transform.forward;                        // update forward
            transform.position -= _curForward * thirdViewDist;
        }

    }

    void KeyboardEventUpdate()
    {
        //当点击esc后
        if (Input.GetKeyDown("escape"))
        {
            Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;//将光标限制在游戏窗口。

            _parseESC = true;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _parseESC = false;
        }
        if (Input.GetKeyDown("v"))
        {
            _curForward = transform.forward;

            if (_thirdView) 
                transform.position += _curForward * thirdViewDist;
            else
                transform.position -= _curForward * thirdViewDist;
            _thirdView = !_thirdView;
        }
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("r pressed");
            PlayerTransform.forward = new Vector3(0, 0, 1);
            transform.forward = new Vector3(0,0,1);
        }
    }


}
