using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTagsToChildren : MonoBehaviour {

	void applyTagToTransform(Transform transf) {
		foreach(Transform childTransform in transf)
		{
			childTransform.gameObject.tag = this.transform.tag;
			applyTagToTransform(childTransform);
		}
	}

	// Use this for initialization
	void Start () {
		applyTagToTransform(this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
