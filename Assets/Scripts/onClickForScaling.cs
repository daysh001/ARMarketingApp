using UnityEngine;
using System.Collections;

public class onClickForScaling : MonoBehaviour {
	void OnMouseDown() {
		Scale.ScaleTransform = this.transform;
	}
}