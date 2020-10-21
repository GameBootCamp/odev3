using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using DG.Tweening;
 using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    [SerializeField]
    private GameObject kareprefab;
     [SerializeField]
    private Transform karelerpanel;
    [SerializeField]
    private Text soruText;
    private GameObject[] karelerDizisi=new GameObject[25];

   [SerializeField]
   private Transform sorupanel;
   [SerializeField]
   private Sprite[] karesprite;

   List<int> bolumDegerleriListesi = new List<int>();
   int bolunenSayi,bolenSayi;
   int kacinciSoru;
   int dogruSonuc;
   int butonDegeri;

   bool butonaBasilsinmi;
   int hak;
   string zorlukderecesi;
hakmanager hakmanager;

puanmanager puanmanager;
   GameObject gecerliKare;
   [SerializeField]
   private GameObject sonucpaneli;
   
   void Awake()
   {
       hak = 3;

       sonucpaneli.GetComponent<RectTransform>().localScale=Vector3.zero;
       hakmanager = Object.FindObjectOfType<hakmanager>();
       hakmanager.haklarıKontrolEt(hak);
       puanmanager= Object.FindObjectOfType<puanmanager>();
   }
    void Start()
    {  
        butonaBasilsinmi = false;
       // sorupanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        kareleriOlustur();
    }
public void kareleriOlustur()
{
for(int i = 0; i < 25; i++)
{
  GameObject kare = Instantiate(kareprefab,karelerpanel);
 kare.transform.GetChild(1).GetComponent<Image>().sprite= karesprite[Random.Range(0,karesprite.Length)];
  kare.transform.GetComponent<Button>().onClick.AddListener(() => ButonaBasildi());
  karelerDizisi[i] = kare;
}
BolumDegerleriniTexteYazdir();
 StartCoroutine(DoFadeRoutine());
    Invoke("SoruPaneliniAc",2f);
}

void ButonaBasildi()
{
    if(butonaBasilsinmi)
    {
butonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
gecerliKare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
     SonucuKontrolEt();
    }
    

}
void SonucuKontrolEt()
{
    if(butonDegeri == dogruSonuc)
    {
        gecerliKare.transform.GetChild(1).GetComponent<Image>().enabled=true;
        gecerliKare.transform.GetChild(0).GetComponent<Text>().text = "";
        gecerliKare.transform.GetComponent<Button>().interactable=false;
       puanmanager.PuanArtir(zorlukderecesi);
       bolumDegerleriListesi.RemoveAt(kacinciSoru);

       if(bolumDegerleriListesi.Count>0)
       {
       SoruPaneliniAc();
       }
       else
       {
          OyunBitti();
       }
    }
        else
        {
            hak--;
            hakmanager.haklarıKontrolEt(hak);
        }

        if(hak<=0)
        {
            OyunBitti();
        }
    }

    void OyunBitti()
    {
        butonaBasilsinmi=false;
         sonucpaneli.GetComponent<RectTransform>().DOScale(1,0.5f);
    }
    


IEnumerator DoFadeRoutine()
{
foreach (var kare in karelerDizisi)
{
    kare.GetComponent<CanvasGroup>().DOFade(1,0.2f);
    yield return new WaitForSeconds(0.07f);
}
}
    void BolumDegerleriniTexteYazdir()
    {
        foreach(var kare in karelerDizisi)
        {
         int rastgeleDeger = Random.Range(1,13);
         bolumDegerleriListesi.Add(rastgeleDeger);
         kare.transform.GetChild(0).GetComponent<Text>().text=rastgeleDeger.ToString();
        }
    }
    void SoruPaneliniAc()
    {
        SoruyuSor();
        butonaBasilsinmi = true;
        sorupanel.GetComponent<RectTransform>().DOScale(1,0.5f);
    }
    void SoruyuSor()
    { 
        
        bolenSayi=Random.Range(2,11);
        kacinciSoru = Random.Range(0, bolumDegerleriListesi.Count);
        dogruSonuc = bolumDegerleriListesi[kacinciSoru];
        bolunenSayi=bolenSayi*bolumDegerleriListesi[kacinciSoru];

        if(bolunenSayi<=40)
        {
zorlukderecesi="kolay";
        } else if(bolunenSayi>40 && bolunenSayi<=80)
        {
            zorlukderecesi="orta";
        } else
        {
            zorlukderecesi = "zor";
        }

        soruText.text = bolunenSayi.ToString() + ":" + bolenSayi.ToString();
    }
}

