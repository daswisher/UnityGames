using UnityEngine;
using System.Collections;

public class BackgroundTile : MonoBehaviour {

	public int textureSize = 32;
	public bool scaleHorizontally = true;
	public bool scaleVertically = true;
	// Use this for initialization
	void Start () {
		var newWidth = !scaleHorizontally ? 1 : Mathf.Ceil (Screen.width / (textureSize * CameraFocus.scale));
		var newHeight = !scaleVertically ? 1 : Mathf.Ceil (Screen.height / (textureSize * CameraFocus.scale));

		transform.localScale = new Vector3 (newWidth * textureSize, newHeight * textureSize, 1);

		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (newWidth, newHeight, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
