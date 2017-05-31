using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Tweener tweener = transform.DOMoveX(10, 2);
        transform.Translate(10 * Time.deltaTime,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
