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
        public List<GameObject> gameObjects;
        private Stack<GameObject> addedGameObjects;
        private Stack<GameObject> removedGameObjects;
        private KeyboardManager keyboardManager;
        public KeyboardState keyboardState;


        // Represents the camera's position and orientation
        public Camera camera;

        // Graphics ball
        public Ball ball;

        //camera view
        private Vector3 eye;
        private Vector3 target;
        private Vector3 up;
        private Boolean ballview = false;


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
        private Vector3 down1;
        private Vector3 down2;
        private Vector3 down3;
        private Vector3 down4;


        /// <summary>
        /// Initializes a new instance of the <see cref="Project1Game" /> class.
        /// </summary>
        public Project1Game()
        {
            // Creates a graphics manager. This is mandatory.
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            // Setup the relative directory to the executable directory
            // for loading contents with the ContentManager
            Content.RootDirectory = "Content";

            // Create the keyboard manager
            keyboardManager = new KeyboardManager(this);
            ball = new Ball(this);

            // Set boundaries.
            boundaryLeft = -4.5f;
            boundaryRight = 4.5f;
            boundaryTop = 4;
            boundaryBottom = -4.5f;
        }

        protected override void LoadContent()
        {
            gameObjects = new List<GameObject>();
            addedGameObjects = new Stack<GameObject>();
            removedGameObjects = new Stack<GameObject>();

            // Create game objects.
            landscape = new Landscape(this);
            ballMovement = new BallMovement(this);
            gameObjects.Add(ballMovement);
            gameObjects.Add(landscape);
            // Create an input layout from the vertices

            base.LoadContent();
        }

        protected override void Initialize()
        {
            Window.Title = "Project 1";
            camera = new Camera(this);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {

            this.setBoxBoundary(landscape.landscapeHeight, landscape.landscapeWidth);
            Debug.WriteLine("ballMovement.pos"+ballMovement.pos);
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(gameTime);
            }

            keyboardState = keyboardManager.GetState();

            if (ballMovement.game.keyboardState.IsKeyDown(Keys.Tab))
            {
                if (ballview)
                {
                    ballMovement.basicEffect.View = Matrix.LookAtLH(new Vector3(0, 0, -5), new Vector3(0, 0, 0), Vector3.UnitY);
                    landscape.basicEffect.View = Matrix.LookAtLH(new Vector3(0, 0, -5), new Vector3(0, 0, 0), Vector3.UnitY);
                    ballview = false;
                }
                else
                {
                    ballview = true;
                }
            }
            if (this.checkBoundary(ballMovement.pos))
            {
                if (ballMovement.game.keyboardState.IsKeyDown(Keys.H)) { ballMovement.pos.X -= 0.1f; }
                if (ballMovement.game.keyboardState.IsKeyDown(Keys.K)) { ballMovement.pos.X += 0.1f; }
                if (ballMovement.game.keyboardState.IsKeyDown(Keys.U)) { ballMovement.pos.Y += 0.1f; }
                if (ballMovement.game.keyboardState.IsKeyDown(Keys.J)) { ballMovement.pos.Y -= 0.1f; }
                if (ballMovement.game.keyboardState.IsKeyDown(Keys.Y)) { ballMovement.pos.Z += 0.1f; }
                if (ballMovement.game.keyboardState.IsKeyDown(Keys.I)) { ballMovement.pos.Z -= 0.1f; }
            }

            if (ballview)
            {
                CameraViewupdate();
            }
            ballMovement.basicEffect.World = Matrix.Translation(ballMovement.pos);

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
                this.Dispose();
            }
            // Handle base.Update
            base.Update(gameTime);
        }

        private void CameraViewupdate()
        {
            eye = new Vector3(ballMovement.pos.X - 3.0f, ballMovement.pos.Y, ballMovement.pos.Z - 3.0f);
            target = ballMovement.pos;
            up = new Vector3(ballMovement.pos.X, ballMovement.pos.Y + 1.0f, ballMovement.pos.Z);
            ballMovement.basicEffect.View = Matrix.LookAtLH(eye, target, up);
            landscape.basicEffect.View = Matrix.LookAtLH(eye, target, up);
            camera.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)landscape.game.GraphicsDevice.BackBuffer.Width / landscape.game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
            camera.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)ballMovement.game.GraphicsDevice.BackBuffer.Width / ballMovement.game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
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

        private void setBoxBoundary(float height, float width)
        {
            //The position of 4 connors of the landscape
            down1 = new Vector3(0.0f - width / 2, 0.0f, 0.0f + height / 2);//look from the top, left up conor
            down2 = new Vector3(0.0f + width / 2, 0.0f, 0.0f + height / 2);//look from the top, right up conor
            down3 = new Vector3(0.0f + width / 2, 0.0f, 0.0f - height / 2);//look from the top, right down conor
            down4 = new Vector3(0.0f - width / 2, 0.0f, 0.0f - height / 2);//look from the top, left down conor
        }

        private Boolean checkBoundary(Vector3 ballPos)
        {
            if (ballPos.X >= down4.X && ballPos.X <= down3.X && ballPos.Z >= down4.Z && ballPos.Z <= down1.Z)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
