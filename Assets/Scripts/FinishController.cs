using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public void AddBustLevel()
    {
        FindObjectOfType<LevelEntityBust>().AddEntityBust();
    }
}
