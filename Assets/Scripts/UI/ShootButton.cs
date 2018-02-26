using UnityEngine;
using System.Collections;
using UnityEngine.UI;//导入UI包
using System.Collections.Generic;

public class ShootButton : MonoBehaviour {

    public GameObject Player;
    public GameObject ShotPrefab;

    public int ShotLeftNumber = 10;

    private Queue<GameObject> ShotsLeaves;


    void Start()
    {
        //Debug.Log(this.GetComponentInChildren<Text>().text);
        GetComponentInChildren<Text>().enabled = true;


        ShotsLeaves = new Queue<GameObject>();

        GetComponent<Button>().onClick.AddListener(() => { OnClickShot(); });

    }


    void OnClickShot()
    {
        GameObject clone = Instantiate(ShotPrefab, Player.transform.position, Player.transform.rotation) as GameObject;
        clone.GetComponent<BulletMover>().SendMessage("RandomInit"); //SendMessage
        //clone.GetComponent<BulletMover>().RandomInit(); 
        if(ShotsLeaves.Count >= ShotLeftNumber)
        {
            Destroy(ShotsLeaves.Dequeue());
            //ShotsLeaves.Dequeue().SetActive(false);
        }
        ShotsLeaves.Enqueue(clone);
    }
}
