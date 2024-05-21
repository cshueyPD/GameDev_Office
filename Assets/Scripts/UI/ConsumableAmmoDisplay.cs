using TMPro;
using UnityEngine;

public class ConsumableAmmoDisplay : MonoBehaviour
{
    [SerializeField] private bool isPizza = true;
    [SerializeField] private TextMeshProUGUI displayCount;
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if(isPizza){
            displayCount.text = "x" + player.pizzaCount.ToString();
        }
        else{
            displayCount.text = "x" + player.blockCount.ToString();
        }
    }

    private void Update() {
        if (isPizza)
        {
            displayCount.text = "x" + player.pizzaCount.ToString();
        }
        else
        {
            displayCount.text = "x" + player.blockCount.ToString();
        }
    }
}