using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Toolkit;
using SharpDX;

namespace Project1
{
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;
    using System.Diagnostics;

    class SkyBox : GameObject
    {
        private float projectileSpeed = 10;
        float fireTimer;
        float fireWaitMin = 2000;
        float fireWaitMax = 20000;

        public Buffer vertices;
        private VertexPositionTexture[] shapeArray;
        public VertexInputLayout inputLayout;
        public int vertexStride;
        public ModelType modelType;
        public Texture2D Texture;
        public BasicEffect basicEffect;

        public SkyBox(Project1Game game, Vector3 pos)
        {
            this.game = game;
            myModel = game.assets.GetModel("ship", CreateEnemyModel);
            //==================
            //type = GameObjectType.Enemy;
            this.pos = pos;
            basicEffect = GetParamsFromModel();
        }

        //public MyModel getModel()
        //{
        //    return myModel;
        //}


        public MyModel CreateEnemyModel()
        {
            return game.assets.CreateTexturedCube("skybox_texture.jpg", 8f);
        }

        //private MyModel CreateEnemyProjectileModel()
        //{
        //    return game.assets.CreateTexturedCube("enemy projectile.png", new Vector3(0.2f, 0.2f, 0.4f));
        //}

        public override void Update(GameTime gameTime)
        {
            fireTimer -= gameTime.ElapsedGameTime.Milliseconds;
            basicEffect.World = Matrix.Translation(pos);
        }

        public override void Draw(SharpDX.Toolkit.GameTime gametime)
        {
        }
    }
}
