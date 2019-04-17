using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIn2018 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_2019_OR_LATER
        Destroy(gameObject);
#endif
    }
}
