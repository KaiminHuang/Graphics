﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;
namespace Project1
{
    public class Camera
    {
        public Matrix View;
        public Matrix Projection;
        public Game game;

        public void SetProjection(Matrix View)
        {
            this.View = View;
        }

        // Ensures that all objects are being rendered from a consistent viewpoint  Vector3.UnitY  new Vector3(0,1,0)
        public Camera(Game game)
        {
            View = Matrix.LookAtLH(new Vector3(3, 3, 3), new Vector3(0, 0, 0), Vector3.UnitY);
            Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)game.GraphicsDevice.BackBuffer.Width / game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
            this.game = game;
        }

        // If the screen is resized, the projection matrix will change
        public void Update()
        {
            Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)game.GraphicsDevice.BackBuffer.Width / game.GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
        }
    }
}


