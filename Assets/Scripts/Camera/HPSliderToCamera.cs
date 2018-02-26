using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPSliderToCamera : MonoBehaviour {


    #region Inspector

    public GameObject target;
    public Vector2 offsetPos;
    public float value;
    public float maxHPValue;
    public Slider HPSlider;

    #endregion

    //private Slider HPSlider;
    private RectTransform rectTrans;

    // Use this for initialization
    void Start () {
        //HPSlider = GetComponent<Slider>();
        rectTrans = GetComponent<RectTransform>();

        //value = maxHPValue;
        HPSlider.value = value / maxHPValue;
	}
	
	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            Debug.LogError("Target cannot be null.");
            return;
        }
        //Vector3 tarPos = target.transform.position;
        ////Vector2 pos = RectTransformUtility.WorldToScreenPoint(Camera.main, tarPos);
        //Camera CurrentCamera = GameObject.FindWithTag("GameController").GetComponent<GameController>().CurrentCamera;
        //Vector2 pos = RectTransformUtility.WorldToScreenPoint(CurrentCamera, tarPos);
        //Debug.Log(pos);
        //rectTrans.position = pos + offsetPos;
        //rectTrans.rotation = Camera.current.transform.rotation;

        Camera CurrentCamera = GameObject.FindWithTag("GameController").GetComponent<GameController>().CurrentCamera;

        //transform.position += offsetPos;
        transform.rotation = CurrentCamera.transform.rotation;
	}
}
