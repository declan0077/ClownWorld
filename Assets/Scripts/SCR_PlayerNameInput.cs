using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerNameInput : MonoBehaviour
{
    public delegate void PlayerNameInputDelegate(string playerName);
    public static PlayerNameInputDelegate PlayerNameInput;
}
