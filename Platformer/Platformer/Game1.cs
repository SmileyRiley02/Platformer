using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using MonoGame.Extended.ViewportAdapters;
using System.Collections;
namespace Platformer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player = new Player(); //Create an instance of our player

        Camera2D camera = null;
        TiledMap map = null;
        TiledMapRenderer mapRenderer = null;
        TiledMapTileLayer collisionLayer;
        public ArrayList allCollisionFiles = new ArrayList();
        public Sprite[,] levelGrid;
        public int tileHeight;
        public int levelTileHeight = 0;
        public int levelTileWidth = 0;



        public Rectangle myMap;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            myMap.X = 0;
            myMap.Y = 0;
            myMap.Width = 1600;
            myMap.Height = 1600;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player.Load(Content, this); //call the "load" function in the Player Class

            BoxingViewportAdapter viewportAdapter = new BoxingViewportAdapter(Window,
                                                                              GraphicsDevice,
                                                                              graphics.GraphicsDevice.Viewport.Width,
                                                                              graphics.GraphicsDevice.Viewport.Height);

            camera = new Camera2D(viewportAdapter);
            camera.Position = new Vector2(0, graphics.GraphicsDevice.Viewport.Height);

            map = Content.Load<TiledMap>("level1");
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        public void SetupTiles()
        {
            tileHeight = map.TileHeight;
            levelTileHeight = map.Height;
            levelTileWidth = map.Width;
            levelGrid = new Sprite[levelTileWidth, levelTileHeight];
            foreach(TiledMapTileLayer layer in map.TileLayers)
            {
                if (layer.Name == "Collision")
                {
                    collisionLayer = layer;
                }
            }
            int columns = 0;
            int rows = 0;
            int loadCount = 0;
            while (loadCount<collisionLayer.Tiles.Count)
            {
                if (collisionLayer.Tiles[loadCount].GlobalIdentifier != 0)
                {
                    Sprite tileSprite = new Sprite();
                    tileSprite.position.X = columns * tileHeight;
                    tileSprite.position.Y = rows * tileHeight;

                }
            }
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            player.Update(deltaTime); //Call the "Update" from our Player class
            // TODO: Add your update logic here

            camera.Position = player.playerSprite.position - new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                                                                        graphics.GraphicsDevice.Viewport.Height / 2);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            var viewMatrix = camera.GetViewMatrix();
            var projecttimeMatrix = Matrix.CreateOrthographicOffCenter(0,
                                                                        GraphicsDevice.Viewport.Width,
                                                                        GraphicsDevice.Viewport.Height,
                                                                        0,0.0f, -1.0f);

            spriteBatch.Begin(transformMatrix: viewMatrix);
            mapRenderer.Draw(map, ref viewMatrix, ref viewMatrix);
            player.Draw(spriteBatch);
            spriteBatch.End();





            base.Draw(gameTime);
        }
    }
}
