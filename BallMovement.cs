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
    class BallMovement : ColoredGameObject
    {


        //private float speed = 0.001f;
        //private Vector3 eye;
        //private Vector3 target;
        //private Vector3 up;
        //Landscape landscape;

        public BallMovement(Project1Game game)
        {
            //this.game = game;
            //vectors = new Vector3[] { };
            //myModel = game.ball.GetModel("ball", CreatePlayerModel);
            //pos = new SharpDX.Vector3(0, game.boundaryBottom + 0.5f, 0);
            //GetParamsFromModel();

            vertices = Buffer.Vertex.New(
                game.GraphicsDevice,
             new[]
                    {

                        new VertexPositionColor(new Vector3(-0.1f, -0.1f, -0.1f), Color.OrangeRed), // Bottom
                        new VertexPositionColor(new Vector3(0.1f, -0.1f, 0.1f), Color.OrangeRed),
                        new VertexPositionColor(new Vector3(-0.1f, -0.1f, 0.1f), Color.OrangeRed),
                        new VertexPositionColor(new Vector3(-0.1f, -0.1f, -0.1f), Color.OrangeRed),
                        new VertexPositionColor(new Vector3(0.1f, -0.1f, -0.1f), Color.OrangeRed),
                        new VertexPositionColor(new Vector3(0.1f, -0.1f, 0.1f), Color.OrangeRed),
                        new VertexPositionColor(new Vector3(-0.1f, -0.1f, -0.1f), Color.DarkOrange), // left
                        new VertexPositionColor(new Vector3(-0.1f, -0.1f, 0.1f), Color.DarkOrange),
                        new VertexPositionColor(new Vector3(0, 0.1f, 0f), Color.DarkOrange),
                        new VertexPositionColor(new Vector3(0.1f, -0.1f, -0.1f), Color.DarkOrange), //Right
                        new VertexPositionColor(new Vector3(0,0.1f, 0f), Color.DarkOrange),
                        new VertexPositionColor(new Vector3(0.1f, -0.1f, 0.1f), Color.DarkOrange),
                        new VertexPositionColor(new Vector3(0.1f, -0.1f, 0.1f), Color.DarkOrange), // up
                        new VertexPositionColor(new Vector3(0,0.1f, 0f), Color.DarkOrange),
                        new VertexPositionColor(new Vector3(-0.1f, -0.1f, 0.1f), Color.DarkOrange),
                        new VertexPositionColor(new Vector3(-0.1f, -0.1f, -0.1f), Color.DarkOrange), //down
                        new VertexPositionColor(new Vector3(0, 0.1f, 0f), Color.DarkOrange),
                        new VertexPositionColor(new Vector3(0.1f, -0.1f, -0.1f), Color.DarkOrange),
                    });

            basicEffect = new BasicEffect(game.GraphicsDevice)
            {
                View = game.camera.View,
                Projection = game.camera.Projection,
                World = Matrix.Identity,
                VertexColorEnabled = true
            };

            inputLayout = VertexInputLayout.FromBuffer(0, vertices);

            this.game = game;
            pos = new SharpDX.Vector3(0, 0, 0);
        }

        //public MyModel CreatePlayerModel()
        //{
        //    return game.ball.CreatTexturedCircle();
        //}

        public override void Update(SharpDX.Toolkit.GameTime gametime)
        {
        }

        public override void Draw(SharpDX.Toolkit.GameTime gametime)
        {
            // Setup the vertices
            game.GraphicsDevice.SetVertexBuffer(vertices);
            game.GraphicsDevice.SetVertexInputLayout(inputLayout);

            // Apply the basic effect technique and draw the rotating cube
            basicEffect.CurrentTechnique.Passes[0].Apply();
            game.GraphicsDevice.Draw(PrimitiveType.TriangleList, vertices.ElementCount);
        }
    }
}
