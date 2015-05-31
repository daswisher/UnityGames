using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
	public RecycleObject prefab;

	private List<RecycleObject> poolInstances = new List<RecycleObject>();
	private RecycleObject CreateInstance(Vector3 pos){
		var clone = GameObject.Instantiate (prefab);
		clone.transform.position = pos;
		clone.transform.parent = transform;
		poolInstances.Add (clone);
		return clone;
	}

	public RecycleObject NextObject(Vector3 pos){
		RecycleObject instance = null;
		foreach (var go in poolInstances) {
			if(go.gameObject.activeSelf != true){
				instance = go;
				instance.transform.position = pos;
			}
		}
		
		if(instance == null)
			instance = CreateInstance (pos);
		
		instance.Restart ();
		
		return instance;
	}
}
