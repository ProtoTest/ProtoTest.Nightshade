using System;
using System.Threading;
using ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.System;
using ProtoTest.Nightshade.PageObjects.Steps.Apps;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade.PageObjects.DeviceAssets.Windows.MC65.Apps
{
    public class Windows_MC65_FileExplorerApp : IFileExplorer
    {
        public EggplantElement FileExplorerAppHeader = new EggplantElement(By.Image("MC65/Apps/FileExplorer/FileExplorerAppHeader"));
        public EggplantElement ScrollbarDownArrow = new EggplantElement(By.Image("MC65/Apps/FileExplorer/ScrollbarDownArrow"));
        public EggplantElement GoToMenuOption = new EggplantElement(By.Image("MC65/Apps/FileExplorer/GoToMenuOption"));
        public EggplantElement MyDocumentsMenuOption = new EggplantElement(By.Image("MC65/Apps/FileExplorer/MyDocumentsMenuOption"));
        public EggplantElement MyDocumentsFolderHeader = new EggplantElement(By.Image("MC65/Apps/FileExplorer/MyDocumentsFolderHeader"));
        public EggplantElement MyMusicFolderHeader = new EggplantElement(By.Image("MC65/Apps/FileExplorer/MyMusicFolderHeader"));
        public EggplantElement FolderMyMusic = new EggplantElement(By.Image("MC65/Apps/FileExplorer/FolderMyMusic"));

        public IFileExplorer VerifyElements()
        {
            EggplantTestBase.Info("Verifying File Explorer app elements.");
            FileExplorerAppHeader.WaitForPresent();
            return this;
        }

        public IFileExplorer ResetAppState()
        {
            EggplantTestBase.Info("Resetting File Explorer app to default state.");
            var startBar = new Windows_MC65_StartBar();
            startBar.MenuOption.Click();
            GoToMenuOption.Click();
            MyDocumentsMenuOption.Click();
            MyDocumentsFolderHeader.WaitForPresent();
            return this;
        }

        public IFileExplorer EnterFolderMyMusic()
        {
            FolderMyMusic.Click();
            MyMusicFolderHeader.WaitForPresent();
            return this;
        }

        public IMediaPlayerApp IterativelyOpenAudioFiles(int iterations)
        {
            ResetAppState();
            EnterFolderMyMusic();
            
            EggplantTestBase.Info("Iteratively opening all " + iterations +" audio files.");
            for (int i = 1; i < iterations+1; i++)
            {
                int numInt = i;
                string numStr = Convert.ToString(i);
                
                if (numInt < 10)
                {
                    string iterationNum = "0" + numStr;

                    var audioFileName = new EggplantElement(By.Text(Config.AudioTestFileNamePrefix + iterationNum));
                    EggplantTestBase.Info("Searching for file: " + audioFileName + ".");
                    int searches = iterations;
                        for (int j = 0; j < searches+1; j++)
                        {
                            if (!audioFileName.IsPresent() && (j < searches+1))
                            {
                                var explorer = new Windows_MC65_FileExplorerApp();
                                explorer.ScrollbarDownArrow.Click();
                                if (j == searches)
                                {
                                    throw new Exception("Audio file not found after " +iterations+ " searches.");
                                }
                            }
                            else
                            {
                                EggplantTestBase.Info("Clicking on file: " + audioFileName + ".");
                                audioFileName.Click();
                                break;
                            }
                        }
                    
                }
                else
                {
                    var audioFileName = new EggplantElement(By.Text(Config.AudioTestFileNamePrefix + numStr));
                    EggplantTestBase.Info("Searching for file: " + audioFileName + ".");
                    int searches = iterations;
                    for (int j = 0; j < searches+1; j++)
                    {
                        if (!audioFileName.IsPresent() && (j < searches+1))
                        {
                            var explorer = new Windows_MC65_FileExplorerApp();
                            explorer.ScrollbarDownArrow.Click();
                            if (j == searches)
                            {
                                throw new Exception("Audio file not found after " + iterations + " searches.");
                            }
                        }
                        else
                        {
                            EggplantTestBase.Info("Clicking on file: " + audioFileName + ".");
                            audioFileName.Click();
                            break;
                        }
                    }
                }
                
                var mediaPlayer = new Windows_MC65_WindowsMediaApp();
                mediaPlayer.VerifyFilePlaying();
                Thread.Sleep(20000);
                mediaPlayer.RemoveFileFromActiveStatus();
                var startBar = new Windows_MC65_StartBar();
                if (startBar.OKButton.IsPresent())
                {
                    startBar.OKButton.Click();
                }
                startBar.ExitButton.Click();
            }


            return new Windows_MC65_WindowsMediaApp();
        }

        public IFileExplorer ExitApp()
        {
            EggplantTestBase.Info("Exiting File Explorer app.");
            var startBar = new Windows_MC65_StartBar();
            startBar.ExitButton.Click();
            Command.OnHomeScreen().ConfirmHomeScreen();
            return this;
        }
    }
}
