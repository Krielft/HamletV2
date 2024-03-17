using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Variables")]
        public GameObject[] gm;
        public GameObject[] optionGm;
        
        private MenuState state = MenuState.None;
        private enum MenuState
        {
            None = -1,
            Option = 0,
            Credits = 1
        }
        
        private OptionState oState = OptionState.None;
        private enum OptionState
        {
            None = -1,
            Control = 0,
            Video = 1,
            Audio = 2
        }

    [Header("Play Settings")] 
        public GameObject cameraPrefab;
        public GameObject menuCamera;

    public void OpenOptionPanel(int index)
    {
        if (oState == OptionState.None) //Open Option panel
        {
            optionGm[index].SetActive(true);
            oState = (OptionState)index;
        }
        else if ((int)oState == index) //Close Option panel
        {
            optionGm[index].SetActive(false);
            oState = OptionState.None;
        }
        else //Switch Option panel
        {
            optionGm[(int)oState].SetActive(false);
            optionGm[index].SetActive(true);
            oState = (OptionState)index;
        }
    }
    
    public void OpenPanel(int index)
    {
        //Handle the panel state change, to open / close / switch panel
        
        if (state == MenuState.None) //Open panel
        {
            gm[index].SetActive(true);
            state = (MenuState)index;
        }
        else if ((int)state == index) //Close panel
        {
            gm[index].SetActive(false);
            state = MenuState.None;
        }
        else //Switch opened panel (options -> credits)
        {
            gm[(int)state].SetActive(false);
            gm[index].SetActive(true);
            state = (MenuState)index;
        }
    }

    public void Play(GameObject panel)
    {
        //Remove the Canvas of the Main Menu
        panel.SetActive(false);
        menuCamera.SetActive(false);
        cameraPrefab.SetActive(true);
    }
    
    public void Exit()
    {
        //Close the entire game window
        Application.Quit();
    }
}