using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInterface : MonoBehaviour
{
    public bool isActive;
    public void changeActive(bool _isActive) {
        isActive = _isActive;
    }
}
