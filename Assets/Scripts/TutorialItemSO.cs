using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TutorialItem", menuName = "TutorialItems/Create Tutorial Item", order = 1)]
public class TutorialItemSO : ScriptableObject
{
    public string description;
    public Sprite sprite;
}
