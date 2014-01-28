using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Blocker
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        # if WINDOWSPHONE
        public static Vector2 ScreenSize = new Vector2(800f, 480f);
        # endif
//# if ANDROID
        public static Vector2 ScreenSize = new Vector2(1280, 800f);
//# endif
        #region Fields
        public GraphicsDeviceManager graphics;
        ScreenManager screenManager;

        static readonly string[] preloadAssets = {@"Textures_Menu\gradient",};
        #endregion

        public Game1()
        {
            Content.RootDirectory = "Content";
            
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            InitializeLandscapeGraphics();
            
            // Create the screen manager component.
            screenManager = new ScreenManager(this);           
            Components.Add(screenManager);
            // attempt to deserialize the screen manager from disk. if that fails, we add our default screens.
            if (!screenManager.DeserializeState())
            {
                // Activate the first screens.
                screenManager.AddScreen(new BackgroundScreen(), null);
                screenManager.AddScreen(new MainMenuScreen(), null);
            }
            SceneManager.MainGame = this;
        }


        protected override void OnExiting(object sender, System.EventArgs args)
        {
            // serialize the screen manager whenever the game exits
            screenManager.SerializeState();
            base.OnExiting(sender, args);
        }

        /// <summary>
        /// Helper method to the initialize the game to be a portrait game.
        /// </summary>
        private void InitializePortraitGraphics()
        {
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;

        }

        /// <summary>
        /// Helper method to initialize the game to be a landscape game.
        /// </summary>
        private void InitializeLandscapeGraphics()
        {
# if WINDOWSPHONE
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
# endif
#if ANDROID/// this maybe display bug on android
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 800;
#endif
        }

        /// <summary>
        /// Loads graphics content.
        /// </summary>
        protected override void LoadContent()
        {
            //this line rezizes screen to proper size on Nexus 7
            graphics.GraphicsDevice.Viewport = new Viewport(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); 
            foreach (string asset in preloadAssets)
            {
                Content.Load<object>(asset);
            }
        }


        protected override void UnloadContent()
        {
            Content.Unload();
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();

            // TODO: Add your update logic here
            //Game1.Activity.OnConfigurationChanged(orientation);
            if (graphics.GraphicsDevice.Viewport.Width != 1280 || graphics.GraphicsDevice.Viewport.Height != 800)
                graphics.GraphicsDevice.Viewport = new Viewport(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); 
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }


#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
#endif
}
