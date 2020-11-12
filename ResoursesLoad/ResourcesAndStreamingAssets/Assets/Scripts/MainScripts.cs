using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScripts : MonoBehaviour
{
    [SerializeField] private GameObject MenSetting, WomenSetting;
    [SerializeField]private Dropdown[] BodyWariant;
    [SerializeField] private Dropdown[] LegsWariant;
    private GameObject[] BodySex;
    private GameObject[] BodyMan, BodyManIsnt, LegsMen, LegsMenIsnt;
    private GameObject[] BodyFamale;
    private GameObject Man, Women, MenBodyStandart, MenLegsStandart, FamaleBodyStandart;

    private void Awake()
    {
        BodySex = Resources.LoadAll<GameObject>("Sex/");
        Instantiate(BodySex[1]);
        Instantiate(BodySex[0]);
        BodyMan = Resources.LoadAll<GameObject>("BodyMan/");
        LegsMen = Resources.LoadAll<GameObject>("LegsMan");
        Man = GameObject.FindGameObjectWithTag("Man");
        Women = GameObject.FindGameObjectWithTag("Women");
        MenBodyStandart = GameObject.FindGameObjectWithTag("MenTors");
        MenLegsStandart = GameObject.FindGameObjectWithTag("MenLegs");
        FamaleBodyStandart = GameObject.FindGameObjectWithTag("FamaleTors");
        Women.SetActive(false);
        WomenSetting.SetActive(false);
        BodyManIsnt = new GameObject[BodyMan.Length];
        LegsMenIsnt = new GameObject[LegsMen.Length];
    }
    private void Start()
    {
        for(int i =0; i < BodyMan.Length; i++)
        {
           BodyManIsnt[i] = Instantiate(BodyMan[i]);
           BodyManIsnt[i].transform.position = MenBodyStandart.transform.position;
           BodyManIsnt[i].SetActive(false);
        }
        for(int i=0; i< LegsMen.Length; i++)
        {
            LegsMenIsnt[i] = Instantiate(LegsMen[i]);
            LegsMenIsnt[i].transform.position = MenLegsStandart.transform.position;
            LegsMenIsnt[i].SetActive(false);
        }
    }

    public void ShowBodyDefMan()
    {
        Man.SetActive(true);
        Women.SetActive(false);
        MenSetting.SetActive(true);
        WomenSetting.SetActive(false);


    }
    public void ShowBodyDefFemale()
    {
        Man.SetActive(false);
        Women.SetActive(true);
        MenSetting.SetActive(false);
        WomenSetting.SetActive(true);

    }
    public void ChangeBodyMan()
    {
        MenBodyStandart.SetActive(false);
        for(int i =0; i < BodyManIsnt.Length; i++)
        {
            BodyManIsnt[i].SetActive(false);
        }
        BodyManIsnt[BodyWariant[0].value].SetActive(true);  
    }
    public void ChangeLegsMan()
    {
        MenLegsStandart.SetActive(false);
        for (int i = 0; i < LegsMenIsnt.Length; i++)
        {
            LegsMenIsnt[i].SetActive(false);
        }
        LegsMenIsnt[LegsWariant[0].value].SetActive(true);
    }
}
