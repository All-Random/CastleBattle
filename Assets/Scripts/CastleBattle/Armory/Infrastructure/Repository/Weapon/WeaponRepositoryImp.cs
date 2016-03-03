using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using CastleBattle.Armory;

namespace CastleBattle.Armory
{
	public class WeaponRepositoryImp : WeaponRepository
	{
		public void Save (Weapon weapon)
		{ 
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/weapon.dat", FileMode.OpenOrCreate);
			bf.Serialize (file, new WeaponData(weapon));
			file.Close ();
		}

		public Weapon Load (int id)
		{
			if (File.Exists (Application.persistentDataPath + "/weapon.dat")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/weapon.dat", FileMode.Open);
				Weapon weapon = ((WeaponData)bf.Deserialize (file)).Weapon();
				file.Close ();
				return weapon;
			}
			throw new System.NotImplementedException ();
		}

		public void Remove (int id)
		{
			throw new System.NotImplementedException ();
		}			
	}

	[Serializable]
	class WeaponData
	{
		public int id;
		public string name;
		public float damage;
		public float coldDown;

		public WeaponData (Weapon weapon)
		{
			id = weapon.Id;
			name = weapon.Name;
			damage = weapon.Damage;
			coldDown = weapon.ColdDown;
		}

		public Weapon Weapon()
		{
			return new Weapon (id, name, damage, coldDown);
		}
	}
}
