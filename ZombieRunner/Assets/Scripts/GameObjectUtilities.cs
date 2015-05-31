using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtilities {

	private static Dictionary<RecycleObject, ObjectPool> pools = new Dictionary<RecycleObject, ObjectPool> ();
	private static ObjectPool GetObjectPool(RecycleObject reference){
		ObjectPool pool = null;

		if (pools.ContainsKey (reference)) {
			pool = pools [reference];
		} else {
			var poolContainer = new GameObject(reference.gameObject.name+"ObjectPool");
			pool=poolContainer.AddComponent<ObjectPool>();
			pool.prefab=reference;
			pools.Add (reference,pool);
		}
		return pool;
	}
	public static GameObject Instantiate(GameObject prefab, Vector3 pos){
		GameObject instance = null;

		var recycledScript = prefab.GetComponent<RecycleObject> ();
		if (recycledScript != null) {
			var pool = GetObjectPool (recycledScript);
			instance = pool.NextObject (pos).gameObject;
		} else {
			instance = GameObject.Instantiate (prefab);
			instance.transform.position = pos;
		}
		return instance;
	}

	public static void Destroy(GameObject gameObject){
		var recycleGameObject = gameObject.GetComponent<RecycleObject> ();
		if (recycleGameObject != null) {
			recycleGameObject.Shutdown ();
		} else {
			GameObject.Destroy (gameObject);
		}
	}
}
