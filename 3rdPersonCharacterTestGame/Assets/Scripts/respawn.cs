using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour {

    public static int levelN = 0;

    Vector3 startPos;
    Quaternion startRot;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        startRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    //for loading levels
    void nextLevel()
    {
        levelN++;
        if (levelN > 1) levelN = 0;
        SceneManager.LoadScene(levelN);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Death")
        {
            transform.position = startPos;
            transform.rotation = startRot;
            GetComponent<Animator>().Play("LOSE00", -1, 0f);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        else if(other.tag == "CheckPoint")
        {
            startPos =other.transform.position;
            startRot = other.transform.rotation;
            Destroy(other.gameObject);
        }
        else if(other.tag == "Goal")
        {
            Destroy(other.gameObject);
            GetComponent<Animator>().Play("WIN00", -1, 0f);
            Invoke("nextLevel", 2f);
        }
    }
}
