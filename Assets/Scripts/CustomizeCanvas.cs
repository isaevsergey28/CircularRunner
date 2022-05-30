using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CustomizeCanvas : ScreenView
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _acceptSkinButton;
    [SerializeField] private Button _buySkinButton;
    [SerializeField] private TextMeshProUGUI _currentDiamondsText;
    [SerializeField] private List<SuitInfo> _allSkins = new List<SuitInfo>();
    [SerializeField] private TextMeshProUGUI _costText;

    private int _currentDiamonds;
    private string _diamondScoreKey = "DiamondScore";
    private string _diamondsLine = "diamonds";
    private SuitInfo _activeSuit;
    
    public override void Init()
    {
        if (PlayerPrefs.HasKey(_diamondScoreKey))
        {
            _currentDiamonds = PlayerPrefs.GetInt(_diamondScoreKey);
            _currentDiamondsText.text += " " + _currentDiamonds;
        }
        else
        {
            _currentDiamonds = 0;
            _currentDiamondsText.text += " " + "0";
        }

        _mainMenuButton.onClick.AddListener(ShowMainMenuCanvas);
        _acceptSkinButton.onClick.AddListener(AcceptSkin);
        _buySkinButton.onClick.AddListener(BuySkin);
        _allSkins = FindObjectsOfType<SuitInfo>().ToList();
        SuitChanger.onSuitChanged += ChangeButtonsView;
    }

    public override void OnShow()
    {
        
    }

    public override void OnHide()
    {
        foreach (var skin in _allSkins)
        {
            skin.SetIsApplied(skin.IsApplied);
            skin.SetIsLocked(skin.IsLocked);
        }
    }

    private void Update()
    {
        foreach (var skin in _allSkins)
        {
            if (skin.gameObject.activeSelf)
            {
                if (skin.IsApplied )
                {
                    _acceptSkinButton.image.color = new Color(0.200f, 0.55f, 0.55f);
                }
                else
                {
                    _acceptSkinButton.image.color =new Color(0.65f, 0.180f, 0.20f);
                }
            }
            
        }
    }

    private void OnDestroy()
    {
        SuitChanger.onSuitChanged -= ChangeButtonsView;
    }

    private void ShowMainMenuCanvas()
    {
        UIManager.instance.Show<MainMenuCanvas>();
    }
    

    private void AcceptSkin()
    {
        foreach (var skin in _allSkins)
        {
            if (skin.gameObject.activeSelf && skin.IsLocked == false)
            {
                skin.IsApplied = true;
                _activeSuit = skin;
            }
            else
            {
                skin.IsApplied = false;
            }
            
        }
    }


    private void BuySkin()
    {
        foreach (var skin in _allSkins)
        {
            if (skin.gameObject.activeSelf && skin.IsLocked)
            {
                if (skin.Cost <= _currentDiamonds)
                {
                    skin.IsLocked = false;
                    _currentDiamonds -= skin.Cost;
                    PlayerPrefs.SetInt(_diamondScoreKey, _currentDiamonds);
                    _currentDiamondsText.text = _diamondsLine + ": " + _currentDiamonds;
                    ChangeButtonsView(skin);
                }
            }
        }
    }

    private void ChangeButtonsView(SuitInfo suitInfo)
    {
        if (suitInfo.IsLocked)
        {
            _acceptSkinButton.gameObject.SetActive(false);
            _buySkinButton.gameObject.SetActive(true);
            _costText.gameObject.SetActive(true);
            _costText.text = suitInfo.Cost.ToString();
        }
        else
        {
            _acceptSkinButton.gameObject.SetActive(true);
            _buySkinButton.gameObject.SetActive(false);
            _costText.gameObject.SetActive(false);
        }
    }
}
