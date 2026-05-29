using System;
using System.Media;
using System.IO;

namespace POE
{
    public class greetingVoice
    {

        public greetingVoice()
        {

            string path_directory = AppDomain.CurrentDomain.BaseDirectory;

            string directory = path_directory.ToLower().Replace("bin\\debug\\net8.0", "");


            string voice_path = Path.Combine(directory, "AI POE voice.wav");

            play_voice(voice_path);
        }

        public void play_voice(string filePath)
        {
            try
            {

                using (SoundPlayer player = new SoundPlayer(filePath))
                {
                    player.Load();
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Audio Error : {ex.Message}");
                Console.WriteLine($"Target Path: {filePath}");
            }
        }
    }
}