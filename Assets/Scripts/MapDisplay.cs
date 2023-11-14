
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private Text mapName;   
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockIcon;
    [SerializeField] private GameObject episodesIconPlase;
    [SerializeField] private Transform mapHolder;


    public void DisplayMap(Map _map)
    {
        mapName.text = _map.mapName;
        //mapImage.sprite = _map.mapImage;
        if (mapHolder.childCount > 0)
        {
            Destroy(mapHolder.GetChild(0).gameObject);
        }
        Instantiate(_map.mapModel, mapHolder.position, mapHolder.rotation, mapHolder);

        bool mapUnlocked = PlayerPrefs.GetInt("currentScene",0) >= _map.mapIndex;
        lockIcon.SetActive(!mapUnlocked);
        playButton.interactable = mapUnlocked;

       // if (mapUnlocked)
       //     mapImage.color = Color.white;
       // else
       //     mapImage.color = Color.gray;


        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(()=> SceneManager.LoadScene(_map.sceneTOLoad.name));
        
    }
}
