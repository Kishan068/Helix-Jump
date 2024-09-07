using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixMaker : MonoBehaviour
{
    public Material[] mats;
    int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in transform)
        {
            int r = Random.Range(0, mats.Length + 1);
            if (r == 2)
            {
                t.GetComponent<MeshRenderer>().enabled = false;
                t.GetComponent<MeshCollider>().convex = true;
                t.GetComponent<MeshCollider>().isTrigger = true;
                t.transform.position = new Vector3(t.transform.position.x, t.transform.position.y - 0.4f, t.transform.position.z);
                t.tag = "score";
            }
            else
            {
                if (r == 0)
                {
                    cnt++;
                }

                if (cnt >= 2)
                {
                    t.GetComponent<Renderer>().material = mats[1];
                }
                else
                {
                    if (r == 0)
                    {
                        t.tag = "danger";
                    }
                    t.GetComponent<Renderer>().material = mats[r];
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
