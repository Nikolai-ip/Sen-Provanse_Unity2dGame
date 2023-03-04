using Assets.Scripts.Builds;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCard : MonoBehaviour
{
    [SerializeField]private Build _build;
    private static InfoCard _instance;
    private Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();
    [SerializeField] private Sprite _fabricInfoCard;
    [SerializeField] private Sprite _houseInfoCard;
    [SerializeField] private Sprite _hospitalInfoCard;
    [SerializeField] private Sprite _cafeInfoCard;
    private Image _image;
    private BoxCollider2D _boxCollider;
    [SerializeField]private bool _isMouseHover;
    public void SetMouseHoverTrue() { _isMouseHover = true; }
    public void SetMouseHoverFalse() { _isMouseHover = false; }

    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.SetActive(false);
        _image = GetComponent<Image>();
        _boxCollider = GetComponent<BoxCollider2D>();   
        _sprites.Add(typeof(Fabric).Name, _fabricInfoCard);
        _sprites.Add(typeof(House).Name, _houseInfoCard);
        _sprites.Add(typeof(Hospital).Name, _hospitalInfoCard);
        _sprites.Add(typeof(Cafe).Name, _cafeInfoCard);

    }
    public void ShowCard(Build build)
    {
        gameObject.SetActive(true);
        _build = build;
        _image.sprite = _sprites[_build.TypeName];
    }
    public void HideCard(Build build)
    {
        if (build == _build && !_isMouseHover)
            gameObject.SetActive(false);
    }
    public void IncrementEmployees()
    {
        _build.SetInhabitants();
    }
    public void DecrementEmployees()
    {

    }


}
