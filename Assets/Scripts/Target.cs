using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static event Action OnTargetDestroy;


    public void DestroyTarget()
    {
        OnTargetDestroy?.Invoke();
        Destroy(gameObject);
    }
}
