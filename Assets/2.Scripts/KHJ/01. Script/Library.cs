using UnityEngine;

public static class Library
{
    public static T TryGetAddComponenet<T>(this MonoBehaviour owner) where T : MonoBehaviour
    {
        T result;
        try
        {
            result = owner.GetComponent<T>();
        }
        catch
        {
            Debug.Log($"{typeof(T)} Ãß°¡ÇÔ");
            result = owner.gameObject.AddComponent<T>();
        }

        return result;
    }
}
