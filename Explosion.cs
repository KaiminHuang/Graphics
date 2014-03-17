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
    // Projectile classed, used by both player and enemy.
    class Explosion : ColoredGameObject
    {
        private Vector3 vel;
        private float hitRadius = 0.5f;
        private float squareHitRadius;

        private float aliveTime = .9f;
        private float timeElapsed = 0.0f;

        private float dynamicScale;

        private Color color;

        private float spawnTimeOffset = 0;
        private bool head;
        private Matrix scale;

        // an array of Vectors  without color setting
        private Vector3[] buffer;
        // an array of Vectors  with color setting
        private VertexPositionColor[] colorBuffer;

        // Constructor.
        public Explosion(Project1Game game)
        {
            this.game = game;
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
            
        }

        // Frame update method.
        public override void Update(GameTime gameTime)
        {
            //// Apply velocity to position.
            //pos += vel * timeDelta;// *0.5f;
            //transformation = Matrix.RotationQuaternion(game.asteroidRotate);

            //timeElapsed += timeDelta;
            ////dynamicScale *= 1.01f;
            //dynamicScale *= .95f;

            //if (timeElapsed < aliveTime / 2)
            //{
            //    this.vel.X -= this.vel.Y / 100f;
            //    this.vel.Y += this.vel.X / 100f;
            //    this.vel.Z += this.vel.X / 100f;
            //}
            //else
            //{
            //    this.vel.X += this.vel.Y / 100f + Game.random.Next(-100, 100) / 100f; ;
            //    this.vel.Y -= this.vel.X / 100f + Game.random.Next(-100, 100) / 100f; ;
            //    this.vel.Z -= this.vel.X / 100f + Game.random.Next(-100, 100) / 100f; ;
            //}

            //if (head && spawnTimeOffset + 0.1f < timeElapsed)
            //{
            //    var newVel = this.vel / 2f;
            //    newVel.X += spawnTimeOffset + Game.random.Next(-100, 100) / 100f;
            //    newVel.Y -= spawnTimeOffset + Game.random.Next(-100, 100) / 100f;
            //    newVel.Z += spawnTimeOffset + Game.random.Next(-100, 100) / 100f;
            //    game.Add(new Explosion(game, this.pos, newVel, this.colour, 0.1f, false));
            //    spawnTimeOffset = timeElapsed;
            //}


            //this.scale = Matrix.Scaling(dynamicScale);

            //if (timeElapsed > aliveTime)
            //    game.Remove(this);

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
            this.colorBuffer = setVertex();
        }


        public VertexPositionColor[] setVertex()
        {
            VertexPositionColor[] buffer = new VertexPositionColor[3];
            List<VertexPositionColor> colorBufferList = buffer.ToList();
            for (int i = 0; i < 2; i++)
            {
                colorBufferList.Add(this.game.assets.CreateColoredTriangle(new Vector3(10, 10, 10), Color.Red)[i]);

            }
            buffer = colorBufferList.ToArray();
            return buffer;
        }

        public Vector3 findPos()
        {
            return new Vector3(1, 1, 1);
        }

    }



    }
