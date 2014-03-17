﻿using System;
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
        float a = 9.8f;
        public BallMovement(Project1Game game)
        {

            model = game.Content.Load<Model>("Sphere");
            basicEffect = new BasicEffect(game.GraphicsDevice)
            {
                View = game.camera.View,
                Projection = game.camera.Projection,
                World = Matrix.Scaling(0.05f),
                VertexColorEnabled = true
            };

            BasicEffect.EnableDefaultLighting(model,true);
            inputLayout = VertexInputLayout.FromBuffer(0, vertices);

            this.game = game;
            pos = new SharpDX.Vector3(0, 0.1f, 0);
        }

        public override void Update(SharpDX.Toolkit.GameTime gametime)
        {
            float a = 9.8f;
            pos.Z = game.z0 - game.v0 * (float)Math.Cos(((game.yDegree / 180.0) * Math.PI)) * (float)(Math.Cos((game.degree / 180) * Math.PI)) * game.time;
            pos.X = game.x0 + game.v0 * (float)Math.Cos(((game.yDegree / 180.0) * Math.PI)) * (float)(Math.Sin((game.degree / 180) * Math.PI)) * game.time;
            pos.Y = (game.y0 + (game.v0 * (float)Math.Sin(((game.yDegree / 180.0) * Math.PI)) * game.time)) - (0.5f * a * game.time * game.time);
        }


        public override void Draw(SharpDX.Toolkit.GameTime gametime)
        {
            //model.Draw(game.GraphicsDevice, basicEffect.World, basicEffect.View, basicEffect.Projection);
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    // effect.EnableDefaultLighting();
                    effect.LightingEnabled = true; // Turn on the lighting subsystem.

                    effect.DirectionalLight0.DiffuseColor = new Vector3(0f, 1f, 0f); // a reddish light
                    effect.DirectionalLight0.Direction = new Vector3(pos.X +100, pos.Y+500, pos.Z+ 500);  // coming along the x-axis
                    effect.DirectionalLight0.SpecularColor = new Vector3(0, 0, 0); // with green highlights

                    effect.AmbientLightColor = new Vector3(0.2f, 0.2f, 0.2f); // Add some overall ambient light.
                    // effect.EmissiveColor = new Vector3(1, 0, 0); // Sets some strange emmissive lighting.  This just looks weird.

                    effect.World = this.basicEffect.World;
                    effect.View = this.basicEffect.View;
                    effect.Projection = this.basicEffect.Projection;

                    //     effect.TextureEnabled = true;
                    //     effect.Texture = texture; 
                }

                mesh.Draw(game.GraphicsDevice);
            }
        }
    }
}
