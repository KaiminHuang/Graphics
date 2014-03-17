using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;


namespace Project1
{
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;
    using System.Diagnostics;
    
    // Enemy Controller class.
    class SkyBoxController : GameObject
    {
        // Spacing and counts.
        private int rows = 0;
        private int enemiesPerRow = 8;
        private float rowSpacing = 0.6f;
        private float colSpacing = 0.6f;

        // Timing and movement.
        private float stepSize = 1f;
        private float stepWait = 0;
        private float stepTimer = 0;
        private bool stepRight;
        private SkyBox skybox;


        // Constructor.
        public SkyBoxController(Project1Game game)
        {
            this.game = game;
            skybox = new SkyBox(game, new Vector3(0, 0, 0));
            this.game.Add(skybox);
        }

        // Frame update method.
        public override void Update(GameTime gameTime)
        {

        }
        public override void Draw(SharpDX.Toolkit.GameTime gametime)
        {



                // Setup the vertices
            game.GraphicsDevice.SetVertexBuffer(0, skybox.myModel.vertices, skybox.myModel.vertexStride);
            game.GraphicsDevice.SetVertexInputLayout(skybox.myModel.inputLayout);

                // Apply the basic effect technique and draw the object
            skybox.basicEffect.CurrentTechnique.Passes[0].Apply();
                game.GraphicsDevice.Draw(PrimitiveType.TriangleList, skybox.myModel.vertices.ElementCount);
        }
    }
}

