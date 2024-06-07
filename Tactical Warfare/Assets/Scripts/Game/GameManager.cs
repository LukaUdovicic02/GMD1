using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public GameObject player1Assassin;
        public GameObject player1Assault;
        public GameObject player1Hunter;
        public GameObject player2Assassin;
        public GameObject player2Assault;
        public GameObject player2Hunter;

        private void Start()
        {
            string selectedClassPlayer1 = PlayerPrefs.GetString("SelectedClassPlayer1", "Assassin");
            string selectedClassPlayer2 = PlayerPrefs.GetString("SelectedClassPlayer2", "Assassin");

            EnablePlayerClass(player1Assassin, player1Assault, player1Hunter, selectedClassPlayer1);
            EnablePlayerClass(player2Assassin, player2Assault, player2Hunter, selectedClassPlayer2);
            
            Debug.Log("Selected classes " + selectedClassPlayer1 + " " + selectedClassPlayer2);
        }

        private void EnablePlayerClass(GameObject assassin, GameObject assault, GameObject hunter, string selectedClass)
        {
            assassin.SetActive(false);
            assault.SetActive(false);
            hunter.SetActive(false);

            switch (selectedClass)
            {
                case "Assault":
                    assault.SetActive(true);
                    break;
                case "Hunter":
                    hunter.SetActive(true);
                    break;
                case "Assassin":
                default:
                    assassin.SetActive(true);
                    break;
            }
        }
    }
}