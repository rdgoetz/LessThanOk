/*---------------------------------------------------------------------------*\
 *                         LessThanOK Engine                                 *
 *                                                                           *
 *          Copyright (C) 2011-2012 by Robert Goetz, Anthony Lobono          *
 *                                                                           *
 *   authors:  Robert Goetz (rdgoetz@iastate.edu)                            *
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
 * The type of a game object. Types are responsible for creating objects of  *
 * their type.                                                               *
 *                                                                           *
 * See GameObject, GameObjectType, GameObjectFactory                         *
 *                                                                           *
\*---------------------------------------------------------------------------*/


using System;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LessThanOk.GameData.GameObjects
{
    /// <summary>
    /// Prototype for a game object.
    /// </summary>
    public abstract class GameObjectType : AgnosticObject//potentially make class GameObjectType<T> where T:GameObject
    {
        protected GameObject protoType;

        private UInt16 id;

        public UInt16 ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        /// <summary>
        /// The name of this type.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        static GameObjectType()
        {
            AgnosticObject.initFieldMaps(typeof(GameObjectType));
        }

        public GameObjectType()
        {
        }

        /// <summary>
        /// Creates an object of this type.
        /// </summary>
        /// <returns>
        /// The newly created object <see cref="GameObject"/>
        /// </returns>
        public abstract GameObject create();
    }
}