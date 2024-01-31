using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static void DeleteChilds(Transform parentTransform)
    {
        foreach (Transform child in parentTransform) Destroy(child.gameObject);
    }
}
