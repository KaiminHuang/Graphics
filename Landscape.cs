using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Toolkit;

namespace Project1
{
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;
    using System.Diagnostics;
    class Landscape : ColoredGameObject
    {
        //Set the speed of rotaion
        private float speed = 0.006f;
        //The default rotation of the Landscape
        private float rotationX = -0.5f;
        private float rotationY = 0.0f;
        private float rotationZ = 0.0f;
        private float baseline;
        private float pix = 0.0625f; // 0.125f or 0.0625
        float zooming = 4.0f;

        private int level = 3;
        public float landscapeWidth = 2f;
        public float landscapeHeight = 2f;
        //Here to set the Level, TODO create a new screen for level selecting
        public void setLevel(int level, float landscapeHeight, float landscapeWidth)
        {
            this.landscapeWidth = landscapeWidth;
            this.landscapeHeight = landscapeHeight;
            this.level = level;
        }
        // an array of Vectors  without color setting
        private Vector3[] buffer;
        // an array of Vectors  with color setting
        private VertexPositionColor[] colorBuffer;
        BufferGenerator bufferGenerator = new BufferGenerator();


        public Landscape(Project1Game game)
        {
            this.SetBuffer();
            vertices = Buffer.Vertex.New(game.GraphicsDevice, colorBuffer);

            basicEffect = new BasicEffect(game.GraphicsDevice)
            {
                View = game.camera.View,
                Projection = game.camera.Projection,
                World = Matrix.Identity,
                VertexColorEnabled = true
            };

            inputLayout = VertexInputLayout.FromBuffer(0, vertices);
            this.game = game;
        }

        public override void Update(GameTime gameTime)
        {
            // Listen to the keyboard to rotate the landscape
            if (game.keyboardState.IsKeyDown(Keys.Left))
            {
                rotationY -= speed;
                basicEffect.World = Matrix.RotationX(rotationX) * Matrix.RotationY(rotationY) * Matrix.RotationZ(rotationZ);
            }
            if (game.keyboardState.IsKeyDown(Keys.Right))
            {
                rotationY += speed;
                basicEffect.World = Matrix.RotationX(rotationX) * Matrix.RotationY(rotationY) * Matrix.RotationZ(rotationZ);
            }
            if (game.keyboardState.IsKeyDown(Keys.Up))
            {
                rotationX -= speed;
                basicEffect.World = Matrix.RotationX(rotationX) * Matrix.RotationY(rotationY) * Matrix.RotationZ(rotationZ);
            }
            if (game.keyboardState.IsKeyDown(Keys.Down))
            {
                rotationX += speed;
                basicEffect.World = Matrix.RotationX(rotationX) * Matrix.RotationY(rotationY) * Matrix.RotationZ(rotationZ);
            }
            if (game.keyboardState.IsKeyDown(Keys.W))
            {
                zooming = zooming + 0.1f;
            }
            if (game.keyboardState.IsKeyDown(Keys.S))
            {
                zooming = zooming - 0.1f;
                if (zooming < 2.0f)
                {
                    zooming = 2.0f;
                }
            }
            //basicEffect.World = Matrix.RotationX(0.1f) * Matrix.RotationY(0.2f) * Matrix.RotationZ(0);
            basicEffect.Projection = Matrix.PerspectiveFovLH((float)Math.PI / zooming, (float)game.GraphicsDevice.BackBuffer.Width / game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
        }

        public override void Draw(GameTime gameTime)
        {
            // Setup the vertices
            game.GraphicsDevice.SetVertexBuffer(vertices);
            game.GraphicsDevice.SetVertexInputLayout(inputLayout);

            // Apply the basic effect technique and draw the rotating cube
            basicEffect.CurrentTechnique.Passes[0].Apply();
            game.GraphicsDevice.Draw(PrimitiveType.TriangleList, vertices.ElementCount);
        }

        private void SetBuffer()
        {

            bufferGenerator.SetPix(pix);

            //To generate a random float number
            Random rd = new Random();
            float c1, c2, c3, c4;
            c1 = (float)rd.NextDouble(0, 1.0);
            c2 = (float)rd.NextDouble(0, 1.0);
            c3 = (float)rd.NextDouble(0, 1.0);
            c4 = (float)rd.NextDouble(0, 1.0);
            // to record the baseline of landscape's height
            baseline = (c1 + c2 + c3 + c4) / 4;
            bufferGenerator.SetBaseLine(baseline);
            bufferGenerator.SetLandscapeHeight(this.landscapeHeight);
            bufferGenerator.SetLandscapeWidth(this.landscapeWidth);

            //The position of 4 connors of the landscape
            Vector3 dpos1 = new Vector3(0.0f - landscapeWidth/2, c1, 0.0f + landscapeHeight/2);//look from the top, left up conor
            Vector3 dpos2 = new Vector3(dpos1.X + landscapeWidth, c2, dpos1.Z);//look from the top, right up conor
            Vector3 dpos3 = new Vector3(dpos1.X + landscapeWidth, c3, dpos1.Z - landscapeHeight);//look from the top, right down conor
            Vector3 dpos4 = new Vector3(dpos1.X, c4, dpos1.Z - landscapeHeight);//look from the top, left down conor

            float width = Math.Abs(dpos1.X - dpos2.X);
            float height = Math.Abs(dpos1.Z - dpos3.Z);
            this.colorBuffer = new VertexPositionColor[] { };
            this.buffer = new Vector3[] { };
            bufferGenerator.setLevel(level, landscapeHeight,landscapeWidth,dpos1);

            this.buffer = bufferGenerator.DivideGrid(dpos1.X, dpos1.Z, width, height, c1, c2, c3, c4);
            this.bufferGenerator.setColorRanges();
            this.colorBuffer = bufferGenerator.setColor();
            this.colorBuffer = bufferGenerator.setCannonPos();
            this.colorBuffer = bufferGenerator.AddBox(dpos1, dpos2, dpos3, dpos4);
            this.colorBuffer = bufferGenerator.AddBase(dpos1, dpos2, dpos3, dpos4);

        }

 
    }
}
