using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaMath : MonoBehaviour
{
    [SerializeField]float vAwal, a, g;

    void Start()
    {
        Debug.Log("Waktu Saat Titik Puncak = " + tTipun(vAwal, a, g));
        Debug.Log("Titik Puncak = " + calcYMax(vAwal, a, g));
        Debug.Log("Titik Terjauh = " + calcXMax(vAwal, a, g));
        //Debug.Log("Nilai Sin = " + Mathf.Sin(a * Mathf.PI / 180));

    }

    float t = 0;
    [SerializeField]float timeScale = 0;

    void Update()
    {
        t += Time.deltaTime * timeScale;
        transform.position = posBullet(vAwal, t, a, g);
    }
    
    float calcYMax(float _v, float _a, float _g)
    {
        return (Mathf.Pow(_v,2) * Mathf.Pow(Mathf.Sin(_a * Mathf.PI / 180),2)) / (2 * _g);
    }

    float calcXMax(float _v, float _a, float _g)
    {
        return (Mathf.Pow(_v, 2) * Mathf.Sin(2 * _a * Mathf.PI / 180)) / _g;
    }

    float tTipun(float _v, float _a, float _g)
    {
        return (_v * Mathf.Sin(_a * Mathf.PI / 180)) / _g;
    }

    Vector3 posBullet(float _v, float _t, float _a, float _g)
    {
        return new Vector3(
            calcX(vAwal, t, a),
            calcY(vAwal, t, a, g),
            0
        );
    }

    float calcX(float _v, float _t, float _a)
    {
        return vAwal * t * Mathf.Cos(a * Mathf.PI / 180);
    }

    float calcY(float _v, float _t, float _a, float _g)
    {
        return vAwal * t * Mathf.Sin(a * Mathf.PI / 180) - (0.5f * g * Mathf.Pow(t, 2));
    }
}