using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float limitValue;
    public Slider sliderPos;

    void Start()
    {
        sliderPos.value = 0;
    }
    void Update()
    {
        if (Input.GetMouseButton(0)){
        MovePlayer();
        }

    }
    public void MovePlayer()
    {
        float Xpos = sliderPos.value * limitValue;
        playerTransform.transform.position = new Vector3(Xpos, -0.4f, -2.5f);
    }
}
