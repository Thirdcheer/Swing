using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

    public GameObject go;
	void Awake()
    {
        DontDestroyOnLoad(go);
    }
}
