using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Font: MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().font.material.mainTexture.filterMode = FilterMode.Point;
    }
}
