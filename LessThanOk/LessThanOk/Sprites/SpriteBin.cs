﻿/*---------------------------------------------------------------------------*\
 *                         LessThanOK Engine                                 *
 *                                                                           *
 *          Copyright (C) 2011-2012 by Robert Goetz, Anthony Lobono          *
 *                                                                           *
 *   authors:  Anthony LoBono (ajlobono@gmail.com)                           *
 *                                                                           *
\*---------------------------------------------------------------------------*/
/*---------------------------------------------------------------------------*\
 *                                License                                    *
 *                                                                           *
 * This library is free software; you can redistribute it and/or modify it   *
 * under the terms of the MIT Liscense.                                      *
 *                                                                           *
 * This library is distributed in the hope that it will be useful, but       *
 * WITHOUT ANY WARRANTY; without even the implied warranty of                *
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.                      *
 *                                                                           *
 * You should have received a copy of the MIT Liscense with this library, if *
 * not, visit http://www.opensource.org/licenses/mit-license.php.            *
 *                                                                           *
\*---------------------------------------------------------------------------*/
/*---------------------------------------------------------------------------*\
 *                            Class Overview                                 *
 *                                                                           *
 * SpriteBin is responsible for creating all instances of Sprites.           *
 *                                                                           *                                 
 * See: Sprite.cs                                                            *
 *                                                                           *
\*---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LessThanOk.Sprites
{
    class SpriteBin
    {
        List<Sprite> sprites;

        private SpriteFont _font;
        /// <summary>
        /// Contructor for SpriteBin.
        /// </summary>
        /// <param name="font">Font to be used for all sprites.  Shouls be a list</param>
        public SpriteBin(SpriteFont font)
        {
            sprites = new List<Sprite>();
            _font = font;
        }

        /// <summary>
        /// Get a new instantce of a Sprite_Text
        /// </summary>
        /// <param name="content">Text for the Sprite</param>
        /// <returns>New instance of a Sprite_Text</returns>
        public Sprite_Text AddTextSprite(string content)
        {
            Sprite_Text s = new Sprite_Text(content, _font);
            sprites.Add(s);
            return s;
        }
        /// <summary>
        /// Add a Sprite to the sprite list
        /// </summary>
        /// <param name="s">Sprite to be added to list.</param>
        public void Add(Sprite s)
        {
            sprites.Add(s);
        }
        /// <summary>
        /// Clear the sprite list.
        /// </summary>
        public void Clear()
        {
            sprites.Clear();
        }

    }
}