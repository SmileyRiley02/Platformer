using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Collision
    {
        public Game1 game;

        public bool IsColliding(Sprite hero, Sprite otherSprite)
        {
            // Compares the position of each rectangles edges aginst the other
            // it compares the opposite edges of each rectangle, ie, the left edge of one with the right of the other
            if (hero.rightEdge < otherSprite.leftEdge || hero.leftEdge > otherSprite.rightEdge || hero.bottomEdge < otherSprite.topEdge || hero.topEdge > otherSprite.bottomEdge)
            {
                // these two rectangles are not colliding
                return false;
            }
            // Otherwise, the two AABB rectangles overlap, therefore there is a collision
            return true;
        }
        bool CheckForTile(Vector2 coordinates) // Checks if there is a tile at the specified coordinates
        {
            int column = (int)coordinates.X;
            int row = (int)coordinates.Y;

            if (column < 0 || column > game.levelTileWidth - 1)
            {
                return false;
            }
            if (row < 0 || row > game.levelTileHeight - 1)
            {
                return true;
            }

            Sprite tileFound = game.levelGrid[column, row];

            if (tileFound != null)
            {
                return true;
            }

            return false;
        }

        Sprite CollideLeft(Sprite hero, Vector2 tileIndex, Sprite playerPrediction)
        {
            Sprite tile = game.levelGrid[(int)tileIndex.X, (int)tileIndex.Y];
            if (IsColliding(playerPrediction, tile) == true && hero.velocity.X < 0)
            {
                hero.Position.X = tile.rightEdge + hero.offset.X;
                hero.velocity.X = 0;
            }

            return hero;
        }
        Sprite CollideBottomDiagonals(Sprite hero, Vector2 tileIndex, Sprite playerPrediction)
        {
            Sprite tile = game.levelGrid(int)tileIndex.X,(int)tileIndex.Y];
            int leftEdgeDistance = Math.Abs(tile.leftEdge - playerPrediction.rightEdge);

            int rightEdgeDistance = Math.Abs(tile.rightEdge - playerPrediction.leftEdge);

            int topEdgeDistance = Math.Abs(tile.topEdge - playerPrediction.bottomEdge);

            if (IsColliding(playerPrediction, tile) == true)
            {
                if (topEdgeDistance < rightEdgeDistance && topEdgeDistance < leftEdgeDistance)
                {
                    //if the top edge is closes, collision is happening to the right of the platform
                    hero.Position.Y = tile.topEdge - hero.height + hero.offset.Y;
                    hero.velocity.Y = 0;


                }
                else if (rightEdgeDistance < leftEdgeDistance)
                {
                    hero.Position.X = rightEdgeDistance + hero.offset.X;
                    hero.velocity.X = 0;


                }
                else
                {
                    hero.Position.X = tile.leftEdge - hero.width + hero.offset.X;
                    hero.velocity.X = 0;
                }
                
                Sprite CollideBellow (Sprite hero, Vector2 titleIndex, Sprite playerPrediction)
                {
                    Sprite tile = game.levelGrid(int)tileIndex.X, (int)tileIndex.Y];
                    int leftEdgeDistance = Math.Abs(tile.rightEdge - playerPrediction.leftEdge);

                    int rightEdgeDistance = Math.Abs(tile.leftEdge - playerPrediction.rightEdge);

                    int bottomEdgeDistance = Math.Abs(tile.topEdge - playerPrediction.bottomEdge);

                    if (IsColliding(playerPrediction, tile ) == tile)
                    {
                        hero.Position.Y = tile.bottomEdge + hero.offset.Y;
                        hero.velocity.Y = 0;
                    }
                    else if (leftEdgeDistance < rightEdgeDistance) 
                    {
                        hero.Position.X = tile.rightEdge + hero.offset.Y;
                        hero.velocity.X = 0;
                    }
                }
                
            }
        }
    }
}