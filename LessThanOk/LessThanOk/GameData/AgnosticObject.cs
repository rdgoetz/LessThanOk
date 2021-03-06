/*---------------------------------------------------------------------------*\
 *                         LessThanOK Engine                                 *
 *                                                                           *
 *          Copyright (C) 2011-2012 by Robert Goetz,                         *
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
 * This class provides an agnostic way of setting and getting the properties *
 * of an object. It also provides maps into the properties for quick         *
 * operations.                                                               *
 *                                                                           *
 * Subclasses must have a static initializer that calls their own version    *
 * of initFieldMaps()                                                        *
 *                                                                           *
 * See GameObject, GameObjectType, GameObjectFactory                         *
 *                                                                           *
\*---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using LessThanOk.GameData.GameObjects;
///<summary>
///Provides an agnostic interface for modifying an object. Fields can be
///accessed by their name using the provided functions.
///</summary>
public class AgnosticObject
{
	protected static Dictionary<ushort,string> idDecode;
    protected static Dictionary<string, ushort> stringDecode;

	static AgnosticObject()
	{
        idDecode = new Dictionary<ushort, string>();
        stringDecode = new Dictionary<string, ushort>();
		initFieldMaps(typeof(AgnosticObject));
	}
	
    /// <summary>
    /// Initializes the field maps for decoding an
    /// ID value to the name of a property of
    /// the calling class and reverse. Allows for
    /// agnostically setting properties from an int
    /// value.
    /// 
    /// </summary>
	protected static void initFieldMaps(Type typeInfo)
	{
        PropertyInfo[] properties = typeInfo.GetProperties();
		
        foreach (PropertyInfo property in properties)
        {
            UInt16 id = (UInt16) stringDecode.Count;
            if (!stringDecode.ContainsKey(property.Name))
            {
                stringDecode[property.Name] = id;
                idDecode[id] = property.Name;
            }
        }
	}

    private void setProperty(string fieldName, object newValue)
    {
        
        this.GetType().InvokeMember(
            fieldName, BindingFlags.SetProperty, null, this, new object[] { newValue });
    }
	
	/// <summary>
	/// Set a field given its name and a new value.
	/// </summary>
	/// <param name="fieldName">
	/// A <see cref="System.String"/>
	/// </param>
	/// <param name="newValue">
	/// A <see cref="System.Object"/>
	/// </param>
    public void setField(string fieldName, uint newValue)
	{
        Type t = this.GetType().GetProperty(fieldName).PropertyType;
        if(t.IsSubclassOf(typeof(GameObject)))
        {
            setProperty(fieldName, GameObjectFactory.The.getGameObject((ushort)newValue));
        }
        else if (t.IsSubclassOf(typeof(GameObjectType)))
        {
            setProperty(fieldName, GameObjectFactory.The.getType((ushort)newValue));
        }
        else
        {
            setProperty(fieldName, newValue);
        }
	}
	
	/// <summary>
	/// Set a field given its ID and a new value.
	/// </summary>
	/// <param name="fieldID">
	/// A <see cref="System.UInt16"/>
	/// </param>
	/// <param name="newValue">
	/// A <see cref="System.Object"/>
	/// </param>
	public void setField(ushort fieldID, uint newValue)
	{
        setField(idDecode[fieldID], newValue);
	}
	
	/// <summary>
	/// Get a field's ID for its name
	/// </summary>
	/// <param name="fieldName">
	/// A <see cref="System.String"/>
	/// </param>
	/// <returns>
	/// A <see cref="UInt16"/>
	/// </returns>
	public UInt16 getFieldID(string fieldName)
	{
		return stringDecode[fieldName];
	}
}
