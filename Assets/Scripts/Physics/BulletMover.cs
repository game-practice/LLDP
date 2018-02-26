using UnityEngine;
using System.Collections;

public class BulletMover : MonoBehaviour {


    public float Speed = 2.0f;
    public float InitialAngle = 45.0f; // to horizontal plane
    public float g = 1.0f;

    private Rigidbody rb;

    private Camera ca;
    public bool Active = true;


	// Use this for initialization
	void Start () {
        //Debug.Log("B Start");
        rb = GetComponent<Rigidbody>(); /*添加Rigidbody组件*/
        rb.useGravity = false;
        float InitialRadius = InitialAngle / 180 * Mathf.PI;
        // 炮弹旋转
        transform.eulerAngles = new Vector3(InitialAngle, transform.eulerAngles.y, transform.eulerAngles.z); 

        // 速度初始化 （后x 右y 上z）
        rb.velocity = new Vector3(0, Speed * Mathf.Sin(InitialRadius), Speed * Mathf.Cos(InitialRadius));
        //Debug.LogFormat("{0}={1}",Mathf.Sin(InitialAngle), Speed * Mathf.Cos(InitialAngle));
    }

    void RandomInit()
    {
        //Debug.Log("B RandomInit");
        Speed = Random.value * 2.0f + 5.0f;
        InitialAngle = 30.0f; //Random.value * 90.0f;
    }

    void Init(float s, float a)
    {
        Speed = s;
        InitialAngle = a;
    }
	
    void FixedUpdate(){
        if (!Active) // 水平面以下
        {
            rb.velocity = Vector3.zero;
            return;
        };


        float angle = 180 / Mathf.PI * Mathf.Atan( rb.velocity.z / rb.velocity.y );
        //Debug.Log(angle);
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z); 

        //rb.AddForce(Input.gyro.gravity * rb.mass);
        if (!rb.useGravity){
            rb.AddForce(-Vector3.up * g * rb.mass);
        }
    }

	// Update is called once per frame
	void Update () {}


}
