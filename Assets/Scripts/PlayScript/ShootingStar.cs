using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    public float Speed = 1;
    public int CurrentStep = 1;

    private Transform Trans;

    delegate void FuncDelegate(ref Vector3 ret, float theta);
    FuncDelegate[] funcs = { new FuncDelegate(Func1), new FuncDelegate(Func2), new FuncDelegate(Func3) };

    private void Start()
    {
        Trans = gameObject.GetComponent<Transform>();
    }

    public void ChangeStep()
    {
        CurrentStep++;
        if(CurrentStep > funcs.Length)
        {
            CurrentStep = 1;
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            MenuScript temp = new MenuScript();
            temp.GoToPlay("MenuScene");
        }
        if(Input.GetMouseButtonDown(0))
        {
            ChangeStep();
        }
        else
        {
            Vector3 retVector = Vector3.zero;
            float theta = Time.realtimeSinceStartup * Speed;
            for (int i = 0; i < CurrentStep; i++)
            {
                funcs[i](ref retVector, theta);
            }
            Trans.position = retVector;
        }
    }

    static void Func1(ref Vector3 ret, float theta)
    {
        ret.x += 3 * Mathf.Cos(theta);
        ret.y += 3 * Mathf.Sin(theta);
    }

    static void Func2(ref Vector3 ret, float theta)
    {
        ret.x += 2 * Mathf.Cos(3 * theta);
        ret.y += 2 * Mathf.Sin(3 * theta);
    }

    static void Func3(ref Vector3 ret, float theta)
    {
        ret.x += Mathf.Cos(15 * theta);
        ret.y += Mathf.Sin(15 * theta);
    }
}
