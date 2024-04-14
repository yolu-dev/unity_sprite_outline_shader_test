using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableGlow : MonoBehaviour
{
    [SerializeField]
    private Image tex = null;

    [SerializeField]
    private Material mat = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tex != null && mat != null)
            {
                if (tex.material == mat)
                {
                    Debug.Log("hoge");
                    tex.material = null;
                }
                else
                {
                    Debug.Log("piyo");
                    tex.material = mat;
                }
            }
        }
    }
}
