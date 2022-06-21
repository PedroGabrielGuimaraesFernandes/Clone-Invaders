using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    public class MainData
    {

        public static int highestHighscore;
        public static int highestLevelReached;


        public static void SaveData()
        {
            PlayerPrefs.SetInt("Highscore", highestHighscore);
            PlayerPrefs.SetInt("HighestLevel", highestLevelReached);
        }

        public static void SaveHighscore()
        {
            PlayerPrefs.SetInt("Highscore", highestHighscore);
        }

        public static void LoadData()
        {
            highestHighscore = PlayerPrefs.GetInt("Highscore", 0);
            highestLevelReached = PlayerPrefs.GetInt("HighestLevel", 0);
        }

        public static void ResetSavedData()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
