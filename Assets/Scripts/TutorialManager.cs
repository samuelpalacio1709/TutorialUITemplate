using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private List<TutorialItemSO> items;
    [SerializeField] private int  totalStepsToShow=3;
    
    private int activeIndexStep= 0;

    public TutorialItemSO Next()
    {
        if (activeIndexStep > (items.Count-1) || activeIndexStep== totalStepsToShow) return null;
        activeIndexStep++;
        TutorialItemSO item = items[activeIndexStep-1];
        return item;
    }

    public TutorialItemSO Back()
    {
        activeIndexStep--;
        if (activeIndexStep <= 0)
        {
            activeIndexStep = 1;
        }

        TutorialItemSO item = items[activeIndexStep-1];
        return item;

    }
    public void ResetTutorialInfo()
    {
        activeIndexStep = 0;
    }

    public bool isFirstItem()
    {
        return (activeIndexStep <= 1);
    }
}
