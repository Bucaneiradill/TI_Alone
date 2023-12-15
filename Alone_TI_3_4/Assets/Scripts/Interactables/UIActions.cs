using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIActions : MonoBehaviour
{
    public static UIActions instance;

    private RectTransform PanelTransform;

    [Header("Actions")]
    [SerializeField] Image Icon1;
    [SerializeField] Image Icon2;
    [SerializeField] GameObject panelActions;
    [SerializeField] Button b1;
    [SerializeField] Button b2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
       PanelTransform = panelActions.GetComponent<RectTransform>();
    }

    /*------------------------------------------------------------------------------
    Função:     AddActions
    Descrição:  Fecha todos os paineis
    Entrada:    -
    Saída:      -
    ------------------------------------------------------------------------------*/

    public void AddActions(UnityAction a1, UnityAction a2, Vector3 position, Sprite actionIcon1, Sprite actionIcon2){
        Debug.Log("Item: " + position);
        transform.position = position;
        Icon1.sprite = actionIcon1;
        Icon2.sprite = actionIcon2;
        PanelTransform.anchoredPosition = Vector3.zero;
        panelActions.SetActive(true);
        Debug.Log("Passei");
        b1.onClick.RemoveAllListeners();
        b2.onClick.RemoveAllListeners();
        b1.onClick.AddListener(a1);
        b2.onClick.AddListener(a2);
        b1.onClick.AddListener(ClosePanel);
        b2.onClick.AddListener(ClosePanel);
    } 

    public void ClosePanel(){
        panelActions.SetActive(false);
    }
}
