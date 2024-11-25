using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public ActionManager(Action action, Action met)
    {
        action += met;
    }


}
