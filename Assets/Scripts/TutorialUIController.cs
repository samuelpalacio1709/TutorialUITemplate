using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(TutorialManager))]
public class TutorialUIController : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Image tutorialImage;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private GameObject welcomeText;
    [SerializeField] private GameObject tutorialSteps;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject HUD;
    [SerializeField] private Button infoTutorial;

    private TutorialManager tutorialManager;
    private void Awake()
    {
        tutorialManager = GetComponent<TutorialManager>();
    }
    private void OnEnable()
    {
        ResetTutorial();
        infoTutorial.onClick.AddListener(ResetTutorial);
    }

    public void ResetTutorial()
    {
        tutorialManager.ResetTutorialInfo();
        tutorial.gameObject.SetActive(true);
        HUD.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        tutorialSteps.gameObject.SetActive(false);
        welcomeText.SetActive(true);
        nextButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(StartTutorial);
        backButton.onClick.AddListener(UpdateLastItem);

    }

    public void StartTutorial()
    {
        welcomeText.SetActive(false);
        tutorialSteps.SetActive(true);
        ShowItem(tutorialManager.Next());
        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(UpdateNextItem);
    }
   
  
    public void UpdateNextItem()
    {
        ShowItem(tutorialManager.Next());
        if (!tutorialManager.isFirstItem())
        {
            backButton.gameObject.SetActive(true);
        }

    }

    public void UpdateLastItem()
    {
        ShowItem(tutorialManager.Back());
        if (tutorialManager.isFirstItem())
        {
            backButton.gameObject.SetActive(false);
        }

    }

    public void EndTutorial()
    {
        tutorial.gameObject.SetActive(false);
        HUD.gameObject.SetActive(true);
    }


    public void ShowItem(TutorialItemSO item)
    {
        if (item == null)
        {
            EndTutorial();
            return;
        }
        descriptionText.text = item.description;
        tutorialImage.sprite = item.sprite;

    }

}
