using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T: Component
{
    public static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.name = typeof(T).Name;
                    _instance = gameObject.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            if (_instance != this)
            {
                 Destroy(gameObject);
            }

        }
    }
}
