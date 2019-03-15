﻿namespace NNHelper
{
    public class MainApp
    {
        private GameProcess gp;

        private Settings settings;

        public void Start()
        {
            settings = Settings.ReadSettings();
            var nNet = NeuralNet.Create(settings.Game);

            gp = GameProcess.Create(settings);


            if (nNet == null)
            {
                var ta = new TrainingApp(gp, nNet);
                ta.startTrainingMode();
            }

            var ab = new Aimbot(settings, gp, nNet);
            ab.Start();
        }
    }
}