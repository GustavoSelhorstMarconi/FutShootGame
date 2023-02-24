using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button modeButton;
    [SerializeField]
    private Button skinButton;
    [SerializeField]
    private Button activeMenuModeButton;
    [SerializeField]
    private Button activeMenuSkinButton;
    [SerializeField]
    private Button twoPlayersButton;
    [SerializeField]
    private Button threePlayersButton;
    [SerializeField]
    private Button fourPlayersButton;
    [SerializeField]
    private Button nextPlayerSkinButton;
    [SerializeField]
    private Button previousPlayerSkinButton;
    [SerializeField]
    private Button nextSkinButton;
    [SerializeField]
    private Button previousSkinButton;
    [SerializeField]
    private Button selectSkinButton;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject modePanel;
    [SerializeField]
    private GameObject skinPanel;
    [SerializeField]
    private ScriptableMode modeValue;
    [SerializeField]
    private RawImage playerSkinImage;
    [SerializeField]
    private ScriptableColors colorsSkinValue;
    [SerializeField]
    private TextMeshProUGUI playerSkinSelectionText;

    [Header("Configurations")]
    [SerializeField]
    private List<string> playersName;
    [SerializeField]
    private List<GameObject> playersSelection;
    [SerializeField]
    private UnityEvent<int, int> OnSkinSelected;

    private int currentPlayerSkinSelection;
    private int currentSkinSelected;

    private void Start()
    {
        playButton.onClick.AddListener(LoadPlayLevel);
        modeButton.onClick.AddListener(ActiveModeSelection);
        skinButton.onClick.AddListener(ActiveSkinSelection);
        activeMenuModeButton.onClick.AddListener(ActiveMenu);
        activeMenuSkinButton.onClick.AddListener(ActiveMenu);

        twoPlayersButton.onClick.AddListener(SelectModeTwo);
        threePlayersButton.onClick.AddListener(SelectModeThree);
        fourPlayersButton.onClick.AddListener(SelectModeFour);

        nextPlayerSkinButton.onClick.AddListener(NextPlayerSkin);
        previousPlayerSkinButton.onClick.AddListener(PreviousPlayerSkin);

        nextSkinButton.onClick.AddListener(NextColorSkin);
        previousSkinButton.onClick.AddListener(PreviousColorSkin);
        selectSkinButton.onClick.AddListener(SelectSkin);
    }

    private void LoadPlayLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void ActiveMenu()
    {
        menuPanel.SetActive(true);
        modePanel.SetActive(false);
        skinPanel.SetActive(false);
    }

    private void ActiveModeSelection()
    {
        menuPanel.SetActive(false);
        modePanel.SetActive(true);
        skinPanel.SetActive(false);
    }

    private void ActiveSkinSelection()
    {
        menuPanel.SetActive(false);
        modePanel.SetActive(false);
        skinPanel.SetActive(true);
    }

    private void SelectModeTwo()
    {
        modeValue.modeSelected = 2;
        Invoke(nameof(LoadPlayLevel), 0.1f);
    }

    private void SelectModeThree()
    {
        modeValue.modeSelected = 3;
        Invoke(nameof(LoadPlayLevel), 0.1f);
    }

    private void SelectModeFour()
    {
        modeValue.modeSelected = 4;
        Invoke(nameof(LoadPlayLevel), 0.1f);
    }

    private void NextPlayerSkin()
    {
        currentPlayerSkinSelection = currentPlayerSkinSelection + 1 < playersSelection.Count ? currentPlayerSkinSelection + 1 : 0;
        playerSkinSelectionText.SetText(playersName[currentPlayerSkinSelection]);

        for (int i = 0; i < playersSelection.Count; i++)
        {
            playersSelection[i].SetActive(i == currentPlayerSkinSelection);
        }
    }

    private void PreviousPlayerSkin()
    {
        currentPlayerSkinSelection = currentPlayerSkinSelection - 1 >= 0 ? currentPlayerSkinSelection - 1 : playersSelection.Count - 1;
        playerSkinSelectionText.SetText(playersName[currentPlayerSkinSelection]);

        for (int i = 0; i < playersSelection.Count; i++)
        {
            playersSelection[i].SetActive(i == currentPlayerSkinSelection);
        }
    }

    private void NextColorSkin()
    {
        currentSkinSelected = currentSkinSelected + 1 < colorsSkinValue.skinColors.Count ? currentSkinSelected + 1 : 0;
        playerSkinImage.color = colorsSkinValue.skinColors[currentSkinSelected];
    }

    private void PreviousColorSkin()
    {
        currentSkinSelected = currentSkinSelected - 1 >= 0 ? currentSkinSelected - 1 : colorsSkinValue.skinColors.Count - 1;
        playerSkinImage.color = colorsSkinValue.skinColors[currentSkinSelected];
    }

    private void SelectSkin()
    {
        OnSkinSelected?.Invoke(currentPlayerSkinSelection, currentSkinSelected);
    }
}