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

using System;
using SharpDX;
using SharpDX.Toolkit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using Windows.UI.Input;
using Windows.UI.Core;
using Windows.Devices.Sensors;


namespace Project1
{
    // Use this namespace here in case we need to use Direct3D11 namespace as well, as this
    // namespace will override the Direct3D11.
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;
    using System.Diagnostics;

    public class Project1Game : Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        private Landscape landscape;
        private BallMovement ballMovement;
        private CannonModel cannonModel;
        private Arrow arrow;

        public List<GameObject> gameObjects;
        private Stack<GameObject> addedGameObjects;
        private Stack<GameObject> removedGameObjects;
        private KeyboardManager keyboardManager;
        public KeyboardState keyboardState;
        public AccelerometerReading accelerometerReading;
        public GameInput input;
        public AccelerometerReading accreading;

        public int attemptCount = 0;
        public int bestAttempt = 0;

        // Graphics assets
        public Assets assets;

        // Represents the camera's position and orientation
        public Camera camera;

        //camera view
        private Vector3 eye;
       // private Vector3 target;
        private Vector3 target1;
        private Vector3 target2;
        private Vector3 up;
        private Boolean ballview = false;
        private Boolean isTabDown = true;


        // World boundaries that indicate where the edge of the screen is for the camera.
        public float boundaryLeft;
        public float boundaryRight;
        public float boundaryTop;
        public float boundaryBottom;

        // boundaries of the Box
        private Vector3 top1;
        private Vector3 top2;
        private Vector3 top3;
        private Vector3 top4;
        public Vector3 down1;
        public Vector3 down2;
        public Vector3 down3;
        public Vector3 down4;

        public float xadjust = 0;


        private Vector3 initMatrix = new Vector3(0,0,-5);
        private Vector3 emptyMatrix = new Vector3(0, 0, 0);






        //ballParabolaMovement related variables
        public float time = 0f;  
        float a = 9.8f;
        public float y0;
        public float x0;
        public float z0;
        public float v0 = 7f;
        public double yDegree;
        public double degree;
        public int level;

        //rotation for the cannon
        private float rotationY = 1f;
        private float speed = 0.006f;

        //xaml variables
       public float difficulty = 1;
        private int score = 0;
        public bool gameStarted = false;
        public bool justLaunched = false;
      //  public int launchAngle = 0;
        private MainPage mainpage;
        //public int xAngle = 90;
      //  public int power = 50;

        public bool LaunchMode = false;

        public Vector2 cannonTargetVect;
        //inital the arrow 
        public float x1;
        public float y1;
        public float z1;

        public float xtree;
        public float ytree;

        /// <summary>
        /// Initializes a new instance of the <see cref="Project1Game" /> class.
        /// </summary>
        public Project1Game(MainPage mainpage)
        {

            // Creates a graphics manager. This is mandatory.
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            // Setup the relative directory to the executable directory
            // for loading contents with the ContentManager
            Content.RootDirectory = "Content";

            assets = new Assets(this);

            // Create the keyboard manager
            keyboardManager = new KeyboardManager(this);

            //new GameInput
            input = new GameInput();

            //// Initialise event handling.

            input.gestureRecognizer.Tapped += Tapped;

            input.gestureRecognizer.ManipulationStarted += OnManipulationStarted;

            input.gestureRecognizer.ManipulationUpdated += OnManipulationUpdated;

            input.gestureRecognizer.ManipulationCompleted += OnManipulationCompleted;

            // Set boundaries.
            boundaryLeft = -4.5f;
            boundaryRight = 4.5f;
            boundaryTop = 4;
            boundaryBottom = -4.5f;

            this.mainpage = mainpage;
        }

        protected override void LoadContent()
        {

            gameObjects = new List<GameObject>();
            addedGameObjects = new Stack<GameObject>();
            removedGameObjects = new Stack<GameObject>();

            

 
        


            base.LoadContent();
        }

        public void LoadLevel(int level)
        {
            this.level = level;
            landscape = new Landscape(this, level);
      
            // Create game objects.


            //for (int i = 0; i < 100; i++)
            //{
            //    Random random = new Random();
            //    xtree = (float)random.NextDouble() * 4;
            //    ytree = (float)random.NextDouble() * 4;

            //    if (landscape.getHeight(xtree, ytree) > -0.1)
            //    {
            //        Debug.WriteLine("works");
            //        Tree tree;
            //        tree = new Tree(this);
            //        gameObjects.Add(tree);
            //        tree.basicEffect.World = Matrix.Scaling(0.001f) * Matrix.Translation(xtree, (landscape.getHeight(xtree, ytree) + 1f), ytree);
            //    }


            //}



            

            ballMovement = new BallMovement(this);
            cannonModel = new CannonModel(this);
            arrow = new Arrow(this);

            gameObjects.Add(ballMovement);
            gameObjects.Add(new SkyBoxController(this));

            //this.cannonTargetVect = new Vector2(x1 - x0, z1 - z0);
            gameObjects.Add(landscape);
            gameObjects.Add(cannonModel);
            gameObjects.Add(arrow);


            //Set the inital postion of the ball
            ballMovement.pos = landscape.getCannonPos().Position;
            y0 = landscape.getCannonPos().Position.Y;
            x0 = landscape.getCannonPos().Position.X;
            z0 = landscape.getCannonPos().Position.Z;

            //inital the postion of the arrow
            x1 = landscape.getTargetPos().Position.X;
            y1 = landscape.getTargetPos().Position.Y;
            z1 = landscape.getTargetPos().Position.Z;
        }

        // Add a new game object.
        public void Add(GameObject obj)
        {
            if (!gameObjects.Contains(obj) && !addedGameObjects.Contains(obj))
            {
                addedGameObjects.Push(obj);
            }
        }
        protected override void Initialize()
        {
            Window.Title = "Project 1";
            camera = new Camera(this);
          
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            
            keyboardState = keyboardManager.GetState();

            

            
            if (gameStarted)
            {

                // set the postition of the cannonball base on the landscape 
                cannonModel.basicEffect.World = Matrix.RotationY(rotationY) * Matrix.Scaling(0.0003f) * Matrix.Translation(x0, y0 + 0.05f, z0);
                arrow.basicEffect.World = Matrix.Scaling(0.003f) * Matrix.Translation(x1, y1 + 0.3f + (float)arrow.ywave, z1);
                
                arrow.Update(gameTime);
                Debug.WriteLine(arrow.pos);

                accreading = input.accelerometer.GetCurrentReading();

                xadjust = (float) accreading.AccelerationX;
                

                if (!LaunchMode)
                {

                    launchViewUpdate();
                    //aim Cannon
                    rotationY = (float)((180 - degree) * Math.PI / 180);
                    if (keyboardState.IsKeyDown(Keys.Left))
                    {
                        rotationY -= speed;
                    }
                    if (keyboardState.IsKeyDown(Keys.Right))
                    {
                        rotationY += speed;
                    }
                    if (xadjust < 0.3 && xadjust > -0.3)
                    {
                        xadjust = 0;
                    }
                    rotationY += xadjust * 0.2f;

                    this.degree = 180 - rotationY / Math.PI * 180;
                    degree = this.mainpage.getDegreeValue();
                    this.mainpage.UpdateDegreeSlider((int)degree);
                    
                   
                }
                else
                {
                    //cannonball in air
                    CameraViewupdate();
                    Vector3 distanceMissed = new Vector3(landscape.getTargetPos().Position.X - ballMovement.pos.X,
                                                             landscape.getTargetPos().Position.Y - ballMovement.pos.Y,
                                                             landscape.getTargetPos().Position.Z - ballMovement.pos.Z);
                    if (justLaunched)
                    {

                //        BallViewUpdate();
                        attemptCount++;
                        mainpage.updateattempt(attemptCount);
                        justLaunched = false;
                    }
                    if (landscape.getHeight(ballMovement.pos.X, ballMovement.pos.Y) < ballMovement.pos.Y + 0.01f && !(distanceMissed.Length() < 0.1))
                    {
                        time += 0.004f;
                      //  this.ballParabolaMovement(time, this.x0, this.y0, this.z0, this.yDegree, this.degree);
                        if (landscape.getHeight(ballMovement.pos.X, ballMovement.pos.Y) < ballMovement.pos.Y)
                            ballMovement.Update(gameTime);
                        //  accelerometerReading = input.accelerometer.GetCurrentReading();
                        // this.degree += (float)accelerometerReading.AccelerationX;
                        //adjust path of ball
                        if (keyboardState.IsKeyDown(Keys.Left))
                        {
                            this.degree += 0.05f;

                        }
                        if (keyboardState.IsKeyDown(Keys.Right))
                        {
                            this.degree -= 0.05f;
                        }

                        this.degree += (float)-xadjust;

                       
                    }
                    else
                    {
                        //next level    
                        this.mainpage.viewLaunchControls();
                        LaunchMode = false;
                        time = 0;
                       //if win generate new level and update score
                        if(distanceMissed.Length() <0.1){
                            score +=(int)(10*difficulty);
                            difficulty += 1;
                            mainpage.UpdateScore(score);
                            if (attemptCount < bestAttempt || bestAttempt == 0)
                            {
                                bestAttempt = attemptCount;
                                attemptCount = 0;
                            }
                            mainpage.bestAttempt(bestAttempt);
                            mainpage.returnToMenu();
                            mainpage.hideLaunchControls();
                            this.LoadContent();
                        }

                    }
                }
                //accelerometerReading = input.accelerometer.GetCurrentReading();
             
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    gameObjects[i].Update(gameTime);
                }

       

             /*   if (keyboardState.IsKeyDown(Keys.Tab) && isTabDown)
                {
                    isTabDown = false;
                    if (ballview)
                    {
                      /*  ballMovement.basicEffect.View = Matrix.LookAtLH(initMatrix, emptyMatrix, Vector3.UnitY);
                        landscape.basicEffect.View = Matrix.LookAtLH(initMatrix, emptyMatrix, Vector3.UnitY);
                        cannonModel.basicEffect.View = Matrix.LookAtLH(initMatrix, emptyMatrix, Vector3.UnitY);
                      arrow.basicEffect.View = Matrix.LookAtLH(initMatrix, emptyMatrix, Vector3.UnitY);*/
        /*                BallViewUpdate();
                        ballview = false;
                    }
                    else
                    {
                        ballview = true;
                    }
                }
                if (keyboardState.IsKeyUp(Keys.Tab))
                {
                    isTabDown = true;
                }

                if (ballview)
                {
                    CameraViewupdate();
                }
                else
                {
                    target1 = new Vector3(4, 0, -4);
                    target2 = landscape.getCannonPos().Position;
                    eye.X = target2.X - 0.1f * (target1.X - target2.X);
                    eye.Y = target2.Y - 0.1f * (target1.Y - target2.Y) + 0.1f;
                    eye.Z = target2.Z - 0.1f * (target1.Z - target2.Z);
                    // eye = new Vector3(target2.X - 1.0f, target2.Y + 0.3f, target2.Z - 1.0f);
                    up = Vector3.UnitY;
                    ballMovement.basicEffect.View = Matrix.LookAtLH(eye, target2, up);
                    landscape.basicEffect.View = Matrix.LookAtLH(eye, target2, up);
                    cannonModel.basicEffect.View = Matrix.LookAtLH(eye, target2, up);
                    arrow.basicEffect.View = Matrix.LookAtLH(eye, target2, up);
                    cannonModel.basicEffect.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)cannonModel.game.GraphicsDevice.BackBuffer.Width / ballMovement.game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
                }*/
                ballMovement.basicEffect.World = Matrix.Scaling(0.01f) * Matrix.Translation(ballMovement.pos);




                if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    this.Exit();
                    this.Dispose();
                }
                // Handle base.Update
                //mainpage.UpdateScore(score);
                base.Update(gameTime);
            }
        }

        private void BallViewUpdate()
        {
            ballMovement.basicEffect.View = Matrix.LookAtLH(initMatrix, emptyMatrix, Vector3.UnitY);
            landscape.basicEffect.View = Matrix.LookAtLH(initMatrix, emptyMatrix, Vector3.UnitY);
            cannonModel.basicEffect.View = Matrix.LookAtLH(initMatrix, emptyMatrix, Vector3.UnitY);
            arrow.basicEffect.View = Matrix.LookAtLH(initMatrix, emptyMatrix, Vector3.UnitY);

        }

        private void launchViewUpdate()
        {
            target1 = new Vector3(4, 0, -4);
            target2 = landscape.getCannonPos().Position;
            eye.X = target2.X - 0.1f * (target1.X - target2.X);
            eye.Y = target2.Y - 0.1f * (target1.Y - target2.Y) + 0.1f;
            eye.Z = target2.Z - 0.1f * (target1.Z - target2.Z);
            // eye = new Vector3(target2.X - 1.0f, target2.Y + 0.3f, target2.Z - 1.0f);
            up = Vector3.UnitY;
            ballMovement.basicEffect.View = Matrix.LookAtLH(eye, target2, up);
            landscape.basicEffect.View = Matrix.LookAtLH(eye, target2, up);
            cannonModel.basicEffect.View = Matrix.LookAtLH(eye, target2, up);
            arrow.basicEffect.View = Matrix.LookAtLH(eye, target2, up);
            cannonModel.basicEffect.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)cannonModel.game.GraphicsDevice.BackBuffer.Width / ballMovement.game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
        }

        private void CameraViewupdate()
        {

            target1 = ballMovement.pos;
            target2 = landscape.getCannonPos().Position;
            if(landscape.checkBoundary(ballMovement.pos)){
            eye.X = target2.X + time * 0.5f*(target1.X - target2.X);
            eye.Y = ballMovement.pos.Y + 1.0f;
            eye.Z = target2.Z + time*0.5f*(target1.Z - target2.Z);
            up = Vector3.UnitY;
            }
           // eye = new Vector3(ballMovement.pos.X - 0.5f, ballMovement.pos.Y + 1.0f, ballMovement.pos.Z - 0.5f);

           // up = new Vector3(ballMovement.pos.X, ballMovement.pos.Y + 1.0f, ballMovement.pos.Z);
            //up = Vector3.UnitY;eye.X = ballMovement.pos.X - 3.0f;
            //eye.Y = ballMovement.pos.Y;
            //eye.Z = ballMovement.pos.Z - 3.0f;
            //target = ballMovement.pos;
            //up.X = ballMovement.pos.X;
            //up.Y = ballMovement.pos.Y + 1.0f;
            //up.Z = ballMovement.pos.Z;
            ballMovement.basicEffect.View = Matrix.LookAtLH(eye, target1, up);
            landscape.basicEffect.View = Matrix.LookAtLH(eye, target1, up);
            cannonModel.basicEffect.View = Matrix.LookAtLH(eye, target1, up);
            arrow.basicEffect.View = Matrix.LookAtLH(eye, target1, up);
       //     camera.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)landscape.game.GraphicsDevice.BackBuffer.Width / landscape.game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
      //      camera.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)ballMovement.game.GraphicsDevice.BackBuffer.Width / ballMovement.game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
     //       camera.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)cannonModel.game.GraphicsDevice.BackBuffer.Width / ballMovement.game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clears the screen with the Color.CornflowerBlue
            GraphicsDevice.Clear(Color.CornflowerBlue);

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw(gameTime);
            }

            // Handle base.Draw
            base.Draw(gameTime);
        }



        public void OnManipulationStarted(GestureRecognizer sender, ManipulationStartedEventArgs args)
        {

            // Pass Manipulation events to the game objects.



        }



        public void Tapped(GestureRecognizer sender, TappedEventArgs args)
        {

            // Pass Manipulation events to the game objects.

           // foreach (var obj in gameObjects)
           // {

           //     obj.Tapped(sender, args);

           // }

        }



        public void OnManipulationUpdated(GestureRecognizer sender, ManipulationUpdatedEventArgs args)
        {

            //TASK 3: Update camera position when scaling occurs

         /*   camera.pos.Z = camera.pos.Z * args.Delta.Scale;

            // Update camera position for all game objects

            foreach (var obj in gameObjects)
            {

                if (obj.basicEffect != null) { obj.basicEffect.View = camera.View; }



                // TASK 4: Respond to OnManipulationUpdated events for linear motion

                obj.OnManipulationUpdated(sender, args);

            }*/

        }



        public void OnManipulationCompleted(GestureRecognizer sender, ManipulationCompletedEventArgs args)
        {

        }
    }
}