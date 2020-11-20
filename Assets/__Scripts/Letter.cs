using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Letter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float timeDuration = 0.5f;
    public string easingCuve = Easing.InOut;

    [Header("Set Dynamically")]

    public TextMesh tMesh; // The TextMesh shows the char
    public Renderer tRend; // The Renderer of 3D Text. This will
    public bool big = false; // Big letters act a little differently
    private char _c;    // The char shown on this Letter
    private Renderer rend;
    public List<Vector3> pts = null;
    public float timeStart = -1;

    void Awake()
    {

        tMesh = GetComponentInChildren<TextMesh>();

        tRend = tMesh.GetComponent<Renderer>();

        rend = GetComponent<Renderer>();

        visible = false;

    }

    public char c
    {

        get { return (_c); }

        set
        {

            _c = value;

            tMesh.text = _c.ToString();

        }

    }



    // Gets or sets _c as a string

    public string str
    {

        get { return (_c.ToString()); }

        set { c = value[0]; }

    }



    // Enables or disables the renderer for 3D Text, which causes the char to be

    //  visible or invisible respectively.

    public bool visible
    {

        get { return (tRend.enabled); }

        set { tRend.enabled = value; }

    }



    // Gets or sets the color of the rounded rectangle

    public Color color
    {

        get { return (rend.material.color); }

        set { rend.material.color = value; }

    }



    // Sets the position of the Letter's gameObject

    public Vector3 pos
    {

        set
        {
            //transform.position = value;
            Vector3 mid = (transform.position + value) / 2f;
            float mag = (transform.position - value).magnitude;
            mid += Random.insideUnitSphere * mag * 0.25f;
            pts = new List<Vector3>() { transform.position, mid, value };
            if (timeStart == -1) timeStart = Time.time;

        }

    }
    public Vector3 posImmediate
    {
        set
        {
            transform.position = value;
        }
    }
    void Update()
    {
        if (timeStart == -1) return;
        float u = (Time.time - timeStart) / timeDuration;
        u = Mathf.Clamp01(u);
        float u1 = Easing.Ease(u, easingCuve);
        Vector3 v = Utils.Bezier(u1, pts);
        transform.position = v;

        if (u == 1) timeStart = -1;
    }

}