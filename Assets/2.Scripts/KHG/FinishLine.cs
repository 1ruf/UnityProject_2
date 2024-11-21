using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private int[] a = { 1,2,3,4,5,6,7 };
    private void OnEnable()
    {
        test();
    }
    private void test()
    {
        try
        {
            print(a[10]);
        }
        catch
        {
            print("배열 범위 벗어남");
        }
    }
}
