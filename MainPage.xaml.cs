// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using SharpDX;

namespace Project1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private readonly Project1Game game;

        public MainPage()
        {
            InitializeComponent();
            game = new Project1Game(this);
            game.Run(this);
            txtScore.Visibility = Visibility.Collapsed;
            scoreLabel.Visibility = Visibility.Collapsed;
            hideLaunchControls();
        }

        public void bestAttempt(int bestatt)
        {
            if (bestatt == 0)
            {

            }
            else
            {
                txtScore_Copy.Text = bestatt.ToString();
            }
        }

        public void updateattempt(int current){
            
                txtScore_Copy1.Text = current.ToString();
            }


        public void UpdateScore(int score)
        {
            txtScore.Text = score.ToString();

        }

        public double getDegreeValue()
        {
            return aimCannonSlider.Value;
        }

        public void UpdateDegreeSlider(int degree){

            aimCannonSlider.Value = degree;
        }

        public void LaunchScreen()
        {
       
            viewLaunchControls();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            game.LoadLevel(1);
            game.gameStarted = true;
            cmdStart.Visibility = Visibility.Collapsed;
            cmdStart_Copy.Visibility = Visibility.Collapsed;
            cmdStart_Copy1.Visibility = Visibility.Collapsed;
            dfctySlider.Visibility = Visibility.Collapsed;
            titleLabel.Visibility = Visibility.Collapsed;
            txtScore.Visibility = Visibility.Visible;
            scoreLabel.Visibility = Visibility.Visible;
            txtScore_Copy1.Visibility = Visibility.Visible;
            stagename.Visibility = Visibility.Collapsed;
            LaunchScreen();
        }


        private void ChangeDifficulty(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            if (game != null) { game.difficulty = (float)e.NewValue; }
        }

        private void changeAngle(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            if (game != null) { game.yDegree = (int)e.NewValue; }
        }

        private void launchCannonball(object sender, RoutedEventArgs e)
        {
            hideLaunchControls();
            game.LaunchMode = true;
            game.justLaunched = true;
        }

        public void viewLaunchControls()
        {
            launchDegreeSlider.Visibility = Visibility.Visible;
            launchButton.Visibility = Visibility.Visible;
            launchAngleText.Visibility = Visibility.Visible;
            aimCannonSlider.Visibility = Visibility.Visible;
            launchPowerSlider.Visibility = Visibility.Visible;
            velocityLabel.Visibility = Visibility.Visible;
            tiltLabel.Visibility = Visibility.Visible;
            aimLabel.Visibility = Visibility.Visible;
            scoreLabel_Copy.Visibility = Visibility.Visible;
            txtScore_Copy.Visibility = Visibility.Visible;
            scoreLabel_Copy1.Visibility = Visibility.Visible;
            txtScore_Copy1.Visibility = Visibility.Visible;
        }

        public void hideLaunchControls()
        {
            launchDegreeSlider.Visibility = Visibility.Collapsed;
            launchButton.Visibility = Visibility.Collapsed;
            launchAngleText.Visibility = Visibility.Collapsed;
            aimCannonSlider.Visibility = Visibility.Collapsed;
            launchPowerSlider.Visibility = Visibility.Collapsed;
            velocityLabel.Visibility = Visibility.Collapsed;
            tiltLabel.Visibility = Visibility.Collapsed;
            aimLabel.Visibility = Visibility.Collapsed;
            scoreLabel_Copy.Visibility = Visibility.Visible;
            txtScore_Copy.Visibility = Visibility.Visible;
            scoreLabel_Copy1.Visibility = Visibility.Visible;
            txtScore_Copy1.Visibility = Visibility.Visible;
            txtScore_Copy1.Visibility = Visibility.Visible;







        }

        public void returnToMenu()
        {
            cmdStart.Visibility = Visibility.Visible;
            cmdStart_Copy.Visibility = Visibility.Visible;
            cmdStart_Copy1.Visibility = Visibility.Visible;
            dfctySlider.Visibility = Visibility.Visible;
            titleLabel.Visibility = Visibility.Visible;


        }


        private void ChangeXAngle(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            if (game != null) { game.degree = (int)e.NewValue; };
        }

        private void ChangePower(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            if (game != null) { game.v0 = (int)e.NewValue; };
        }

        private void txtScore_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StartGame2(object sender, RoutedEventArgs e)
        {
            game.LoadLevel(2);
            game.gameStarted = true;
            cmdStart.Visibility = Visibility.Collapsed;
            cmdStart_Copy.Visibility = Visibility.Collapsed;
            cmdStart_Copy1.Visibility = Visibility.Collapsed;
            dfctySlider.Visibility = Visibility.Collapsed;
            titleLabel.Visibility = Visibility.Collapsed;
            txtScore.Visibility = Visibility.Visible;
            scoreLabel.Visibility = Visibility.Visible;
            txtScore_Copy1.Visibility = Visibility.Visible;
            stagename.Visibility = Visibility.Collapsed;
            LaunchScreen();
        }

        private void StartGame3(object sender, RoutedEventArgs e)
        {
            game.LoadLevel(3);
            game.gameStarted = true;
            cmdStart.Visibility = Visibility.Collapsed;
            cmdStart_Copy.Visibility = Visibility.Collapsed;
            cmdStart_Copy1.Visibility = Visibility.Collapsed;
            dfctySlider.Visibility = Visibility.Collapsed;
            titleLabel.Visibility = Visibility.Collapsed;
            txtScore.Visibility = Visibility.Visible;
            scoreLabel.Visibility = Visibility.Visible;
            txtScore_Copy1.Visibility = Visibility.Visible;
            stagename.Visibility = Visibility.Collapsed;

            LaunchScreen();
        }
      

    
    }
}
