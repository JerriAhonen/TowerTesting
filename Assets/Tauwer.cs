using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tauwer : MonoBehaviour {

	public GameObject tsiken;
	public GameObject[] tsikens;
	public bool updateParents;

	// Use this for initialization
	void Start () {

		tsikens = new GameObject[6];

		for (int i = 0; i < tsikens.Length; i++)
		{
			Vector3 pos = new Vector3(transform.position.x, transform.position.y + i + 1, transform.position.z);
			tsikens[i] = Instantiate(tsiken, pos, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (updateParents) 
		{
			UpdateParents();
		}
	}

	void UpdateParents()
	{
		for (int i = 0; i < tsikens.Length; i++)
		{
			Tsiken ts = tsikens[i].GetComponent<Tsiken>();

			if (i == 0) 
			{
				ts.leader = this.gameObject.transform;
			}	
			else
			{
				ts.leader = tsikens[i - 1].transform;
			}

		}
		updateParents = false;
	}
}
