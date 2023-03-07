using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                CreateInstance();
            }
            return instance;
        }
    }

    public static void Init()
    {
        if (instance == null)
        {
            CreateInstance();
        }
    }

    public static void Init(T newInstance)
    {
        instance = newInstance;
    }

    private static void CreateInstance()
    {
        GameObject newObject = GameObject.Find("PersistentManagers");
        if (newObject == null)
        {
            newObject = new GameObject();
            newObject.name = "PersistentManagers";
            newObject.transform.position = Vector3.one * 100;
        }
        instance = newObject.AddComponent<T>();
        DontDestroyOnLoad(newObject);
    }

    public static bool HasInstance()
    {
        return instance != null;
    }
}
