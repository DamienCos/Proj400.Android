using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AndroidTest
{
    public class FrameRateCounter : DrawableGameComponent
    {
        private ContentManager content;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        private Vector2 fpsScreenLocation = new Vector2(0, 0);
        private int frameRate = 0;
        private int frameCounter = 0;
        private float elapsedTime = 0f;
        private string fpsString = "fps: ??";

        public FrameRateCounter(Game game)
            : base(game)
        {
            content = new ContentManager(game.Services, "Content");
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = content.Load<SpriteFont>("gamefont");
        }

        protected override void UnloadContent()
        {
            content.Unload();
        }

        public override void Draw(GameTime gameTime)
        {
#if(DEBUG)
            frameCounter++;
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime >= 1f)
            {
                elapsedTime -= 1f;
                frameRate = frameCounter;
                frameCounter = 0;

                float averageFrameLength = 1000f / frameRate;
                fpsString = string.Format("fps: {0} ({1} ms)", frameRate, averageFrameLength);
            }

            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, fpsString, fpsScreenLocation, Color.White);
            spriteBatch.End();
#endif
        }

    }
}