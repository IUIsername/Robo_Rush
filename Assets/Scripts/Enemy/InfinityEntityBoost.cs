using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityEntityBoost :GameEntityBust
{
    private void AddBustLevel()
    {
        _multiplyEntityHP++;
        OnBustEvent?.Invoke();
    }
}
