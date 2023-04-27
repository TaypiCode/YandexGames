using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Promocode : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _answerText;
    [SerializeField] private GameObject _mobileInputs;
    [SerializeField] private FlexibleGridLayout _mobileInputsGrid;
    [SerializeField] private List<PromocodeScriptable> _promocodes;
    private string _enteredCodeText;
    private List<string> _activatedPromocodes = new List<string>();
    private PromocodeScriptable _enteredPromocode;
    private bool _activatedPerSession = false;
    public void FillActivatedPromocodes(string[] list)
    {
        _activatedPromocodes.AddRange(list);
    }
    public void ShowCanvas()
    {
        _canvas.SetActive(true);
        _enteredCodeText = "";
        _answerText.text = "";
        HideMobileInputs();
    }
    public void TryAcceptPromocode()
    {
        string[] texts = new string[5];
        switch (Languages.CurrentLanguage)
        {
            case Languages.AllLanguages.Rus:
                texts[0] = "Получен предмет: ";
                texts[1] = ", в количестве ";
                texts[2] = "Промокод уже активирован";
                texts[3] = "Не верный промокод";
                texts[4] = " шт";
                break;
            case Languages.AllLanguages.Eng:
                texts[0] = "Item received: ";
                texts[1] = ", in quantity ";
                texts[2] = "Promo code already activated";
                texts[3] = "Invalid promo code";
                texts[4] = " pcs";
                break;
        }
        if (GetEnteredPromocode())
        {
            if (CanActivate() && _activatedPerSession == false)
            {
                switch (_enteredPromocode.GetRewardType)
                {
                    case PromocodeScriptable.RewardType.Items:
                     
                        break;
                    default:
                        break;
                }
                _activatedPromocodes.Add(_enteredPromocode.itemId);
                _activatedPerSession = true;
                FindObjectOfType<SaveGame>().SaveProgress();
            }
            else
            {
                _answerText.text = texts[2];
            }
        }
        else
        {
            _answerText.text = texts[3];
        }
    }
    private bool GetEnteredPromocode()
    {
        
        for (int i = 0; i < _promocodes.Count; i++)
        {
            if (_promocodes[i].Code == _enteredCodeText)
            {
                _enteredPromocode = _promocodes[i];
                return true;
            }
        }
        return false;
    }
    private bool CanActivate()
    {
        for (int i = 0; i < _activatedPromocodes.Count; i++)
        {
            if (_activatedPromocodes[i] == _enteredPromocode.itemId)
            {
                return false;
            }
        }
        return true;
    }
    public void FillEnterCodeText(string s)
    {
        _enteredCodeText = s;
    }
    public string[] GetActivatedPromocodes()
    {
        return _activatedPromocodes.ToArray();
    }
    public void ShowMobileInputs()
    {
        _mobileInputs.SetActive(true);
        _mobileInputsGrid.Reload(FlexibleGridLayout.FitType.FixedRows, 4);
    }
    public void HideMobileInputs()
    {
        _mobileInputs.SetActive(false);
    }
    public void AddLetter(string val)
    {
        _inputField.text += val;
    }
    public void RemoveLetter()
    {
        if (_inputField.text.Length > 0)
        {
            _inputField.text = _inputField.text.Remove(_inputField.text.Length - 1);
        }
    }
}
