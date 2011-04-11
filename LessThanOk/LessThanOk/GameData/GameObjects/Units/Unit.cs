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
 * A unit. Units have armor, weapons, and engines that allow them to move.   *
 * Units also have a set of commands to execute, and some basic AI           *
 *                                                                           *
 * See GameObject, GameObjectType, GameObjectFactory, pretty much everything.*
 *                                                                           *
\*---------------------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using LessThanOk.Network.Commands;
using LessThanOk.GameData.GameObjects;
using LessThanOk.Sprites;
[assembly: InternalsVisibleTo("UnitType")]

namespace LessThanOk.GameData.GameObjects.Units
{
    /// <summary>
    /// A unit. Units have armor, weapons, and engines that allow them to move.
    /// </summary>
    public class Unit : ActiveGameObject
    {
        public event EventHandler unitKilled;
        public event EventHandler unitHealthChange;
        public event EventHandler unitWeaponFired;
        public event EventHandler unitUsedAbility;

        private UnitType type;

        /// <summary>
        /// The type of this unit
        /// </summary>
        public UnitType Type
        {
            get { return type; }
            private set { type = value; }
        }

        private Vector3 velocity;

        private UInt32 hp;

        /// <summary>
        /// How much health this unti has.
        /// </summary>
        public UInt32 health
        {
            get { return hp; }
            set { hp = value; }
        }

        private ActiveGameObject target;

        public ActiveGameObject Target
        {
            get { return target; }
            set { target = value; }
        }

        private bool aggressive;
        private bool pursue;

        private Queue<Command> commands;

        static Unit()
        {
            AgnosticObject.initFieldMaps(typeof(Unit));
        }

        protected Unit() : base() { init(); }

        internal Unit(UnitType t)
            : base()
        {
            type = t;
        }

        /// <summary>
        /// Copy ctor
        /// </summary>
        /// <param name="u">
        /// A <see cref="Unit"/>
        /// </param>
        public Unit(Unit u)
            : base()
        {
            init();

            this.type = u.type;
        }

        private void init()
        {
            velocity = new Vector3();
            target = null;
            commands = new Queue<Command>();
            aggressive = false;
            pursue = false;
        }

        /// <summary>
        /// Update the unit.
        /// </summary>
        /// <param name="elps">
        /// A <see cref="GameTime"/>
        /// </param>
        override public void update(GameTime elps)
        {
            switch (commands.Peek().getCommandType())
            {
                case Command.T_COMMAND.MOVE:
                    break;
                //case Command.T_COMMAND.USEABILITY:
                //    break;
                default:
                    break;
            }
        }

        public void addCommand(Command newCommand)
        {
            if (newCommand.getCommandType() == Command.T_COMMAND.CANCEL)
            {
                commands.Clear();
            }
            else
            {
                commands.Enqueue(newCommand);
            }
        }

        //	public WeaponFire fireWeapon()
    }
}